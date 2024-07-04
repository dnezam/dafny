using System.Collections.Generic;

namespace Microsoft.Dafny.Compilers;
public class SExpressionBackend : DafnyExecutableBackend {
  public override string TargetName => "S-expression";
  public override string TargetExtension => "sexpr";
  public override IReadOnlySet<string> SupportedExtensions => new HashSet<string> { ".sexpr" };
  // set to true so we can see it as an option when using `dafny translate`
  public override bool IsStable => true;
  // set to false since we always want to write to disk
  public override bool SupportsInMemoryCompilation => false;
  public override bool TextualTargetIsExecutable => false;

  protected override DafnyWrittenCodeGenerator CreateDafnyWrittenCompiler() {
    return new SExpressionCodeGenerator(Options);
  }
  public SExpressionBackend(DafnyOptions options) : base(options) {
  }

}
