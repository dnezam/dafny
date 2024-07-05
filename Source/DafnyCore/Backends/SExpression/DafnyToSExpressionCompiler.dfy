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
      // TODO: Move this to a precondition and prove it at call sites
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
                        MapJoinTypeToSexpr(typeArgs),
                        ResolvedTypeToSexpr(resolved)])
    case Nullable(t') =>
      StringSeqToSexpr(["Type.Nullable",
                        TypeToSexpr(t')])
    case Tuple(ts) =>
      StringSeqToSexpr(["Type.Tuple",
                        MapJoinTypeToSexpr(ts)])
    case Array(element, dims) =>
      StringSeqToSexpr(["Type.Array",
                        TypeToSexpr(element),
                        Std.Strings.OfNat(dims)])
    case Seq(element) =>
      StringSeqToSexpr(["Type.Seq",
                        TypeToSexpr(element)])
    case Set(element) =>
      StringSeqToSexpr(["Type.Set",
                        TypeToSexpr(element)])
    case Multiset(element) =>
      StringSeqToSexpr(["Type.Multiset",
                        TypeToSexpr(element)])
    case Map(key, value) =>
      StringSeqToSexpr(["Type.Map",
                        TypeToSexpr(key),
                        TypeToSexpr(value)])
    case SetBuilder(element) =>
      StringSeqToSexpr(["Type.SetBuilder",
                        TypeToSexpr(element)])
    case MapBuilder(key, value) =>
      StringSeqToSexpr(["Type.MapBuilder",
                        TypeToSexpr(key),
                        TypeToSexpr(value)])
    case Arrow(args, result) =>
      StringSeqToSexpr(["Type.Arrow",
                        MapJoinTypeToSexpr(args),
                        TypeToSexpr(result)])
    case Primitive(primitive) =>
      StringSeqToSexpr(["Type.Primitive",
                        PrimitiveToSexpr(primitive)])
    case Passthrough(str) =>
      StringSeqToSexpr(["Type.Passthrough",
                        str])
    case TypeArg(id) =>
      StringSeqToSexpr(["Type.TypeArg",
                        IdentToSexpr(id)])
  }

  // eta-expansion required; cannot be made generic
  function MapJoinTypeToSexpr(ts: seq<DAST.Type>): string
  {
    // need precondition to prove termination in TypeToSexpr
    MapJoin((x) requires x in ts => (TypeToSexpr(x)), ts)
  }

  function FieldToSexpr(field: DAST.Field): string {
    StringSeqToSexpr(["Field.Field",
                      FormalToSexpr(field.formal),
                      OptionToSexpr(field.defaultValue, ExpressionToSexpr)])
  }

  function ClassItemToSexpr(classItem: DAST.ClassItem): string {
    // Need to use match here since classItem.m is not defined
    match classItem
    case Method(m) =>
      StringSeqToSexpr(["ClassItem.Method",
                        MethodToSexpr(m)])
  }

  function NewtypeRangeToSexpr(range: DAST.NewtypeRange): string {
    match range
    case U8 => StringSeqToSexpr(["NewtypeRange.U8"])
    case I8 => StringSeqToSexpr(["NewtypeRange.I8"])
    case U16 => StringSeqToSexpr(["NewtypeRange.U16"])
    case I16 => StringSeqToSexpr(["NewtypeRange.I16"])
    case U32 => StringSeqToSexpr(["NewtypeRange.U32"])
    case I32 => StringSeqToSexpr(["NewtypeRange.I32"])
    case U64 => StringSeqToSexpr(["NewtypeRange.U64"])
    case I64 => StringSeqToSexpr(["NewtypeRange.I64"])
    case U128 => StringSeqToSexpr(["NewtypeRange.U128"])
    case I128 => StringSeqToSexpr(["NewtypeRange.I128"])
    case BigInt => StringSeqToSexpr(["NewtypeRange.BigInt"])
    case NoRange => StringSeqToSexpr(["NewtypeRange.NoRange"])
  }

  function ExpressionToSexpr(expr: DAST.Expression): string
    decreases expr
  {
    match expr
    case Literal(literal) =>
      StringSeqToSexpr(["Expression.Literal",
                        LiteralToSexpr(literal)])
    case Ident(name) =>
      StringSeqToSexpr(["Expression.Ident",
                        NameToSexpr(name)])
    case Companion(ids) =>
      StringSeqToSexpr(["Expression.Companion",
                        MapJoin(IdentToSexpr, ids)])
    case Tuple(exprs) =>
      StringSeqToSexpr(["Expression.Tuple",
                        MapJoinExpressionToSexpr(exprs)])
    case New(path, typeArgs, args) =>
      StringSeqToSexpr(["Expression.New",
                        MapJoin(IdentToSexpr, path),
                        MapJoin(TypeToSexpr, typeArgs),
                        MapJoinExpressionToSexpr(args)])
    case NewArray(dims, typ) =>
      StringSeqToSexpr(["Expression.NewArray",
                          MapJoinExpressionToSexpr(dims),
                          TypeToSexpr(typ)])
    case DatatypeValue(datatypeType, typeArgs, variant, isCo, contents) =>
      StringSeqToSexpr(["Expression.DatatypeValue",
                          DatatypeTypeToSexpr(datatypeType),
                          MapJoin(TypeToSexpr, typeArgs),
                          NameToSexpr(variant),
                          Std.Strings.OfBool(isCo),
                          assert forall x :: x in contents ==> x.1 < expr;
                          MapJoin(x requires x in contents =>
                                  TwoTupleToSexpr(x,
                                                  y => y,
                                                  (z) requires z < expr =>
                                                    ExpressionToSexpr(z)),
                                                  contents)])
    case Convert(value, from, typ) => "TODO"
    case SeqConstruct(length, elem) => "TODO"
    case SeqValue(elements, typ) => "TODO"
    case SetValue(elements) => "TODO"
    case MultisetValue(elements) => "TODO"
    case MapValue(mapElems) =>
      StringSeqToSexpr(["Expression.MapValue",
                          assert forall x :: x in mapElems ==> (x.0 < expr && x.1 < expr);
                          MapJoin(x requires x in mapElems =>
                                  TwoTupleToSexpr(x,
                                                  (y) requires y < expr =>
                                                    ExpressionToSexpr(y),
                                                  (z) requires z < expr =>
                                                    ExpressionToSexpr(z)),
                                                  mapElems)])
    case MapBuilder(keyType, valueType) => "TODO"
    case SeqUpdate(expr, indexExpr, value) => "TODO"
    case MapUpdate(expr, indexExpr, value) => "TODO"
    case SetBuilder(elemType) => "TODO"
    case ToMultiset(expr) => "TODO"
    case This() => "TODO"
    case Ite(cond, thn, els) => "TODO"
    case UnOp(unOp, expr, format1) => "TODO"
    case BinOp(op, left, right, format2) => "TODO"
    case ArrayLen(expr, dim) => "TODO"
    case MapKeys(expr) => "TODO"
    case MapValues(expr) => "TODO"
    case Select(expr, field, isConstant, onDatatype, fieldType) => "TODO"
    case SelectFn(expr, field, onDatatype, isStatic, arity) => "TODO"
    case Index(expr, collKind, indices) => "TODO"
    case IndexRange(expr, isArray, low, high) => "TODO"
    case TupleSelect(expr, index, fieldType) => "TODO"
    case Call(on, callName, typeArgs, args) => "TODO"
    case Lambda(params, retType, body) => "TODO"
    case BetaRedex(values, retType, expr) =>
      StringSeqToSexpr(["Expression.BetaRedex",
  assert forall x: (DAST.Formal, DAST.Expression) {:trigger x.1} {:trigger x in values} :: x in values ==> x.1 < expr;
                          MapJoin(x requires x in values =>
                                  TwoTupleToSexpr(x,
                                                  FormalToSexpr,
                                                  (z) requires z < expr =>
                                                    ExpressionToSexpr(z)),
                                                  values)])
    case IIFE(name, typ, value, iifeBody) => "TODO"
    case Apply(expr, args) => "TODO"
    case TypeTest(on, dType, variant) => "TODO"
    case InitializationValue(typ) => "TODO"
    case BoolBoundedPool() => "TODO"
    case SetBoundedPool(of) => "TODO"
    case SeqBoundedPool(of, includeDuplicates) => "TODO"
    case IntRange(lo, hi) => "TODO"
  }

  // analogously to TypeToSexpr case
  function MapJoinExpressionToSexpr(ts: seq<DAST.Expression>): string
  {
    MapJoin((x) requires x in ts => (ExpressionToSexpr(x)), ts)
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

  function FormalToSexpr(formal: DAST.Formal): string {
    "FormalToSexpr: TODO"
  }

  function ResolvedTypeToSexpr(resolvedType: DAST.ResolvedType): string {
    match resolvedType
    case Datatype(datatypeType) => "ResolvedType.Datatype: TODO"
    case Trait(path, attributes) => "ResolvedType.Trait: TODO"
    case Newtype(baseType, range, erase, attributes) =>
      var mutual_test := TypeToSexpr(baseType);
      "ResolvedType.Newtype: TODO"
  }

  function PrimitiveToSexpr(primitive: DAST.Primitive): string {
    "PrimitiveToSexpr: TODO"
  }

  function MethodToSexpr(m: DAST.Method): string {
    "MethodToSexpr: TODO"
  }

  function LiteralToSexpr(literal: DAST.Literal): string {
    "LiteralToSexpr: TODO"
  }

  function DatatypeTypeToSexpr(datatypeType: DAST.DatatypeType): string {
    "DatatypeTypeToSexpr: TODO"
  }

  // Using -> is easier than ~>
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

  function TwoTupleToSexpr<T, U>(tuple: (T, U), Tf: (T ~> string), Uf: (U ~> string)): string
    requires Tf.requires(tuple.0)
    requires Uf.requires(tuple.1)
    reads Tf.reads(tuple.0)
    reads Uf.reads(tuple.1)
  {
    StringSeqToSexpr([Tf(tuple.0), Uf(tuple.1)])
  }

}