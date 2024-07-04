using System;
using Dafny;

namespace Microsoft.Dafny.Compilers {
  class SExpressionCodeGenerator : DafnyWrittenCodeGenerator {
    public DafnyOptions Options { get; set; }

    public SExpressionCodeGenerator(DafnyOptions options) {
      this.Options = options;
    }

    public override ISequence<Rune> Compile(Sequence<DAST.Module> program) {
      throw new NotImplementedException();
    }

    public override ISequence<Rune> EmitCallToMain(string fullName) {
      throw new NotImplementedException();
    }
  }
}