using System.Linq;
using Dafny;

namespace Microsoft.Dafny.Compilers {
  class SExpressionCodeGenerator : DafnyWrittenCodeGenerator {
    public DafnyOptions Options { get; set; }

    public SExpressionCodeGenerator(DafnyOptions options) {
      this.Options = options;
    }

    public override void Compile(Sequence<DAST.Module> program, Sequence<ISequence<Rune>> _, ConcreteSyntaxTree w) {
      w.Write(DafnyToSExpressionCompiler.__default.Compile(program).ToVerbatimString(false));
    }

    public override ISequence<Rune> EmitCallToMain(DAST.Expression companion, Sequence<Rune> mainMethodName, bool hasArguments) {
      return Sequence<Rune>.Empty;
    }
  }
}