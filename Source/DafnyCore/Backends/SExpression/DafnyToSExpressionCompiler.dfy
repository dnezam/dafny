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
    case Convert(value, from, typ) =>
      StringSeqToSexpr(["Expression.Convert",
                        ExpressionToSexpr(value),
                        TypeToSexpr(from),
                        TypeToSexpr(typ)])
    case SeqConstruct(length, elem) =>
      StringSeqToSexpr(["Expression.SeqConstruct",
                        ExpressionToSexpr(length),
                        ExpressionToSexpr(elem)])
    case SeqValue(elements, typ) =>
      StringSeqToSexpr(["Expression.SeqValue",
                        MapJoinExpressionToSexpr(elements),
                        TypeToSexpr(typ)])
    case SetValue(elements) =>
      StringSeqToSexpr(["Expression.SetValue",
                        MapJoinExpressionToSexpr(elements)])
    case MultisetValue(elements) =>
      StringSeqToSexpr(["Expression.MultisetValue",
                        MapJoinExpressionToSexpr(elements)])
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
    case MapBuilder(keyType, valueType) =>
      StringSeqToSexpr(["Expression.MapBuilder",
                        TypeToSexpr(keyType),
                        TypeToSexpr(valueType)])
    case SeqUpdate(expr', indexExpr, value) =>
      StringSeqToSexpr(["Expression.SeqUpdate",
                        ExpressionToSexpr(expr'),
                        ExpressionToSexpr(indexExpr),
                        ExpressionToSexpr(value)])
    case MapUpdate(expr', indexExpr, value) =>
      StringSeqToSexpr(["Expression.MapUpdate",
                        ExpressionToSexpr(expr'),
                        ExpressionToSexpr(indexExpr),
                        ExpressionToSexpr(value)])
    case SetBuilder(elemType) =>
      StringSeqToSexpr(["Expression.SetBuilder",
                        TypeToSexpr(elemType)])
    case ToMultiset(expr') =>
      StringSeqToSexpr(["Expression.ToMultiset",
                        ExpressionToSexpr(expr')])
    case This() =>
      StringSeqToSexpr(["Expression.This"])
    case Ite(cond, thn, els) =>
      StringSeqToSexpr(["Expression.Ite",
                        ExpressionToSexpr(cond),
                        ExpressionToSexpr(thn),
                        ExpressionToSexpr(els)])
    // Ignore formatting
    case UnOp(unOp, expr', _) =>
      StringSeqToSexpr(["Expression.UnOp",
                        UnaryOpToSexpr(unOp),
                        ExpressionToSexpr(expr')])
    // Ignore formatting
    case BinOp(op, left, right, _) =>
      StringSeqToSexpr(["Expression.BinOp",
                        BinOpToSexpr(op),
                        ExpressionToSexpr(left),
                        ExpressionToSexpr(right)])
    case ArrayLen(expr', dim) =>
      StringSeqToSexpr(["Expression.ArrayLen",
                        ExpressionToSexpr(expr'),
                        Std.Strings.OfNat(dim)])
    case MapKeys(expr') =>
      StringSeqToSexpr(["Expression.MapKeys",
                        ExpressionToSexpr(expr')])
    case MapValues(expr') =>
      StringSeqToSexpr(["Expression.MapValues",
                        ExpressionToSexpr(expr')])
    case Select(expr', field, isConstant, onDatatype, fieldType) =>
      StringSeqToSexpr(["Expression.Select",
                        ExpressionToSexpr(expr'),
                        NameToSexpr(field),
                        Std.Strings.OfBool(isConstant),
                        Std.Strings.OfBool(onDatatype),
                        TypeToSexpr(fieldType)])
    case SelectFn(expr', field, onDatatype, isStatic, arity) =>
      StringSeqToSexpr(["Expression.SelectFn",
                        ExpressionToSexpr(expr'),
                        NameToSexpr(field),
                        Std.Strings.OfBool(onDatatype),
                        Std.Strings.OfBool(isStatic),
                        Std.Strings.OfNat(arity)])
    case Index(expr', collKind, indices) =>
      StringSeqToSexpr(["Expression.Index",
                        ExpressionToSexpr(expr'),
                        CollKindToSexpr(collKind),
                        MapJoinExpressionToSexpr(indices)])
    case IndexRange(expr', isArray, low, high) =>
      StringSeqToSexpr(["Expression.IndexRange",
                        ExpressionToSexpr(expr'),
                        Std.Strings.OfBool(isArray),
                        OptionToSexpr(low,
                                      (x) requires x < expr =>
                                        ExpressionToSexpr(x)),
                        OptionToSexpr(high,
                                      (x) requires x < expr =>
                                        ExpressionToSexpr(x))])
    case TupleSelect(expr', index, fieldType) =>
      StringSeqToSexpr(["Expression.TupleSelect",
                        ExpressionToSexpr(expr'),
                        Std.Strings.OfNat(index),
                        TypeToSexpr(fieldType)])
    case Call(on, callName, typeArgs, args) =>
      StringSeqToSexpr(["Expression.Call",
                        ExpressionToSexpr(on),
                        CallNameToSexpr(callName),
                        MapJoin(TypeToSexpr, typeArgs),
                        MapJoinExpressionToSexpr(args)])
    case Lambda(params, retType, body) =>
      StringSeqToSexpr(["Expression.Lambda",
                        MapJoin(FormalToSexpr, params),
                        TypeToSexpr(retType),
                        MapJoinStatementToSexpr(body)])
    case BetaRedex(values, retType, expr') =>
      StringSeqToSexpr(["Expression.BetaRedex",
                        assert forall x :: x in values ==> x.1 < expr;
                        MapJoin(x requires x in values =>
                                  TwoTupleToSexpr(x,
                                                  FormalToSexpr,
                                                  (z) requires z < expr =>
                                                    ExpressionToSexpr(z)),
                                values),
                        TypeToSexpr(retType),
                        ExpressionToSexpr(expr')])
    case IIFE(name, typ, value, iifeBody) =>
      StringSeqToSexpr(["Expression.IIFE",
                        IdentToSexpr(name),
                        TypeToSexpr(typ),
                        ExpressionToSexpr(value),
                        ExpressionToSexpr(iifeBody)])
    case Apply(expr', args) =>
      StringSeqToSexpr(["Expression.Apply",
                        ExpressionToSexpr(expr'),
                        MapJoinExpressionToSexpr(args)])
    case TypeTest(on, dType, variant) =>
      StringSeqToSexpr(["Expression.TypeTest",
                        ExpressionToSexpr(on),
                        MapJoin(IdentToSexpr, dType),
                        NameToSexpr(variant)])
    case InitializationValue(typ) =>
      StringSeqToSexpr(["Expression.InitializationValue",
                        TypeToSexpr(typ)])
    case BoolBoundedPool() =>
      StringSeqToSexpr(["Expression.BoolBoundedPool"])
    case SetBoundedPool(of) =>
      StringSeqToSexpr(["Expression.SetBoundedPool",
                        ExpressionToSexpr(of)])
    case SeqBoundedPool(of, includeDuplicates) =>
      StringSeqToSexpr(["Expression.SeqBoundedPool",
                        ExpressionToSexpr(of),
                        Std.Strings.OfBool(includeDuplicates)])
    case IntRange(lo, hi) =>
      StringSeqToSexpr(["Expression.IntRange",
                        ExpressionToSexpr(lo),
                        ExpressionToSexpr(hi)])
  }

  // analogous to TypeToSexpr case
  function MapJoinExpressionToSexpr(ts: seq<DAST.Expression>): string
  {
    MapJoin((x) requires x in ts => (ExpressionToSexpr(x)), ts)
  }

  function StatementToSexpr(stmt: DAST.Statement): string
    decreases stmt
  {
    match stmt
    case DeclareVar(name, typ, maybeValue) =>
      StringSeqToSexpr(["Statement.DeclareVar",
                        NameToSexpr(name),
                        TypeToSexpr(typ),
                        OptionToSexpr(maybeValue,
                                      (x) requires maybeValue.Some?
                                          requires maybeValue.Extract() == x =>
                                            ExpressionToSexpr(x))])
    case Assign(lhs, value)  =>
      StringSeqToSexpr(["Statement.Assign",
                        AssignLhsToSexpr(lhs),
                        ExpressionToSexpr(value)])
    case If(cond, thn, els)  => "TODO"
    case Labeled(lbl, body)  => "TODO"
    case While(cond, body)  => "TODO"
    case Foreach(boundName, boundType, over, body) => "TODO"
    case Call(on, callName, typeArgs, args, outs) =>
      StringSeqToSexpr(["Statement.Call",
                        ExpressionToSexpr(on),
                        CallNameToSexpr(callName),
                        MapJoin(TypeToSexpr, typeArgs),
                        MapJoinExpressionToSexpr(args),
                        OptionToSexpr(outs, x => MapJoin(IdentToSexpr, x))])
    case Return(expr) => "TODO"
    case EarlyReturn() => "TODO"
    case Break(toLabel) => "TODO"
    case TailRecursive(body) => "TODO"
    case JumpTailCallStart() => "TODO"
    case Halt() => "TODO"
    case Print(expr) => "TODO"
  }

  // analogous to TypeToSexpr case
  function MapJoinStatementToSexpr(ts: seq<DAST.Statement>): string
  {
    MapJoin((x) requires x in ts => (StatementToSexpr(x)), ts)
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

  function UnaryOpToSexpr(unOp: DAST.UnaryOp): string {
    "UnaryOpToSexpr: TODO"
  }

  function BinOpToSexpr(op: DAST.BinOp): string {
    "BinOpToSexpr: TODO"
  }

  function CollKindToSexpr(collKind: DAST.CollKind): string {
    "CollKindToSexpr: TODO"
  }

  function CallNameToSexpr(callName: DAST.CallName): string {
    "CallNameToSexpr: TODO"
  }

  function AssignLhsToSexpr(lhs: DAST.AssignLhs): string {
    "AssignLhsToSexpr: TODO"
  }

  function OptionToSexpr<T>(opt: Std.Wrappers.Option<T>, f: (T ~> string)): string
    requires opt.Some? ==> f.requires(opt.Extract())
    reads set o | opt.Some? && o in f.reads(opt.Extract()) :: o
  {
    match opt
    case None => "(None)"
    case Some(value) => StringSeqToSexpr(["Some", f(value)])
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