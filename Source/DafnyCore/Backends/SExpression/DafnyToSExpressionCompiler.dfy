include "../Dafny/AST.dfy"

module {:extern} DafnyToSExpressionCompiler {
  import Std
  import Std.Wrappers
  import DAST

  // Same as in ResolvedDesugaredExecutableDafnyPlugin
  method EmitCallToMain(fullName: seq<DAST.Name>) returns (s: string) {
    s := "";
  }

  method Compile(p: seq<DAST.Module>) returns (s: string) {
    s := StringSeqToSexpr(["Program", MapJoin(ModuleToSexpr, p)]);
  }

  function ModuleToSexpr(mod: DAST.Module): string
    decreases mod, 1
  {
    StringSeqToSexpr(["Module.Module",
                        NameToSexpr(mod.name),
                        MapJoin(AttributeToSexpr, mod.attributes),
                        OptionToSexpr(mod.body, x => MapJoin(i => ModuleItemToSexpr(mod, i), x))])
  }

  function NameToSexpr(name: DAST.Name): string {
    StringSeqToSexpr(["Name.Name", name.dafny_name])
  }

  function AttributeToSexpr(attribute: DAST.Attribute): string {
    StringSeqToSexpr(["Attribute.Attribute", attribute.name, StringSeqToSexpr(attribute.args)])
  }

  function ModuleItemToSexpr(ghost parent: DAST.Module, modItem: DAST.ModuleItem): string
    decreases parent, 0
  {
    match modItem
    case Module(mod) =>
      // TODO: Move this as a precondition and prove it at call sites
      assume {:axiom} mod < parent;
      StringSeqToSexpr(["ModuleItem.Module", ModuleToSexpr(mod)])
    case Class(cls) => StringSeqToSexpr(["ModuleItem.Class", ClassToSexpr(cls)]) 
    case Trait(trt) => StringSeqToSexpr(["ModuleItem.Trait", TraitToSexpr(trt)])
    case Newtype(nt) => StringSeqToSexpr(["ModuleItem.Newtype", NewtypeToSexpr(nt)])
    case Datatype(dt) => StringSeqToSexpr(["ModuleItem.Datatype", DatatypeToSexpr(dt)])
  }

  function ClassToSexpr(cls: DAST.Class): string {
    StringSeqToSexpr(["Class.Class",
                        NameToSexpr(cls.name),
                        IdentToSexpr(cls.enclosingModule),
                        MapJoin(TypeArgDeclToSexpr, cls.typeParams),
                        MapJoin(TypeToSexpr, cls.superClasses),
                        MapJoin(FieldToSexpr, cls.fields),
                        MapJoin(ClassItemToSexpr, cls.body),
                        MapJoin(AttributeToSexpr, cls.attributes)])
  }

  function TraitToSexpr(trt: DAST.Trait): string {
    StringSeqToSexpr(["Trait.Trait",
                        NameToSexpr(trt.name),
                        MapJoin(TypeArgDeclToSexpr, trt.typeParams),
                        MapJoin(ClassItemToSexpr, trt.body),
                        MapJoin(AttributeToSexpr, trt.attributes)])
  }

  function NewtypeToSexpr(nt: DAST.Newtype): string {
    StringSeqToSexpr(["Newtype.Newtype",
                        NameToSexpr(nt.name),
                        MapJoin(TypeArgDeclToSexpr, nt.typeParams),
                        TypeToSexpr(nt.base),
                        NewtypeRangeToSexpr(nt.range),
                        MapJoin(StatementToSexpr, nt.witnessStmts),
                        OptionToSexpr(nt.witnessExpr, ExpressionToSexpr),
                        MapJoin(AttributeToSexpr, nt.attributes)])
  }

  function DatatypeToSexpr(dt: DAST.Datatype): string {
    StringSeqToSexpr(["Datatype.Datatype",
                        NameToSexpr(dt.name),
                        IdentToSexpr(dt.enclosingModule),
                        MapJoin(TypeArgDeclToSexpr, dt.typeParams),
                        MapJoin(DatatypeCtorToSexpr, dt.ctors),
                        MapJoin(ClassItemToSexpr, dt.body),
                        Std.Strings.OfBool(dt.isCo),
                        MapJoin(AttributeToSexpr, dt.attributes)])
  }

  function IdentToSexpr(ident: DAST.Ident): string {
    StringSeqToSexpr(["Ident.Ident",
                        NameToSexpr(ident.id)])
  }

  function TypeArgDeclToSexpr(typeArgDecl: DAST.TypeArgDecl): string {
    StringSeqToSexpr(["TypeArgDecl.TypeArgDecl",
                        IdentToSexpr(typeArgDecl.name),
                        MapJoin(TypeArgBoundToSexpr, typeArgDecl.bounds)])
  }

  function TypeToSexpr(t: DAST.Type): string
    decreases t
  {
    match t
    case Path(ids, typeArgs, resolved) =>
      StringSeqToSexpr(["Type.Path",
                          MapJoin(IdentToSexpr, ids),
                          MapJoin((x) requires x in typeArgs => (TypeToSexpr(x)),
                                  typeArgs),
                          ResolvedTypeToSexpr(resolved)])
    case Nullable(t') => "Type.Nullable: TODO"
    case Tuple(ts) => "Type.Tuple: TODO"
    case Array(element, dims) => "Type. Array: TODO"
    case Seq(element) =>
      StringSeqToSexpr(["Type.Seq", TypeToSexpr(element)])
    case Set(element) => "Type.Set: TODO"
    case Multiset(element) => "Type.Multiset: TODO"
    case Map(key, value) => "Type.Map: TODO"
    case SetBuilder(element) => "Type.SetBuilder: TODO"
    case MapBuilder(key, value) => "Type.MapBuilder: TODO"
    case Arrow(args, result) => "Type.Arrow: TODO"
    case Primitive(primitive) => "Type.Primitive: TODO"
    case Passthrough(str) => "Type.Passthrough: TODO"
    case TypeArg(id) => "Type.TypeArg: TODO"
  }

  function FieldToSexpr(field: DAST.Field): string {
    "FieldToSexpr: TODO"
  }

  function ClassItemToSexpr(classItem: DAST.ClassItem): string {
    "ClassItemToSexpr: TODO"
  }

  function NewtypeRangeToSexpr(range: DAST.NewtypeRange): string {
    "NewtypeRangeToSexpr: TODO"
  }

  function ExpressionToSexpr(expr: DAST.Expression): string {
    "ExpressionToSexpr: TODO"
  }

  function StatementToSexpr(stmt: DAST.Statement): string {
    "StatementToSexpr: TODO"
  }

  function DatatypeCtorToSexpr(datatypeCtor: DAST.DatatypeCtor): string {
    "DatatypeCtorToSexpr: TODO"
  }

  function TypeArgBoundToSexpr(typeArgBound: DAST.TypeArgBound): string {
    "TypeArgBoundToSexpr: TODO"
  }

  function ResolvedTypeToSexpr(resolvedType: DAST.ResolvedType): string {
    match resolvedType
    case Datatype(datatypeType) => "ResolvedType.Datatype: TODO"
    case Trait(path, attributes) => "ResolvedType.Trait: TODO"
    case Newtype(baseType, range, erase, attributes) =>
      var mutual_test := TypeToSexpr(baseType);
    "ResolvedType.Newtype: TODO"
  }

  function OptionToSexpr<T>(opt: Std.Wrappers.Option<T>, convert: (T -> string)): string {
    match opt
    case None => "(None)"
    case Some(value) => StringSeqToSexpr(["Some", convert(value)])
  }

  function MapJoin<T>(f: (T ~> string), xs: seq<T>): string
    requires forall i :: 0 <= i < |xs| ==> f.requires(xs[i])
    reads set i, o | 0 <= i < |xs| && o in f.reads(xs[i]) :: o
  {
    "(" + Std.Collections.Seq.Join(Std.Collections.Seq.Map(f, xs), " ") + ")"
  }

  // Note that xs is a sequence of strings in Dafny, not DAST.
  function StringSeqToSexpr(xs: seq<string>): string {
    MapJoin(x => x, xs)
  }

}