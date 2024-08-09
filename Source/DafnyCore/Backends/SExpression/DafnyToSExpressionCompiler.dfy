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

  // TODO Figure out correct way of when to escape strings (and what)
  //  in particular strings and chars.

  function ModuleToSexpr(mod: DAST.Module): string
    decreases mod, 1
  {
    match mod
    case Module(name, attributes, body) =>
      StringSeqToSexpr(["Module.Module",
                        NameToSexpr(name),
                        MapJoin(AttributeToSexpr, attributes),
                        OptionToSexpr(body, x => MapJoin(i => ModuleItemToSexpr(mod, i), x))])
  }

  function NameToSexpr(name: DAST.Name): string {
    match name
    case Name(dafny_name) =>
      StringSeqToSexpr(["Name.Name",
                        EscapeAndQuote(dafny_name)])
  }

  function AttributeToSexpr(attribute: DAST.Attribute): string {
    match attribute
    case Attribute(name, args) =>
      StringSeqToSexpr(["Attribute.Attribute",
                        EscapeAndQuote(name),
                        MapJoin(EscapeAndQuote, args)])
  }

  function ModuleItemToSexpr(ghost parent: DAST.Module, modItem: DAST.ModuleItem): string
    decreases parent, 0
  {
    match modItem
    case Module(mod) =>
      // TODO: Try to get rid of this axiom
      // https://leino.science/papers/krml283.html
      assume {:axiom} mod < parent;
      StringSeqToSexpr(["ModuleItem.Module", ModuleToSexpr(mod)])
    case Class(cls) => StringSeqToSexpr(["ModuleItem.Class", ClassToSexpr(cls)])
    case Trait(trt) => StringSeqToSexpr(["ModuleItem.Trait", TraitToSexpr(trt)])
    case Newtype(nt) => StringSeqToSexpr(["ModuleItem.Newtype", NewtypeToSexpr(nt)])
    case Datatype(dt) => StringSeqToSexpr(["ModuleItem.Datatype", DatatypeToSexpr(dt)])
  }

  function ClassToSexpr(cls: DAST.Class): string {
    match cls
    case Class(name, enclosingModule, typeParams, superClasses, fields, body, attributes) =>
      StringSeqToSexpr(["Class.Class",
                        NameToSexpr(name),
                        IdentToSexpr(enclosingModule),
                        MapJoin(TypeArgDeclToSexpr, typeParams),
                        MapJoin(TypeToSexpr, superClasses),
                        MapJoin(FieldToSexpr, fields),
                        MapJoin(ClassItemToSexpr, body),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function TraitToSexpr(trt: DAST.Trait): string {
    match trt
    case Trait(name, typeParams, body, attributes) =>
      StringSeqToSexpr(["Trait.Trait",
                        NameToSexpr(name),
                        MapJoin(TypeArgDeclToSexpr, typeParams),
                        MapJoin(ClassItemToSexpr, body),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function NewtypeToSexpr(nt: DAST.Newtype): string {
    match nt
    case Newtype(name, typeParams, base, range, witnessStmts, witnessExpr, attributes) =>
      StringSeqToSexpr(["Newtype.Newtype",
                        NameToSexpr(name),
                        MapJoin(TypeArgDeclToSexpr, typeParams),
                        TypeToSexpr(base),
                        NewtypeRangeToSexpr(range),
                        MapJoin(StatementToSexpr, witnessStmts),
                        OptionToSexpr(witnessExpr, ExpressionToSexpr),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function DatatypeToSexpr(dt: DAST.Datatype): string {
    match dt
    case Datatype(name, enclosingModule, typeParams, ctors, body, isCo, attributes) =>
      StringSeqToSexpr(["Datatype.Datatype",
                        NameToSexpr(name),
                        IdentToSexpr(enclosingModule),
                        MapJoin(TypeArgDeclToSexpr, typeParams),
                        MapJoin(DatatypeCtorToSexpr, ctors),
                        MapJoin(ClassItemToSexpr, body),
                        Std.Strings.OfBool(isCo),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function IdentToSexpr(ident: DAST.Ident): string {
    match ident
    case Ident(id) =>
      StringSeqToSexpr(["Ident.Ident",
                        NameToSexpr(id)])
  }

  function TypeArgDeclToSexpr(typeArgDecl: DAST.TypeArgDecl): string {
    match typeArgDecl
    case TypeArgDecl(name, bounds) =>
      StringSeqToSexpr(["TypeArgDecl.TypeArgDecl",
                        IdentToSexpr(name),
                        MapJoin(TypeArgBoundToSexpr, bounds)])
  }

  function TypeToSexpr(t: DAST.Type): string {
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
                        EscapeAndQuote(str)])
    case TypeArg(id) =>
      StringSeqToSexpr(["Type.TypeArg",
                        IdentToSexpr(id)])
  }

  // eta-expansion required; cannot be made generic
  function MapJoinTypeToSexpr(ts: seq<DAST.Type>): string {
    // need precondition to prove termination in TypeToSexpr
    MapJoin((x) requires x in ts => (TypeToSexpr(x)), ts)
  }

  function FieldToSexpr(field: DAST.Field): string {
    match field
    case Field(formal, defaultValue) =>
      StringSeqToSexpr(["Field.Field",
                        FormalToSexpr(formal),
                        OptionToSexpr(defaultValue, ExpressionToSexpr)])
  }

  function ClassItemToSexpr(classItem: DAST.ClassItem): string {
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

  function ExpressionToSexpr(expr: DAST.Expression): string {
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
                                                  EscapeAndQuote,
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
    case UnOp(unOp, expr', _) =>  // Ignore formatting
      StringSeqToSexpr(["Expression.UnOp",
                        UnaryOpToSexpr(unOp),
                        ExpressionToSexpr(expr')])
    case BinOp(op, left, right, _) =>  // Ignore formatting
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
  function MapJoinExpressionToSexpr(ts: seq<DAST.Expression>): string {
    MapJoin((x) requires x in ts => (ExpressionToSexpr(x)), ts)
  }

  function StatementToSexpr(stmt: DAST.Statement): string {
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
    case If(cond, thn, els)  =>
      StringSeqToSexpr(["Statement.If",
                        ExpressionToSexpr(cond),
                        MapJoinStatementToSexpr(thn),
                        MapJoinStatementToSexpr(els)])
    case Labeled(lbl, body)  =>
      StringSeqToSexpr(["Statement.Labeled",
                        EscapeAndQuote(lbl),
                        MapJoinStatementToSexpr(body)])
    case While(cond, body)  =>
      StringSeqToSexpr(["Statement.While",
                        ExpressionToSexpr(cond),
                        MapJoinStatementToSexpr(body)])
    case Foreach(boundName, boundType, over, body) =>
      StringSeqToSexpr(["Statement.Foreach",
                        NameToSexpr(boundName),
                        TypeToSexpr(boundType),
                        ExpressionToSexpr(over),
                        MapJoinStatementToSexpr(body)])
    case Call(on, callName, typeArgs, args, outs) =>
      StringSeqToSexpr(["Statement.Call",
                        ExpressionToSexpr(on),
                        CallNameToSexpr(callName),
                        MapJoin(TypeToSexpr, typeArgs),
                        MapJoinExpressionToSexpr(args),
                        OptionToSexpr(outs, x => MapJoin(IdentToSexpr, x))])
    case Return(expr) =>
      StringSeqToSexpr(["Statement.Return",
                        ExpressionToSexpr(expr)])
    case EarlyReturn() =>
      StringSeqToSexpr(["Statement.EarlyReturn"])
    case Break(toLabel) =>
      StringSeqToSexpr(["Statement.Break",
                        OptionToSexpr(toLabel, EscapeAndQuote)])
    case TailRecursive(body) =>
      StringSeqToSexpr(["Statement.TailRecursive",
                        MapJoinStatementToSexpr(body)])
    case JumpTailCallStart() =>
      StringSeqToSexpr(["Statement.JumpTailCallStart"])
    case Halt() =>
      StringSeqToSexpr(["Statement.Halt"])
    case Print(expr) =>
      StringSeqToSexpr(["Statement.Print",
                        ExpressionToSexpr(expr)])
  }

  // analogous to TypeToSexpr case
  function MapJoinStatementToSexpr(ts: seq<DAST.Statement>): string {
    MapJoin((x) requires x in ts => (StatementToSexpr(x)), ts)
  }

  function DatatypeCtorToSexpr(datatypeCtor: DAST.DatatypeCtor): string {
    match datatypeCtor
    case DatatypeCtor(name, args, hasAnyArgs) =>
      StringSeqToSexpr(["DatatypeCtor.DatatypeCtor",
                        NameToSexpr(name),
                        MapJoin(DatatypeDtorToSexpr, args),
                        Std.Strings.OfBool(hasAnyArgs)])
  }

  function TypeArgBoundToSexpr(typeArgBound: DAST.TypeArgBound): string {
    match typeArgBound
    case SupportsEquality =>
      StringSeqToSexpr(["TypeArgBound.SupportsEquality"])
    case SupportsDefault =>
      StringSeqToSexpr(["TypeArgBound.SupportsDefault"])
  }

  function FormalToSexpr(formal: DAST.Formal): string {
    match formal
    case Formal(name, typ, attributes) =>
      StringSeqToSexpr(["Formal.Formal",
                        NameToSexpr(name),
                        TypeToSexpr(typ),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function ResolvedTypeToSexpr(resolvedType: DAST.ResolvedType): string {
    match resolvedType
    case Datatype(datatypeType) =>
      StringSeqToSexpr(["ResolvedType.Datatype",
                        DatatypeTypeToSexpr(datatypeType)])
    case Trait(path, attributes) =>
      StringSeqToSexpr(["ResolvedType.Trait",
                        MapJoin(IdentToSexpr, path),
                        MapJoin(AttributeToSexpr, attributes)])
    case Newtype(baseType, range, erase, attributes) =>
      StringSeqToSexpr(["ResolvedType.Newtype",
                        TypeToSexpr(baseType),
                        NewtypeRangeToSexpr(range),
                        Std.Strings.OfBool(erase),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function PrimitiveToSexpr(primitive: DAST.Primitive): string {
    match primitive
    case Int => StringSeqToSexpr(["Primitive.Int"])
    case Real => StringSeqToSexpr(["Primitive.Real"])
    case String => StringSeqToSexpr(["Primitive.String"])
    case Bool => StringSeqToSexpr(["Primitive.Bool"])
    case Char => StringSeqToSexpr(["Primitive.Char"])
  }

  function MethodToSexpr(m: DAST.Method): string {
    match m
    case Method(isStatic, hasBody, overridingPath, name, typeParams, params, body, outTypes, outVars) =>
      StringSeqToSexpr(["Method.Method",
                        Std.Strings.OfBool(isStatic),
                        Std.Strings.OfBool(hasBody),
                        OptionToSexpr(overridingPath,
                                      x => MapJoin(IdentToSexpr, x)),
                        NameToSexpr(name),
                        MapJoin(TypeArgDeclToSexpr, typeParams),
                        MapJoin(FormalToSexpr, params),
                        MapJoin(StatementToSexpr, body),
                        MapJoin(TypeToSexpr, outTypes),
                        OptionToSexpr(outVars,
                                      x => MapJoin(IdentToSexpr, x))])
  }

  function LiteralToSexpr(literal: DAST.Literal): string {
    match literal
    case BoolLiteral(b) =>
      StringSeqToSexpr(["Literal.BoolLiteral",
                        Std.Strings.OfBool(b)])
    case IntLiteral(str, t) =>
      StringSeqToSexpr(["Literal.IntLiteral",
                        EscapeAndQuote(str),
                        TypeToSexpr(t)])
    case DecLiteral(str1, str2, t) =>
      StringSeqToSexpr(["Literal.DecLiteral",
                        EscapeAndQuote(str1),
                        EscapeAndQuote(str2),
                        TypeToSexpr(t)])
    case StringLiteral(str, verbatim) =>
      StringSeqToSexpr(["Literal.StringLiteral",
                        EscapeAndQuote(str),
                        Std.Strings.OfBool(verbatim)])
    case CharLiteral(c) =>
      StringSeqToSexpr(["Literal.CharLiteral",
                        EscapeAndQuote(Std.Strings.OfChar(c))])
    case CharLiteralUTF16(n) =>
      StringSeqToSexpr(["Literal.CharLiteralUTF16",
                        Std.Strings.OfNat(n)])
    case Null(t) =>
      StringSeqToSexpr(["Literal.Null",
                        TypeToSexpr(t)])
  }

  function DatatypeTypeToSexpr(datatypeType: DAST.DatatypeType): string {
    match datatypeType
    case DatatypeType(path, attributes) =>
      StringSeqToSexpr(["DatatypeType.DatatypeType",
                        MapJoin(IdentToSexpr, path),
                        MapJoin(AttributeToSexpr, attributes)])
  }

  function UnaryOpToSexpr(unOp: DAST.UnaryOp): string {
    match unOp
    case Not => StringSeqToSexpr(["UnaryOp.Not"])
    case BitwiseNot => StringSeqToSexpr(["UnaryOp.BitwiseNot"])
    case Cardinality => StringSeqToSexpr(["UnaryOp.Cardinality"])
  }

  function BinOpToSexpr(op: DAST.BinOp): string {
    match op
    case Eq(referential, nullable) =>
      StringSeqToSexpr(["BinOp.Eq",
                        Std.Strings.OfBool(referential),
                        Std.Strings.OfBool(nullable)])
    case Div() =>
      StringSeqToSexpr(["BinOp.Div"])
    case EuclidianDiv() =>
      StringSeqToSexpr(["BinOp.EuclidianDiv"])
    case Mod() =>
      StringSeqToSexpr(["BinOp.Mod"])
    case EuclidianMod() =>
      StringSeqToSexpr(["BinOp.EuclidianMod"])
    case Lt() =>
      StringSeqToSexpr(["BinOp.Lt"])
    case LtChar() =>
      StringSeqToSexpr(["BinOp.LtChar"])
    case Plus() =>
      StringSeqToSexpr(["BinOp.Plus"])
    case Minus() =>
      StringSeqToSexpr(["BinOp.Minus"])
    case Times() =>
      StringSeqToSexpr(["BinOp.Times"])
    case BitwiseAnd() =>
      StringSeqToSexpr(["BinOp.BitwiseAnd"])
    case BitwiseOr() =>
      StringSeqToSexpr(["BinOp.BitwiseOr"])
    case BitwiseXor() =>
      StringSeqToSexpr(["BinOp.BitwiseXor"])
    case BitwiseShiftRight() =>
      StringSeqToSexpr(["BinOp.BitwiseShiftRight"])
    case BitwiseShiftLeft() =>
      StringSeqToSexpr(["BinOp.BitwiseShiftLeft"])
    case And() =>
      StringSeqToSexpr(["BinOp.And"])
    case Or() =>
      StringSeqToSexpr(["BinOp.Or"])
    case In() =>
      StringSeqToSexpr(["BinOp.In"])
    case SeqProperPrefix() =>
      StringSeqToSexpr(["BinOp.SeqProperPrefix"])
    case SeqPrefix() =>
      StringSeqToSexpr(["BinOp.SeqPrefix"])
    case SetMerge() =>
      StringSeqToSexpr(["BinOp.SetMerge"])
    case SetSubtraction() =>
      StringSeqToSexpr(["BinOp.SetSubtraction"])
    case SetIntersection() =>
      StringSeqToSexpr(["BinOp.SetIntersection"])
    case Subset() =>
      StringSeqToSexpr(["BinOp.Subset"])
    case ProperSubset() =>
      StringSeqToSexpr(["BinOp.ProperSubset"])
    case SetDisjoint() =>
      StringSeqToSexpr(["BinOp.SetDisjoint"])
    case MapMerge() =>
      StringSeqToSexpr(["BinOp.MapMerge"])
    case MapSubtraction() =>
      StringSeqToSexpr(["BinOp.MapSubtraction"])
    case MultisetMerge() =>
      StringSeqToSexpr(["BinOp.MultisetMerge"])
    case MultisetSubtraction() =>
      StringSeqToSexpr(["BinOp.MultisetSubtraction"])
    case MultisetIntersection() =>
      StringSeqToSexpr(["BinOp.MultisetIntersection"])
    case Submultiset() =>
      StringSeqToSexpr(["BinOp.Submultiset"])
    case ProperSubmultiset() =>
      StringSeqToSexpr(["BinOp.ProperSubmultiset"])
    case MultisetDisjoint() =>
      StringSeqToSexpr(["BinOp.MultisetDisjoint"])
    case Concat() =>
      StringSeqToSexpr(["BinOp.Concat"])
    case Passthrough(str) =>
      StringSeqToSexpr(["BinOp.Passthrough",
                        EscapeAndQuote(str)])
  }

  function CollKindToSexpr(collKind: DAST.CollKind): string {
    match collKind
    case Seq => StringSeqToSexpr(["CollKind.Seq"])
    case Array => StringSeqToSexpr(["CollKind.Array"])
    case Map => StringSeqToSexpr(["CollKind.Map"])
  }

  function CallNameToSexpr(callName: DAST.CallName): string {
    match callName
    case CallName(name, onType, signature) =>
      StringSeqToSexpr(["CallName.CallName",
                        NameToSexpr(name),
                        OptionToSexpr(onType, TypeToSexpr),
                        CallSignatureToSexpr(signature)])
    case MapBuilderAdd => StringSeqToSexpr(["CallName.MapBuilderAdd"])
    case MapBuilderBuild => StringSeqToSexpr(["CallName.MapBuilderBuild"])
    case SetBuilderAdd => StringSeqToSexpr(["CallName.SetBuilderAdd"])
    case SetBuilderBuild => StringSeqToSexpr(["CallName.SetBuilderBuild"])
  }

  function AssignLhsToSexpr(lhs: DAST.AssignLhs): string {
    match lhs
    case Ident(ident) =>
      StringSeqToSexpr(["AssignLhs.Ident",
                        IdentToSexpr(ident)])
    case Select(expr, field) =>
      StringSeqToSexpr(["AssignLhs.Select",
                        ExpressionToSexpr(expr),
                        NameToSexpr(field)])
    case Index(expr, indices) =>
      StringSeqToSexpr(["AssignLhs.Index",
                        ExpressionToSexpr(expr),
                        MapJoinExpressionToSexpr(indices)])
  }

  function DatatypeDtorToSexpr(datatypeDtor: DAST.DatatypeDtor): string {
    match datatypeDtor
    case DatatypeDtor(formal, callName) =>
      StringSeqToSexpr(["DatatypeDtor.DatatypeDtor",
                        FormalToSexpr(formal),
                        OptionToSexpr(callName, EscapeAndQuote)])
  }

  function CallSignatureToSexpr(signature: DAST.CallSignature): string {
    match signature
    case CallSignature(parameters) =>
      StringSeqToSexpr(["CallSignature.CallSignature",
                        MapJoin(FormalToSexpr, parameters)])
  }

  function EscapeAndQuote(str: string): string {
    "\"" + Std.Strings.CharStrEscaping.Escape(str, {'\"', '\\'}, '\\') + "\""
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