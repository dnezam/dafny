using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Microsoft.Dafny.Compilers {
  public class Bake {

    // TODO? Use NormalizeExpand() on types?
    // TODO? When we start to consider ghost code, make sure to
    //   account for that

    public static string ProgramToString(Program program) {
      var compileModules = program.CompileModules;

      return StringListToString([
        "Program",
        ListToString(ModuleDefinitionToString, compileModules)
        // TODO Add name of main method?
      ]);
    }

    public static string ModuleDefinitionToString(ModuleDefinition m) {
      var name = m.Name;
      var topLevelDecls = m.TopLevelDecls;

      if (name.Equals("_System")) {
        // NOTE Ignore system module for now
        return "";
      } else {
        return StringListToString([
          "Module",
          EscapeAndQuote(name),
          ListToString(TopLevelDeclToString, topLevelDecls)
        ]);
      }
    }

    public static string TopLevelDeclToString(TopLevelDecl decl) {
      if (decl is DefaultClassDecl defaultClassDecl) {
        var name = defaultClassDecl.Name;
        var members = defaultClassDecl.Members;

        return StringListToString([
          "DefaultClassDecl",
          EscapeAndQuote(name),
          ListToString(MemberDeclToString, members)
        ]);
      } else {
        throw UnsupportedError(decl);
      }
    }

    public static string MemberDeclToString(MemberDecl member) {
      if (member is Method method) {
        var name = method.Name;
        var ins = method.Ins;
        var outs = method.Outs;
        var body = method.Body;

        return StringListToString([
          "Method",
          EscapeAndQuote(name),
          ListToString(FormalToString, ins),
          ListToString(FormalToString, outs),
          StatementListToString(body.Body)
        ]);
      } else if (member is Function function) {
        var name = function.Name;
        var ins = function.Ins;
        var resultType = function.ResultType;
        var body = function.Body;

        return StringListToString([
          "Function",
          EscapeAndQuote(name),
          ListToString(FormalToString, ins),
          TypeToString(resultType),
          ExpressionToString(body)
        ]);
      } else {
        throw UnsupportedError(member);
      }
    }

    public static string FormalToString(Formal formal) {
      var name = formal.Name;
      var type = formal.Type;

      return StringListToString([
        "Formal",
        EscapeAndQuote(name),
        TypeToString(type)
      ]);
    }

    public static string TypeToString(Type type) {
      if (type is IntType) {
        return StringListToString(["IntType"]);
      } else if (type is BoolType) {
        return StringListToString(["BoolType"]);
      } else if (type is UserDefinedType userDefinedType) {
        var name = userDefinedType.Name;

        return StringListToString([
          "UserDefinedType",
          EscapeAndQuote(name)
        ]);
      } else {
        throw UnsupportedError(type);
      }
    }

    public static LiteralExpr InitExpr(Type type) {
      if (type is IntType) {
        return new LiteralExpr(Token.NoToken, 0);
      } else {
        throw UnsupportedError(type);
      }
    }


    public static string StatementToString(Statement statement) {
      if (statement is AssignStatement assignStatement) {
        var lhss = assignStatement.Lhss;
        var rhss = assignStatement.Rhss;

        return StringListToString([
          "AssignStatement",
          ListToString(ExpressionToString, lhss),
          ListToString(AssignmentRhsToString, rhss)
        ]);
      } else if (statement is IfStmt ifStmt) {
        var guard = ifStmt.Guard;
        var thn = ifStmt.Thn;
        var els = ifStmt.Els;

        return StringListToString([
          "IfStmt",
          ExpressionToString(guard),
          StatementListToString(thn.Body),
          NullableStatementToString(els)
        ]);
      } else if (statement is VarDeclStmt varDeclStmt) {
        var locals = varDeclStmt.Locals;
        var assign = varDeclStmt.Assign;

        return StringListToString([
          "VarDeclStmt",
          ListToString(LocalVariableToString, locals),
          NullableStatementToString(assign)
        ]);
      } else if (statement is WhileStmt whileStmt) {
        var guard = whileStmt.Guard;
        var body = whileStmt.Body;

        return StringListToString([
          "WhileStmt",
          ExpressionToString(guard),
          StatementListToString(body.Body)
        ]);
      } else if (statement is BlockStmt blockStmt) {
        return StatementListToString(blockStmt.Body);
      } else if (statement is PrintStmt printStmt) {
        var args = printStmt.Args;

        return StringListToString([
          "PrintStmt",
          ListToString(ExpressionToString, args)
        ]);

      } else if (statement is ReturnStmt returnStmt) {
        var rhss = returnStmt.Rhss;

        return StringListToString([
          "ReturnStmt",
          NullableToString(x => ListToString(AssignmentRhsToString, x), rhss)
        ]);
      } else {
        throw UnsupportedError(statement);
      }
    }

    public static string StatementListToString(List<Statement> stmts) =>
      stmts switch {
        [] => StringListToString(["Skip"]),
        [var stmt] => StatementToString(stmt),
        [VarDeclStmt varDecl, .. var rest] =>
          StringListToString([
            "VarDeclStmt",
            ListToString(LocalVariableToString, varDecl.Locals),
            NullableStatementToString(varDecl.Assign),
            StatementListToString(rest)
        ]),
        [var stmt, .. var rest] =>
          StringListToString([
            "Then",
            StatementToString(stmt),
            StatementListToString(rest)
          ])
      };

    public static string ExpressionToString(Expression expression) {
      // TODO Find out whether resolving like this makes sense
      if (expression.WasResolved()) {
        expression = expression.Resolved;
      }

      // Somewhat based on CloneExpr in ExtremeLemmaBodyCloner.cs
      if (expression is ApplySuffix applySuffix) {
        // ApplySuffix was not resolved; that's weird. Seems to be just
        // a method call, so let's go with that.

        // Get method name
        var mse = (MemberSelectExpr)applySuffix.Lhs.Resolved;
        Contract.Assert(mse.Member is Method);
        var name = mse.MemberName;

        // Get arguments
        var args = applySuffix.Bindings.ArgumentBindings.
          Select(b => b.Actual.Resolved);

        return StringListToString([
          "MethodCall",
          EscapeAndQuote(name),
          ListToString(ExpressionToString, args)
        ]);
      } else if (expression is IdentifierExpr identifierExpr) {
        var name = identifierExpr.Name;
        var type = identifierExpr.Type;

        return StringListToString([
          "IdentifierExpr",
          EscapeAndQuote(name),
          TypeToString(type)
        ]);
      } else if (expression is BinaryExpr binaryExpr) {
        var rop = binaryExpr.ResolvedOp;
        var e0 = binaryExpr.E0;
        var e1 = binaryExpr.E1;

        return StringListToString([
          "BinaryExpr",
          ResolvedOpcodeToString(rop),
          ExpressionToString(e0),
          ExpressionToString(e1)
        ]);
      } else if (expression is LiteralExpr literalExpr) {
        string valueAsString;

        var value = literalExpr.Value;
        if (expression is StringLiteralExpr stringLiteralExpr) {
          var isVerbatim = stringLiteralExpr.IsVerbatim;

          valueAsString = StringListToString([
            "StringLiteral",
            isVerbatim.ToString(),
            EscapeAndQuote((string)value)
          ]);
        } else if (expression is StaticReceiverExpr) {
          // We do not support receivers, so reaching the point
          // probably means we have an unnecessary field somewhere.
          throw UnsupportedError(expression);
        } else if (value is null) {
          valueAsString = StringListToString(["Null"]);
        } else if (value is BigInteger bigInteger) {
          valueAsString = StringListToString([
            "BigInteger",
            bigInteger.ToString()
          ]);
        } else if (LiteralExpr.IsTrue(literalExpr)) {
          valueAsString = StringListToString([
            "BoolV",
            "True"
          ]);
        } else if (LiteralExpr.IsFalse(literalExpr)) {
          valueAsString = StringListToString([
           "BoolV",
            "False"
         ]);
        } else {
          throw UnsupportedError(literalExpr);
        }

        return StringListToString([
          "LiteralExpr",
          valueAsString
        ]);
      } else if (expression is SeqSelectExpr seqSelectExpr) {
        var selectOne = seqSelectExpr.SelectOne;
        var seq = seqSelectExpr.Seq;
        var e0 = seqSelectExpr.E0;
        var e1 = seqSelectExpr.E1;

        if (selectOne && seq.Type.IsArrayType) {
          Contract.Assert(e0 != null && e1 == null);
          return StringListToString([
            "ArraySelect",
            ExpressionToString(seq),
            ExpressionToString(e0)
          ]);
        } else {
          throw UnsupportedError(seqSelectExpr);
        }
      } else if (expression is ITEExpr iteeExpr) {
        var test = iteeExpr.Test;
        var thn = iteeExpr.Thn;
        var els = iteeExpr.Els;

        return StringListToString([
          "ITEExpr",
          ExpressionToString(test),
          ExpressionToString(thn),
          ExpressionToString(els)
        ]);

      } else if (expression is FunctionCallExpr functionCallExpr) {
        var name = functionCallExpr.Name;
        var receiver = functionCallExpr.Receiver;
        var args = functionCallExpr.Args;

        if (receiver is StaticReceiverExpr staticReceiver) {
          // We can drop the receiver, since we only support
          // default for now.
          return StringListToString([
            "FunctionCall",
            EscapeAndQuote(name),
            ListToString(ExpressionToString, args)
          ]);
        } else {
          throw UnsupportedError(functionCallExpr);
        }
      } else if (expression is MemberSelectExpr memberSelectExpr) {
        var obj = memberSelectExpr.Obj.Resolved;
        var name = memberSelectExpr.MemberName;

        // For now, only support length for one-dimensional arrays
        var type = obj.Type;
        if (name == "Length" && type.IsArrayType && type.AsArrayType.Dims == 1) {
          return StringListToString([
            "ArrayLen",
            ExpressionToString(obj)
          ]);
        } else {
          throw UnsupportedError(memberSelectExpr);
        }
      } else {
        throw UnsupportedError(expression);
      }
    }

    public static string LocalVariableToString(LocalVariable localVariable) {
      var name = localVariable.Name;
      var type = localVariable.Type;

      return StringListToString([
        "LocalVariable",
        EscapeAndQuote(name),
        TypeToString(type)
      ]);
    }

    public static string ResolvedOpcodeToString(BinaryExpr.ResolvedOpcode rop) =>
      rop switch {
        BinaryExpr.ResolvedOpcode.Lt => StringListToString(["Lt"]),
        BinaryExpr.ResolvedOpcode.EqCommon => StringListToString(["EqCommon"]),
        BinaryExpr.ResolvedOpcode.NeqCommon => StringListToString(["NeqCommon"]),
        BinaryExpr.ResolvedOpcode.Sub => StringListToString(["Sub"]),
        BinaryExpr.ResolvedOpcode.Add => StringListToString(["Add"]),
        BinaryExpr.ResolvedOpcode.Div => StringListToString(["Div"]),
        _ => throw UnsupportedError(rop)
      };

    public static string AssignmentRhsToString(AssignmentRhs assignmentRhs) {
      if (assignmentRhs is ExprRhs exprRhs) {
        var expr = exprRhs.Expr;

        return StringListToString([
          "ExprRhs",
          ExpressionToString(expr)
        ]);
      } else if (assignmentRhs is AllocateArray allocateArray) {
        var explicitType = allocateArray.ExplicitType;
        var arrayDimensions = allocateArray.ArrayDimensions;
        var elementInit = allocateArray.ElementInit;
        var initDisplay = allocateArray.InitDisplay;

        if (arrayDimensions.Count != 1) {
          throw UnsupportedError(arrayDimensions);
        }

        if (initDisplay is not null && elementInit is not null) {
          // This should not happen
          Contract.Assert(false);
        }

        var length = arrayDimensions[0];

        if (initDisplay is not null) {
          throw UnsupportedError(assignmentRhs);
        } else {
          var initValue = elementInit is null ? InitExpr(explicitType) : elementInit;

          return StringListToString([
            "AllocArray",
            TypeToString(explicitType),
            ExpressionToString(length),
            ExpressionToString(initValue)
          ]);
        }
      } else {
        throw UnsupportedError(assignmentRhs);
      }
    }

    public static string NullableStatementToString(Statement stmt) {
      if (stmt is null) {
        return StringListToString(["Skip"]);
      } else {
        return StatementToString(stmt);
      }
    }

    public static string NullableToString<T>(Func<T, string> f, T t) {
      if (t is null) {
        return StringListToString(["None"]);
      } else {
        return StringListToString([
          "Some",
          f(t)
        ]);
      }
    }

    public static string StringListToString(IEnumerable<string> xs) {
      return ListToString(x => x, xs);
    }

    public static string ListToString<T>(Func<T, string> f, IEnumerable<T> xs) {
      return "(" + string.Join(" ", xs.Select(f).Where(x => x != "")) + ")";
    }

    public static string EscapeAndQuote(string str) {
      ArgumentNullException.ThrowIfNull(str);

      StringBuilder sb = new StringBuilder();
      sb.Append('"');
      foreach (char c in str) {
        if (c == '"' || c == '\\') {
          sb.Append('\\');
        }
        sb.Append(c);
      }
      sb.Append('"');
      return sb.ToString();
    }

    private static ExtractorError UnsupportedError(object obj) {
      var typeName = obj.GetType().Name;
      var startToken = (obj is INode) ? ((INode)obj).StartToken : Token.NoToken;

      return new ExtractorError(startToken, $"Unsupported {typeName}: {obj}\n{Environment.StackTrace}");
    }
  }
}