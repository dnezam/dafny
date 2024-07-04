using System.Linq;
using Dafny;

namespace Microsoft.Dafny.Compilers {
  class SExpressionCodeGenerator : DafnyWrittenCodeGenerator {
    public DafnyOptions Options { get; set; }

    public SExpressionCodeGenerator(DafnyOptions options) {
      this.Options = options;
    }

    public override ISequence<Rune> Compile(Sequence<DAST.Module> program) {
      return DafnyToSExpressionCompiler.__default.Compile(program);
    }

    public override ISequence<Rune> EmitCallToMain(string fullName) {
      // next two lines taken verbatim from RustCodeGenerator.cs
      var splitByDot = fullName.Split('.');
      var convertedToUnicode = Sequence<Sequence<Rune>>.FromArray(splitByDot.Select(s => (Sequence<Rune>)Sequence<Rune>.UnicodeFromString(s)).ToArray());
      return DafnyToSExpressionCompiler.__default.EmitCallToMain(convertedToUnicode);
    }
  }
}