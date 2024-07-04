include "../Dafny/AST.dfy"


module DafnyToSExpressionCompiler {
    import DAST

    method Compile(p: seq<DAST.Module>) returns (s: string) {
        s := "Hello from Compile!";
    }

    method EmitCallToMain(fullName: seq<DAST.Name>) returns (s: string) {
        s := "Hello from EmitCallToMain!";
    }
}