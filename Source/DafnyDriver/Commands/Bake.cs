using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Microsoft.Dafny.Compilers {
  public class Bake {
    // NOTE We do not consistently throw errors on unsupported
    //   features, so it is possible that a program we don't
    //   actually support gets translated into something similar.

    // TODO? Use NormalizeExpand() on types?

    private static string seq_name = "Then";

    public static string ProgramToString(Program program) {
      var compileModules = program.CompileModules;

      // For now, we only consider programs with a single module besides
      // the system module
      if (compileModules.Count() != 2) {
        throw UnsupportedError(compileModules);
      }
      if (!compileModules.First().Name.Equals("_System")) {
        throw UnsupportedError(compileModules.First());
      }

      // The single module we consider should only have a DefaultClassDecl
      var topLevelDecls = compileModules.ElementAt(1).TopLevelDecls;
      if (topLevelDecls.Count() != 1) {
        throw UnsupportedError(topLevelDecls);
      }
      var defaultClassDecl = (DefaultClassDecl)topLevelDecls.First();
      var members = defaultClassDecl.Members;


      return StringListToString([
        "Program",
        ListToString(MemberDeclToString, members)
      ]);
    }

    // Helper functions in case we need to handle these nodes less naively,
    // that is, do more than pretending they are complicated lists of expressions
    public static string AttributedExpressionToString(AttributedExpression attrExp) =>
      ExpressionToString(attrExp.E);

    public static string FrameExpSpecToString(Specification<FrameExpression> specs) {
      var expressions = specs.Expressions;

      // Instead of mapping "null" to None, map it to []
      expressions ??= [];

      return ListToString(ExpressionToString, expressions.Select(x => x.E));
    }

    public static string ExpSpecToString(Specification<Expression> specs) =>
      ListToString(ExpressionToString, specs.Expressions);

    public static string MemberDeclToString(MemberDecl member) {
      if (member is Method method) {
        var name = method.Name;
        var ins = method.Ins;
        var req = method.Req;
        var ens = method.Ens;
        var reads = method.Reads;
        var decreases = method.Decreases;
        var outs = method.Outs;
        var mod = method.Mod;
        var body = method.Body;

        return StringListToString([
          "Method",
          EscapeAndQuote(name),
          ListToString(FormalToString, ins),
          ListToString(AttributedExpressionToString, req),
          ListToString(AttributedExpressionToString, ens),
          FrameExpSpecToString(reads),
          ExpSpecToString(decreases),
          ListToString(FormalToString, outs),
          FrameExpSpecToString(mod),
          StatementToString(body)
        ]);
      } else if (member is Function function) {
        var name = function.Name;
        var ins = function.Ins;
        var resultType = function.ResultType;
        var req = function.Req;
        var reads = function.Reads;
        var body = function.Body;

        return StringListToString([
          "Function",
          EscapeAndQuote(name),
          ListToString(FormalToString, ins),
          TypeToString(resultType),
          ListToString(AttributedExpressionToString, req),
          FrameExpSpecToString(reads),
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
        EscapeAndQuote(name),
        TypeToString(type)
      ]);
    }

    public static string TypeToString(Type type) {
      if (type is TypeProxy typeProxy) {
        return TypeToString(typeProxy.T);
      }

      if (type.IsStringType) {
        return StringListToString(["StringT"]);
      } else if (type is IntType) {
        return StringListToString(["IntT"]);
      } else if (type is BoolType) {
        return StringListToString(["BoolT"]);
      } else if (type.IsArrayType) {
        var arrayType = type.AsArrayType;
        if (arrayType.Dims != 1) {
          throw UnsupportedError(type);
        }

        // Resolve type argument
        Contract.Assert(type.TypeArgs.Count == 1);

        return StringListToString([
          "ArrayT",
          TypeToString(type.TypeArgs[0])
        ]);
      } else {
        throw UnsupportedError(type);
      }
    }

    public static string ExpressionWithTypeToString(Expression expression) {
      if (expression.WasResolved()) {
        expression = expression.Resolved;
      }

      var type = expression.Type;

      return StringListToString([
        ExpressionToString(expression),
        TypeToString(type)
      ]);
    }

    public static LiteralExpr InitExpr(Type type) {
      if (type is IntType) {
        return new LiteralExpr(Token.NoToken, 0);
      } else {
        throw UnsupportedError(type);
      }
    }

    public static string AssignToString(List<Expression> lhss, List<AssignmentRhs> rhss) {
      if (rhss.Count == 1 && IsMethodCall(rhss[0])) {
        var lhss_string = ListToString(ExpressionToString, lhss);
        var mc_string = MethodCallToString(rhss[0]);

        return StringListToString([
          "MetAssign",
          lhss_string,
          mc_string
        ]);
      } else {
        Contract.Assert(!rhss.Any(IsMethodCall));
        Contract.Assert(lhss.Count == rhss.Count);

        var assigns = lhss.Zip(rhss,
          (lhs, rhs) => StringListToString([
            ExpressionToString(lhs),
            RhsExpToString(rhs)
          ]));

        return StringListToString([
          "ParAssign",
          StringListToString(assigns)]);
      }
    }

    public static string VarDeclToString(VarDeclStmt varDeclStmt, List<Statement> scope) {
      var locals = varDeclStmt.Locals;
      var assign = varDeclStmt.Assign;

      if (assign is AssignStatement assignStatement) {
        var lhss = assignStatement.Lhss;
        var rhss = assignStatement.Rhss;

        return StringListToString([
          "VarDecl",
          ListToString(LocalVariableToString, locals),
          AssignToString(lhss, rhss),
          StatementListToString(scope),
        ]);
      } else {
        throw UnsupportedError(assign);
      }
    }

    public static string StatementToString(Statement statement) {
      if (statement is AssignStatement assignStatement) {
        var lhss = assignStatement.Lhss;
        var rhss = assignStatement.Rhss;

        return StringListToString([
          "AssignStmt",
          AssignToString(lhss, rhss)
        ]);
      } else if (statement is IfStmt ifStmt) {
        var guard = ifStmt.Guard;
        var thn = ifStmt.Thn;
        var els = ifStmt.Els;

        return StringListToString([
          "If",
          ExpressionToString(guard),
          StatementToString(thn),
          NullableStatementToString(els)
        ]);
      } else if (statement is VarDeclStmt varDeclStmt) {
        return VarDeclToString(varDeclStmt, null);
      } else if (statement is WhileStmt whileStmt) {
        var guard = whileStmt.Guard;
        var invariants = whileStmt.Invariants;
        var decreases = whileStmt.Decreases;
        var mod = whileStmt.Mod;
        var body = whileStmt.Body;

        return StringListToString([
          "While",
          ExpressionToString(guard),
          ListToString(AttributedExpressionToString, invariants),
          ExpSpecToString(decreases),
          FrameExpSpecToString(mod),
          StatementToString(body)
        ]);
      } else if (statement is BlockStmt blockStmt) {
        return StatementListToString(blockStmt.Body);
      } else if (statement is PrintStmt printStmt) {
        var args = printStmt.Args;

        return StringListToString([
          "Print",
          ListToString(ExpressionWithTypeToString, args)
        ]);

      } else if (statement is ReturnStmt returnStmt) {
        var return_string = StringListToString(["Return"]);
        var hiddenUpdate = returnStmt.HiddenUpdate;

        if (hiddenUpdate is null) {
          return return_string;
        } else {
          return StringListToString([
            seq_name,
            StatementToString(hiddenUpdate),
            return_string
          ]);
        }
      } else if (statement is AssertStmt assertStmt) {
        var expr = assertStmt.Expr;

        return StringListToString([
          "Assert",
          ExpressionToString(expr)
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
          VarDeclToString(varDecl, rest),
        [var stmt, .. var rest] =>
          StringListToString([
            seq_name,
            StatementToString(stmt),
            StatementListToString(rest)
          ])
      };

    public static string ExpressionToString(Expression expression) {
      if (expression.WasResolved()) {
        expression = expression.Resolved;
      }

      if (expression is IdentifierExpr identifierExpr) {
        var name = identifierExpr.Name;
        var type = identifierExpr.Type;

        return StringListToString([
          "IdentifierExp",
          EscapeAndQuote(name),
          TypeToString(type)
        ]);
      } else if (expression is BinaryExpr binaryExpr) {
        var rop = binaryExpr.ResolvedOp;
        var e0 = binaryExpr.E0;
        var e1 = binaryExpr.E1;

        return StringListToString([
          "BinaryExp",
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
            "StringLit",
            isVerbatim.ToString(),
            EscapeAndQuote((string)value)
          ]);
        } else if (expression is StaticReceiverExpr) {
          // We do not support receivers, so reaching the point
          // probably means we have an unnecessary field somewhere.
          throw UnsupportedError(expression);
        } else if (value is BigInteger bigInteger) {
          valueAsString = StringListToString([
            "IntLit",
            bigInteger.ToString()
          ]);
        } else if (LiteralExpr.IsTrue(literalExpr)) {
          valueAsString = StringListToString([
            "BoolLit",
            "True"
          ]);
        } else if (LiteralExpr.IsFalse(literalExpr)) {
          valueAsString = StringListToString([
            "BoolLit",
            "False"
         ]);
        } else {
          throw UnsupportedError(literalExpr);
        }

        return StringListToString([
          "LiteralExp",
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
          "ITE",
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
      } else if (expression is ForallExpr forallExpr) {
        var boundVars = forallExpr.BoundVars;
        var range = forallExpr.Range;
        var term = forallExpr.Term;
        // NOTE Attributes probably contain triggers; these might be useful?

        if (range is not null) {
          throw UnsupportedError(forallExpr);
        }

        return StringListToString([
          "ForallExp",
          ListToString(BoundVarToString, boundVars),
          ExpressionToString(term)
        ]);
      } else {
        throw UnsupportedError(expression);
      }
    }

    public static string BoundVarToString(BoundVar boundVar) {
      var name = boundVar.Name;
      var type = boundVar.Type;

      // Note that this is essentially a tuple
      return StringListToString([
        EscapeAndQuote(name),
        TypeToString(type)
      ]);
    }

    public static string LocalVariableToString(LocalVariable localVariable) {
      var name = localVariable.Name;
      var type = localVariable.Type;

      return StringListToString([
        EscapeAndQuote(name),
        TypeToString(type)
      ]);
    }

    public static string ResolvedOpcodeToString(BinaryExpr.ResolvedOpcode rop) =>
      rop switch {
        BinaryExpr.ResolvedOpcode.Lt => StringListToString(["Lt"]),
        BinaryExpr.ResolvedOpcode.Le => StringListToString(["Le"]),
        BinaryExpr.ResolvedOpcode.Ge => StringListToString(["Ge"]),
        BinaryExpr.ResolvedOpcode.EqCommon => StringListToString(["Eq"]),
        BinaryExpr.ResolvedOpcode.NeqCommon => StringListToString(["Neq"]),
        BinaryExpr.ResolvedOpcode.Sub => StringListToString(["Sub"]),
        BinaryExpr.ResolvedOpcode.Add => StringListToString(["Add"]),
        BinaryExpr.ResolvedOpcode.Mul => StringListToString(["Mul"]),
        BinaryExpr.ResolvedOpcode.Div => StringListToString(["Div"]),
        BinaryExpr.ResolvedOpcode.And => StringListToString(["And"]),
        BinaryExpr.ResolvedOpcode.Imp => StringListToString(["Imp"]),
        BinaryExpr.ResolvedOpcode.Or => StringListToString(["Or"]),
        _ => throw UnsupportedError(rop)
      };

    // Method calls are special right-hand side expressions, as they can return
    // multiple things; hence, we deal with them separately.

    // Determining method calls like this has been "discovered" by looking at
    // concrete examples, and CloneExpr in ExtremeLemmaBodyCloner.cs
    public static bool IsMethodCall(AssignmentRhs rhs) =>
      rhs is ExprRhs exprRhs && exprRhs.Expr is ApplySuffix;

    public static string MethodCallToString(AssignmentRhs rhs) {
      Contract.Assert(IsMethodCall(rhs));

      var exprRhs = (ExprRhs)rhs;
      var expr = exprRhs.Expr;
      var applySuffix = (ApplySuffix)expr;
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
    }

    public static string RhsExpToString(AssignmentRhs assignmentRhs) {
      Contract.Assert(!IsMethodCall(assignmentRhs));

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