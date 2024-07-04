include "../Dafny/AST.dfy"

module {:extern} DafnyToSExpressionCompiler {
  import Std
  import opened Std.Wrappers
  import opened DAST

  // Same as in ResolvedDesugaredExecutableDafnyPlugin
  method EmitCallToMain(fullName: seq<Name>) returns (s: string) {
    s := "";
  }

  method Compile(p: seq<Module>) returns (s: string) {
    s := StringSeqToSexpr(["Program", MapJoin(ModuleToSexpr, p)]);
  }

  function ModuleToSexpr(mod: Module): string {
    StringSeqToSexpr(["Module",
                        NameToSexpr(mod.name),
                        MapJoin(AttributeToSexpr, mod.attributes),
                        OptionToSexpr(mod.body, x => MapJoin(ModuleItemToSexpr, x))])
  }

  function NameToSexpr(name: Name): string {
    StringSeqToSexpr(["Name", name.dafny_name])
  }

  function AttributeToSexpr(attribute: Attribute): string {
    StringSeqToSexpr(["Attribute", attribute.name, StringSeqToSexpr(attribute.args)])
  }

  function OptionToSexpr<T>(opt: Option<T>, convert: (T -> string)): string{
    match opt
    case None => "(None)"
    case Some(value) => StringSeqToSexpr(["Some", convert(value)])
  }

  function ModuleItemToSexpr(modItem: ModuleItem): string {
    match modItem
    case Module(mod) => ModuleToSexpr(mod)
    case Class(cls) => ClassToSexpr(cls) 
    case Trait(trt) => TraitToSexpr(trt)
    case Newtype(nt) => NewtypeToSexpr(nt)
    case Datatype(dt) => DatatypeToSexpr(dt)
  }

  function ClassToSexpr(cls: Class): string {
    "ClassToSexpr: TODO"
  }

  function TraitToSexpr(trt: Trait): string {
    "TraitToSexpr: TODO"
  }

  function NewtypeToSexpr(nt: Newtype): string {
    "NewtypeToSexpr: TODO"
  }

  function DatatypeToSexpr(dt: Datatype): string {
    "DatatypeToSexpr: TODO"
  }


  function MapJoin<T>(f: (T -> string), xs: seq<T>): string {
    "(" + Std.Collections.Seq.Join(Std.Collections.Seq.Map(f, xs), " ") + ")"
  }

  // Note that xs is a sequence of strings in Dafny, not DAST.
  function StringSeqToSexpr(xs: seq<string>): string {
    MapJoin(x => x, xs)
  }

}