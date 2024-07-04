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

    public override ISequence<Rune> EmitCallToMain(string fullName) {
      // next two lines taken verbatim from RustCodeGenerator.cs
      var splitByDot = fullName.Split('.');
      var convertedToUnicode = Sequence<Sequence<Rune>>.FromArray(splitByDot.Select(s => (Sequence<Rune>)Sequence<Rune>.UnicodeFromString(s)).ToArray());
      return DafnyToSExpressionCompiler.__default.EmitCallToMain(convertedToUnicode);
    }
  }
}