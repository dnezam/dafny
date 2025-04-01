using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Dafny.Compilers {
  public class Bake {

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

    public static string FormalToString(Formal formal) {
      throw UnsupportedError(formal);
    }

    public static string BlockStmtToString(BlockStmt blockStmt) {
      var body = blockStmt.Body;

      return StringListToString([
        "BlockStmt",
        ListToString(StatementToString, body)
      ]);
    }

    public static string StatementToString(Statement statement) {
      throw UnsupportedError(statement);
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

      return new ExtractorError(startToken, $"Unsupported {typeName}: {obj}");
    }
  }
}