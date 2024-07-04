include "../Dafny/AST.dfy"

module {:extern} DafnyToSExpressionCompiler {
    import opened DAST

    method Compile(p: seq<Module>) returns (s: string) {
        s := "Hello from Compile!";
    }

    method EmitCallToMain(fullName: seq<Name>) returns (s: string) {
        s := "";
    }
}