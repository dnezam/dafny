using System;
using System.Collections.Generic;
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
          BlockStmtToString(body)
        ]);
      } else {
        throw UnsupportedError(member);
      }
    }

    public static string BlockStmtToString(BlockStmt blockStmt) {
      var body = blockStmt.Body;

      return StringListToString([
        "BlockStmt",
        ListToString(StatementToString, body)
      ]);
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
      } else {
        throw UnsupportedError(type);
      }
    }

    public static string StatementToString(Statement statement) {
      if (statement is ConcreteAssignStatement concreteAssignStatement) {
        return StringListToString([
          "Statement_ConcreteAssignStatement",
          ConcreteAssignStatementToString(concreteAssignStatement)
        ]);
      } else if (statement is IfStmt ifStmt) {
        var guard = ifStmt.Guard;
        var thn = ifStmt.Thn;
        var els = ifStmt.Els;

        return StringListToString([
          "IfStmt",
          ExpressionToString(guard),
          BlockStmtToString(thn),
          StatementToString(els)
        ]);
      } else if (statement is VarDeclStmt varDeclStmt) {
        var locals = varDeclStmt.Locals;
        var assign = varDeclStmt.Assign;

        return StringListToString([
          "VarDeclStmt",
          ListToString(LocalVariableToString, locals),
          ConcreteAssignStatementToString(assign)
        ]);
      } else if (statement is WhileStmt whileStmt) {
        var guard = whileStmt.Guard;
        var body = whileStmt.Body;

        return StringListToString([
          "WhileStmt",
          ExpressionToString(guard),
          BlockStmtToString(body)
        ]);
      } else if (statement is BlockStmt blockStmt) {
        var block = BlockStmtToString(blockStmt);

        return StringListToString([
          "Statement_BlockStatement",
          block
        ]);

      } else if (statement is PrintStmt printStmt) {
        var args = printStmt.Args;

        return StringListToString([
          "PrintStmt",
          ListToString(ExpressionToString, args)
        ]);

      } else {
        throw UnsupportedError(statement);
      }
    }

    public static string ConcreteAssignStatementToString(ConcreteAssignStatement concreteAssignStatement) {
      if (concreteAssignStatement is AssignStatement assignStatement) {
        var lhss = assignStatement.Lhss;
        var rhss = assignStatement.Rhss;

        return StringListToString([
          "AssignStatement",
          ListToString(ExpressionToString, lhss),
          ListToString(AssignmentRhsToString, rhss)
        ]);
      } else {
        throw UnsupportedError(concreteAssignStatement);
      }
    }

    public static string ExpressionToString(Expression expression) {
      // TODO Find out whether resolving like this makes sense
      if (expression.WasResolved()) {
        expression = expression.Resolved;
      }

      // Somewhat based on CloneExpr in ExtremeLemmaBodyCloner.cs
      if (expression is ApplySuffix applySuffix) {
        // Hopefully applySuffix.Lhs was resolved - otherwise, the
        // Contract will fail...
        var lhsResolved = applySuffix.Lhs.Resolved;

        // The invariant Args isn't null? A lie.
        // FilledInDuringResolution? A lie.
        var args = applySuffix.Bindings.ArgumentBindings.
          Select(b => b.Actual.Resolved);

        return StringListToString([
          // TODO Find out whether this is essentially always
          //   something like "MethodCallExpr"
          "ApplySuffix",
          ExpressionToString(lhsResolved),
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
        } else if (value is null) {
          valueAsString = StringListToString(["Null"]);
        } else if (value is BigInteger bigInteger) {
          valueAsString = StringListToString([
            "BigInteger",
            bigInteger.ToString()
          ]);
        } else {
          throw UnsupportedError(literalExpr);
        }

        return StringListToString([
          "LiteralExpr",
          valueAsString
        ]);
      } else if (expression is MemberSelectExpr memberSelectExpr) {
        var obj = memberSelectExpr.Obj;
        var memberName = memberSelectExpr.MemberName;

        return StringListToString([
          "MemberSelectExpr",
          ExpressionToString(obj),
          EscapeAndQuote(memberName)
        ]);

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
        _ => throw UnsupportedError(rop)
      };

    public static string AssignmentRhsToString(AssignmentRhs assignmentRhs) {
      if (assignmentRhs is ExprRhs exprRhs) {
        var expr = exprRhs.Expr;

        return StringListToString([
          "ExprRhs",
          ExpressionToString(expr)
        ]);
      } else {
        throw UnsupportedError(assignmentRhs);
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