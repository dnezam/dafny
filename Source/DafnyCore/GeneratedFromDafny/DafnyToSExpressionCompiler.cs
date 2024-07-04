// Dafny program the_program compiled into C#
// To recompile, you will need the libraries
//     System.Runtime.Numerics.dll System.Collections.Immutable.dll
// but the 'dotnet' tool in .NET should pick those up automatically.
// Optionally, you may want to include compiler switches like
//     /debug /nowarn:162,164,168,183,219,436,1717,1718

using System;
using System.Numerics;
using System.Collections;
#pragma warning disable CS0164 // This label has not been referenced
#pragma warning disable CS0162 // Unreachable code detected
#pragma warning disable CS1717 // Assignment made to same variable

namespace DafnyToSExpressionCompiler {

  public partial class __default {
    public static Dafny.ISequence<Dafny.Rune> MapJoin<__T>(Func<__T, Dafny.ISequence<Dafny.Rune>> f, Dafny.ISequence<__T> xs)
    {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("("), Std.Collections.Seq.__default.Join<Dafny.Rune>(Std.Collections.Seq.__default.Map<__T, Dafny.ISequence<Dafny.Rune>>(f, xs), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(" "))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(")"));
    }
    public static Dafny.ISequence<Dafny.Rune> EscapeAndQuote(Dafny.ISequence<Dafny.Rune> str) {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""), Std.Strings.CharStrEscaping.__default.Escape(str, Dafny.Set<Dafny.Rune>.FromElements(new Dafny.Rune('\"'), new Dafny.Rune('\\')), new Dafny.Rune('\\'))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""));
    }
    public static Dafny.ISequence<Dafny.Rune> StringSeqToSexpr(Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> xs) {
      return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(((System.Func<Dafny.ISequence<Dafny.Rune>, Dafny.ISequence<Dafny.Rune>>)((_0_x) => {
        return _0_x;
      })), xs);
    }
    public static Dafny.ISequence<Dafny.Rune> OptionToSexpr<__T>(Std.Wrappers._IOption<__T> opt, Func<__T, Dafny.ISequence<Dafny.Rune>> f)
    {
      Std.Wrappers._IOption<__T> _source0 = opt;
      {
        if (_source0.is_None) {
          return Dafny.Sequence<Dafny.Rune>.UnicodeFromString("(None)");
        }
      }
      {
        __T _0_value = _source0.dtor_value;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Some"), Dafny.Helpers.Id<Func<__T, Dafny.ISequence<Dafny.Rune>>>(f)(_0_value)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TwoTupleToSexpr<__T, __U>(_System._ITuple2<__T, __U> tuple, Func<__T, Dafny.ISequence<Dafny.Rune>> Tf, Func<__U, Dafny.ISequence<Dafny.Rune>> Uf)
    {
      return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Helpers.Id<Func<__T, Dafny.ISequence<Dafny.Rune>>>(Tf)((tuple).dtor__0), Dafny.Helpers.Id<Func<__U, Dafny.ISequence<Dafny.Rune>>>(Uf)((tuple).dtor__1)));
    }
    public static Dafny.ISequence<Dafny.Rune> Compile(Dafny.ISequence<DAST._IModule> p)
    {
      Dafny.ISequence<Dafny.Rune> s = Dafny.Sequence<Dafny.Rune>.Empty;
      s = DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Program"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IModule>(DafnyToSExpressionCompiler.__default.ModuleToSexpr, p)));
      return s;
    }
    public static Dafny.ISequence<Dafny.Rune> NameToSexpr(Dafny.ISequence<Dafny.Rune> name) {
      Dafny.ISequence<Dafny.Rune> _source0 = name;
      {
        Dafny.ISequence<Dafny.Rune> _0_dafny__name = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Name.Name"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_0_dafny__name)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> VarNameToSexpr(Dafny.ISequence<Dafny.Rune> varName) {
      Dafny.ISequence<Dafny.Rune> _source0 = varName;
      {
        Dafny.ISequence<Dafny.Rune> _0_dafny__name = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("VarName.VarName"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_0_dafny__name)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ModuleToSexpr(DAST._IModule mod) {
      DAST._IModule _source0 = mod;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._IAttribute> _2_attributes = _source0.dtor_attributes;
        bool _3_requiresExterns = _source0.dtor_requiresExterns;
        Std.Wrappers._IOption<Dafny.ISequence<DAST._IModuleItem>> _4_body = _source0.dtor_body;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Module.Module"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2_attributes), Std.Strings.__default.OfBool(_3_requiresExterns), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<DAST._IModuleItem>>(_4_body, Dafny.Helpers.Id<Func<DAST._IModule, Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>>>((_5_mod) => ((System.Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>)((_6_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IModuleItem>(Dafny.Helpers.Id<Func<DAST._IModule, Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>>>((_7_mod) => ((System.Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>)((_8_i) => {
            return DafnyToSExpressionCompiler.__default.ModuleItemToSexpr(_8_i);
          })))(_5_mod), _6_x);
        })))(mod))));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ModuleItemToSexpr(DAST._IModuleItem modItem)
    {
      DAST._IModuleItem _source0 = modItem;
      {
        if (_source0.is_Module) {
          DAST._IModule _0_mod = _source0.dtor_Module_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Module"), DafnyToSExpressionCompiler.__default.ModuleToSexpr(_0_mod)));
        }
      }
      {
        if (_source0.is_Class) {
          DAST._IClass _1_cls = _source0.dtor_Class_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Class"), DafnyToSExpressionCompiler.__default.ClassToSexpr(_1_cls)));
        }
      }
      {
        if (_source0.is_Trait) {
          DAST._ITrait _2_trt = _source0.dtor_Trait_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Trait"), DafnyToSExpressionCompiler.__default.TraitToSexpr(_2_trt)));
        }
      }
      {
        if (_source0.is_Newtype) {
          DAST._INewtype _3_nt = _source0.dtor_Newtype_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Newtype"), DafnyToSExpressionCompiler.__default.NewtypeToSexpr(_3_nt)));
        }
      }
      {
        if (_source0.is_SynonymType) {
          DAST._ISynonymType _4_st = _source0.dtor_SynonymType_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.SynonymType"), DafnyToSExpressionCompiler.__default.SynonymTypeToSexpr(_4_st)));
        }
      }
      {
        DAST._IDatatype _5_dt = _source0.dtor_Datatype_a0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Datatype"), DafnyToSExpressionCompiler.__default.DatatypeToSexpr(_5_dt)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TypeToSexpr(DAST._IType t) {
      DAST._IType _source0 = t;
      {
        if (_source0.is_UserDefined) {
          DAST._IResolvedType _0_resolved = _source0.dtor_resolved;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.UserDefined"), DafnyToSExpressionCompiler.__default.ResolvedTypeToSexpr(_0_resolved)));
        }
      }
      {
        if (_source0.is_Tuple) {
          Dafny.ISequence<DAST._IType> _1_ts = _source0.dtor_Tuple_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Tuple"), DafnyToSExpressionCompiler.__default.MapJoinTypeToSexpr(_1_ts)));
        }
      }
      {
        if (_source0.is_Array) {
          DAST._IType _2_element = _source0.dtor_element;
          BigInteger _3_dims = _source0.dtor_dims;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Array"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2_element), Std.Strings.__default.OfNat(_3_dims)));
        }
      }
      {
        if (_source0.is_Seq) {
          DAST._IType _4_element = _source0.dtor_element;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Seq"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_4_element)));
        }
      }
      {
        if (_source0.is_Set) {
          DAST._IType _5_element = _source0.dtor_element;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Set"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_5_element)));
        }
      }
      {
        if (_source0.is_Multiset) {
          DAST._IType _6_element = _source0.dtor_element;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Multiset"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_6_element)));
        }
      }
      {
        if (_source0.is_Map) {
          DAST._IType _7_key = _source0.dtor_key;
          DAST._IType _8_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Map"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_7_key), DafnyToSExpressionCompiler.__default.TypeToSexpr(_8_value)));
        }
      }
      {
        if (_source0.is_SetBuilder) {
          DAST._IType _9_element = _source0.dtor_element;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.SetBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_9_element)));
        }
      }
      {
        if (_source0.is_MapBuilder) {
          DAST._IType _10_key = _source0.dtor_key;
          DAST._IType _11_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.MapBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_10_key), DafnyToSExpressionCompiler.__default.TypeToSexpr(_11_value)));
        }
      }
      {
        if (_source0.is_Arrow) {
          Dafny.ISequence<DAST._IType> _12_args = _source0.dtor_args;
          DAST._IType _13_result = _source0.dtor_result;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Arrow"), DafnyToSExpressionCompiler.__default.MapJoinTypeToSexpr(_12_args), DafnyToSExpressionCompiler.__default.TypeToSexpr(_13_result)));
        }
      }
      {
        if (_source0.is_Primitive) {
          DAST._IPrimitive _14_primitive = _source0.dtor_Primitive_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Primitive"), DafnyToSExpressionCompiler.__default.PrimitiveToSexpr(_14_primitive)));
        }
      }
      {
        if (_source0.is_Passthrough) {
          Dafny.ISequence<Dafny.Rune> _15_str = _source0.dtor_Passthrough_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Passthrough"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_15_str)));
        }
      }
      {
        if (_source0.is_TypeArg) {
          Dafny.ISequence<Dafny.Rune> _16_id = _source0.dtor_TypeArg_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.TypeArg"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_16_id)));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Object")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinTypeToSexpr(Dafny.ISequence<DAST._IType> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IType>, Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>>>((_0_ts) => ((System.Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>)((_1_x) => {
        return DafnyToSExpressionCompiler.__default.TypeToSexpr(_1_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> VarianceToSexpr(DAST._IVariance v) {
      DAST._IVariance _source0 = v;
      {
        if (_source0.is_Nonvariant) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Variance.Nonvariant")));
        }
      }
      {
        if (_source0.is_Covariant) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Variance.Covariant")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Variance.Contravariant")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TypeArgDeclToSexpr(DAST._ITypeArgDecl typeArgDecl) {
      DAST._ITypeArgDecl _source0 = typeArgDecl;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgBound> _1_bounds = _source0.dtor_bounds;
        DAST._ITypeParameterInfo _2_info = _source0.dtor_info;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgDecl.TypeArgDecl"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgBound>(DafnyToSExpressionCompiler.__default.TypeArgBoundToSexpr, _1_bounds), DafnyToSExpressionCompiler.__default.TypeParameterInfoToSexpr(_2_info)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TypeArgBoundToSexpr(DAST._ITypeArgBound typeArgBound) {
      DAST._ITypeArgBound _source0 = typeArgBound;
      {
        if (_source0.is_SupportsEquality) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.SupportsEquality")));
        }
      }
      {
        if (_source0.is_SupportsDefault) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.SupportsDefault")));
        }
      }
      {
        DAST._IType _0_typ = _source0.dtor_typ;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.TraitBound"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_0_typ)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> PrimitiveToSexpr(DAST._IPrimitive primitive) {
      DAST._IPrimitive _source0 = primitive;
      {
        if (_source0.is_Int) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Int")));
        }
      }
      {
        if (_source0.is_Real) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Real")));
        }
      }
      {
        if (_source0.is_String) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.String")));
        }
      }
      {
        if (_source0.is_Bool) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Bool")));
        }
      }
      {
        if (_source0.is_Char) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Char")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Native")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeRangeToSexpr(DAST._INewtypeRange range) {
      DAST._INewtypeRange _source0 = range;
      {
        if (_source0.is_U8) {
          bool _0_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U8"), Std.Strings.__default.OfBool(_0_overflow)));
        }
      }
      {
        if (_source0.is_I8) {
          bool _1_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I8"), Std.Strings.__default.OfBool(_1_overflow)));
        }
      }
      {
        if (_source0.is_U16) {
          bool _2_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U16"), Std.Strings.__default.OfBool(_2_overflow)));
        }
      }
      {
        if (_source0.is_I16) {
          bool _3_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I16"), Std.Strings.__default.OfBool(_3_overflow)));
        }
      }
      {
        if (_source0.is_U32) {
          bool _4_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U32"), Std.Strings.__default.OfBool(_4_overflow)));
        }
      }
      {
        if (_source0.is_I32) {
          bool _5_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I32"), Std.Strings.__default.OfBool(_5_overflow)));
        }
      }
      {
        if (_source0.is_U64) {
          bool _6_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U64"), Std.Strings.__default.OfBool(_6_overflow)));
        }
      }
      {
        if (_source0.is_I64) {
          bool _7_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I64"), Std.Strings.__default.OfBool(_7_overflow)));
        }
      }
      {
        if (_source0.is_U128) {
          bool _8_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U128"), Std.Strings.__default.OfBool(_8_overflow)));
        }
      }
      {
        if (_source0.is_I128) {
          bool _9_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I128"), Std.Strings.__default.OfBool(_9_overflow)));
        }
      }
      {
        if (_source0.is_NativeArrayIndex) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.NativeArrayIndex")));
        }
      }
      {
        if (_source0.is_BigInt) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.BigInt")));
        }
      }
      {
        if (_source0.is_Bool) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.Bool")));
        }
      }
      {
        if (_source0.is_Sequence) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.Sequence")));
        }
      }
      {
        if (_source0.is_Map) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.Map")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.NoRange")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> AttributeToSexpr(DAST._IAttribute attribute) {
      DAST._IAttribute _source0 = attribute;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1_args = _source0.dtor_args;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Attribute.Attribute"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.EscapeAndQuote, _1_args)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeTypeToSexpr(DAST._INewtypeType ntt) {
      DAST._INewtypeType _source0 = ntt;
      {
        DAST._IType _0_baseType = _source0.dtor_baseType;
        DAST._INewtypeRange _1_range = _source0.dtor_range;
        bool _2_erase = _source0.dtor_erase;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeType.NewtypeType"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_0_baseType), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_1_range), Std.Strings.__default.OfBool(_2_erase)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TraitTypeToSexpr(DAST._ITraitType tt) {
      DAST._ITraitType _source0 = tt;
      {
        if (_source0.is_ObjectTrait) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TraitType.ObjectTrait")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TraitType.GeneralTrait")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TypeParameterInfoToSexpr(DAST._ITypeParameterInfo tpi) {
      DAST._ITypeParameterInfo _source0 = tpi;
      {
        DAST._IVariance _0_variance = _source0.dtor_variance;
        bool _1_necessaryForEqualitySupportOfSurroundingInductiveDatatype = _source0.dtor_necessaryForEqualitySupportOfSurroundingInductiveDatatype;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeParameterInfo.TypeParameterInfo"), DafnyToSExpressionCompiler.__default.VarianceToSexpr(_0_variance), Std.Strings.__default.OfBool(_1_necessaryForEqualitySupportOfSurroundingInductiveDatatype)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> EqualitySupportToSexpr(DAST._IEqualitySupport es) {
      DAST._IEqualitySupport _source0 = es;
      {
        if (_source0.is_Never) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("EqualitySupport.Never")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("EqualitySupport.ConsultTypeArguments")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ResolvedTypeBaseToSexpr(DAST._IResolvedTypeBase rtb) {
      DAST._IResolvedTypeBase _source0 = rtb;
      {
        if (_source0.is_Class) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Class")));
        }
      }
      {
        if (_source0.is_Datatype) {
          DAST._IEqualitySupport _0_equalitySupport = _source0.dtor_equalitySupport;
          Dafny.ISequence<DAST._ITypeParameterInfo> _1_info = _source0.dtor_info;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Datatype"), DafnyToSExpressionCompiler.__default.EqualitySupportToSexpr(_0_equalitySupport), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeParameterInfo>(DafnyToSExpressionCompiler.__default.TypeParameterInfoToSexpr, _1_info)));
        }
      }
      {
        if (_source0.is_Trait) {
          DAST._ITraitType _2_traitType = _source0.dtor_traitType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Trait"), DafnyToSExpressionCompiler.__default.TraitTypeToSexpr(_2_traitType)));
        }
      }
      {
        if (_source0.is_SynonymType) {
          DAST._IType _3_baseType = _source0.dtor_baseType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.SynonymType"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_3_baseType)));
        }
      }
      {
        DAST._IType _4_baseType = _source0.dtor_baseType;
        DAST._INewtypeRange _5_range = _source0.dtor_range;
        bool _6_erase = _source0.dtor_erase;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Newtype"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_4_baseType), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_5_range), Std.Strings.__default.OfBool(_6_erase)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ResolvedTypeToSexpr(DAST._IResolvedType resolvedType) {
      DAST._IResolvedType _source0 = resolvedType;
      {
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _0_path = _source0.dtor_path;
        Dafny.ISequence<DAST._IType> _1_typeArgs = _source0.dtor_typeArgs;
        DAST._IResolvedTypeBase _2_kind = _source0.dtor_kind;
        Dafny.ISequence<DAST._IAttribute> _3_attributes = _source0.dtor_attributes;
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _4_properMethods = _source0.dtor_properMethods;
        Dafny.ISequence<DAST._IType> _5_extendedTypes = _source0.dtor_extendedTypes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedType.ResolvedType"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _0_path), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IType>, Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>>>((_6_typeArgs) => ((System.Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>)((_7_x) => {
          return DafnyToSExpressionCompiler.__default.TypeToSexpr(_7_x);
        })))(_1_typeArgs), _1_typeArgs), DafnyToSExpressionCompiler.__default.ResolvedTypeBaseToSexpr(_2_kind), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _3_attributes), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.NameToSexpr, _4_properMethods), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IType>, Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>>>((_8_extendedTypes) => ((System.Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>)((_9_x) => {
          return DafnyToSExpressionCompiler.__default.TypeToSexpr(_9_x);
        })))(_5_extendedTypes), _5_extendedTypes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> IdentToSexpr(Dafny.ISequence<Dafny.Rune> ident) {
      Dafny.ISequence<Dafny.Rune> _source0 = ident;
      {
        Dafny.ISequence<Dafny.Rune> _0_id = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Ident.Ident"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_id)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ClassToSexpr(DAST._IClass cls) {
      DAST._IClass _source0 = cls;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<Dafny.Rune> _2_enclosingModule = _source0.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _3_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IType> _4_superTraitTypes = _source0.dtor_superTraitTypes;
        Dafny.ISequence<DAST._IField> _5_fields = _source0.dtor_fields;
        Dafny.ISequence<DAST._IMethod> _6_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _7_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Class.Class"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.IdentToSexpr(_2_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _3_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _4_superTraitTypes), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IField>(DafnyToSExpressionCompiler.__default.FieldToSexpr, _5_fields), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _6_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _7_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TraitToSexpr(DAST._ITrait trt) {
      DAST._ITrait _source0 = trt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._ITypeArgDecl> _2_typeParams = _source0.dtor_typeParams;
        DAST._ITraitType _3_traitType = _source0.dtor_traitType;
        Dafny.ISequence<DAST._IType> _4_parents = _source0.dtor_parents;
        Dafny.ISequence<DAST._IType> _5_downcastableTraits = _source0.dtor_downcastableTraits;
        Dafny.ISequence<DAST._IMethod> _6_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _7_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Trait.Trait"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2_typeParams), DafnyToSExpressionCompiler.__default.TraitTypeToSexpr(_3_traitType), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _4_parents), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _5_downcastableTraits), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _6_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _7_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeToSexpr(DAST._IDatatype dt) {
      DAST._IDatatype _source0 = dt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<Dafny.Rune> _2_enclosingModule = _source0.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _3_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IDatatypeCtor> _4_ctors = _source0.dtor_ctors;
        Dafny.ISequence<DAST._IMethod> _5_body = _source0.dtor_body;
        bool _6_isCo = _source0.dtor_isCo;
        DAST._IEqualitySupport _7_equalitySupport = _source0.dtor_equalitySupport;
        Dafny.ISequence<DAST._IAttribute> _8_attributes = _source0.dtor_attributes;
        Dafny.ISequence<DAST._IType> _9_superTraitTypes = _source0.dtor_superTraitTypes;
        Dafny.ISequence<DAST._IType> _10_superTraitNegativeTypes = _source0.dtor_superTraitNegativeTypes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Datatype.Datatype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.IdentToSexpr(_2_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _3_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeCtor>(DafnyToSExpressionCompiler.__default.DatatypeCtorToSexpr, _4_ctors), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _5_body), Std.Strings.__default.OfBool(_6_isCo), DafnyToSExpressionCompiler.__default.EqualitySupportToSexpr(_7_equalitySupport), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _8_attributes), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _9_superTraitTypes), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _10_superTraitNegativeTypes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeDtorToSexpr(DAST._IDatatypeDtor datatypeDtor) {
      DAST._IDatatypeDtor _source0 = datatypeDtor;
      {
        DAST._IFormal _0_formal = _source0.dtor_formal;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.Rune>> _1_callName = _source0.dtor_callName;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeDtor.DatatypeDtor"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_0_formal), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.Rune>>(_1_callName, DafnyToSExpressionCompiler.__default.EscapeAndQuote)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeCtorToSexpr(DAST._IDatatypeCtor datatypeCtor) {
      DAST._IDatatypeCtor _source0 = datatypeCtor;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._IDatatypeDtor> _2_args = _source0.dtor_args;
        bool _3_hasAnyArgs = _source0.dtor_hasAnyArgs;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeCtor.DatatypeCtor"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeDtor>(DafnyToSExpressionCompiler.__default.DatatypeDtorToSexpr, _2_args), Std.Strings.__default.OfBool(_3_hasAnyArgs)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeToSexpr(DAST._INewtype nt) {
      DAST._INewtype _source0 = nt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._ITypeArgDecl> _2_typeParams = _source0.dtor_typeParams;
        DAST._IType _3_base = _source0.dtor_base;
        DAST._INewtypeRange _4_range = _source0.dtor_range;
        Std.Wrappers._IOption<DAST._INewtypeConstraint> _5_constraint = _source0.dtor_constraint;
        Dafny.ISequence<DAST._IStatement> _6_witnessStmts = _source0.dtor_witnessStmts;
        Std.Wrappers._IOption<DAST._IExpression> _7_witnessExpr = _source0.dtor_witnessExpr;
        DAST._IEqualitySupport _8_equalitySupport = _source0.dtor_equalitySupport;
        Dafny.ISequence<DAST._IAttribute> _9_attributes = _source0.dtor_attributes;
        Dafny.ISequence<DAST._IMethod> _10_classItems = _source0.dtor_classItems;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Newtype.Newtype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2_typeParams), DafnyToSExpressionCompiler.__default.TypeToSexpr(_3_base), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_4_range), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._INewtypeConstraint>(_5_constraint, DafnyToSExpressionCompiler.__default.NewtypeConstraintToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _6_witnessStmts), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_7_witnessExpr, DafnyToSExpressionCompiler.__default.ExpressionToSexpr), DafnyToSExpressionCompiler.__default.EqualitySupportToSexpr(_8_equalitySupport), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _9_attributes), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _10_classItems)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeConstraintToSexpr(DAST._INewtypeConstraint ntc) {
      DAST._INewtypeConstraint _source0 = ntc;
      {
        DAST._IFormal _0_variable = _source0.dtor_variable;
        Dafny.ISequence<DAST._IStatement> _1_constraintStmts = _source0.dtor_constraintStmts;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeConstraint.NewtypeConstraint"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_0_variable), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _1_constraintStmts)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> SynonymTypeToSexpr(DAST._ISynonymType st) {
      DAST._ISynonymType _source0 = st;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._ITypeArgDecl> _2_typeParams = _source0.dtor_typeParams;
        DAST._IType _3_base = _source0.dtor_base;
        Dafny.ISequence<DAST._IStatement> _4_witnessStmts = _source0.dtor_witnessStmts;
        Std.Wrappers._IOption<DAST._IExpression> _5_witnessExpr = _source0.dtor_witnessExpr;
        Dafny.ISequence<DAST._IAttribute> _6_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("SynonymType.SynonymType"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2_typeParams), DafnyToSExpressionCompiler.__default.TypeToSexpr(_3_base), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _4_witnessStmts), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_5_witnessExpr, DafnyToSExpressionCompiler.__default.ExpressionToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _6_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ClassItemToSexpr(DAST._IMethod classItem) {
      DAST._IMethod _source0 = classItem;
      {
        DAST._IMethod _0_m = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ClassItem.Method"), DafnyToSExpressionCompiler.__default.MethodToSexpr(_0_m)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> FieldToSexpr(DAST._IField field) {
      DAST._IField _source0 = field;
      {
        DAST._IFormal _0_formal = _source0.dtor_formal;
        bool _1_isConstant = _source0.dtor_isConstant;
        Std.Wrappers._IOption<DAST._IExpression> _2_defaultValue = _source0.dtor_defaultValue;
        bool _3_isStatic = _source0.dtor_isStatic;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Field.Field"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_0_formal), Std.Strings.__default.OfBool(_1_isConstant), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_2_defaultValue, Dafny.Helpers.Id<Func<Std.Wrappers._IOption<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_4_defaultValue) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_5_x) => {
          return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_5_x);
        })))(_2_defaultValue)), Std.Strings.__default.OfBool(_3_isStatic)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> FormalToSexpr(DAST._IFormal formal) {
      DAST._IFormal _source0 = formal;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        DAST._IType _1_typ = _source0.dtor_typ;
        Dafny.ISequence<DAST._IAttribute> _2_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Formal.Formal"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1_typ), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MethodToSexpr(DAST._IMethod m) {
      DAST._IMethod _source0 = m;
      {
        Dafny.ISequence<Dafny.Rune> _0_docString = _source0.dtor_docString;
        Dafny.ISequence<DAST._IAttribute> _1_attributes = _source0.dtor_attributes;
        bool _2_isStatic = _source0.dtor_isStatic;
        bool _3_hasBody = _source0.dtor_hasBody;
        bool _4_outVarsAreUninitFieldsToAssign = _source0.dtor_outVarsAreUninitFieldsToAssign;
        bool _5_wasFunction = _source0.dtor_wasFunction;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _6_overridingPath = _source0.dtor_overridingPath;
        Dafny.ISequence<Dafny.Rune> _7_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _8_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IFormal> _9_params = _source0.dtor_params;
        Dafny.ISequence<DAST._IFormal> _10_inheritedParams = _source0.dtor_inheritedParams;
        Dafny.ISequence<DAST._IStatement> _11_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IType> _12_outTypes = _source0.dtor_outTypes;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _13_outVars = _source0.dtor_outVars;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Method.Method"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_0_docString), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1_attributes), Std.Strings.__default.OfBool(_2_isStatic), Std.Strings.__default.OfBool(_3_hasBody), Std.Strings.__default.OfBool(_4_outVarsAreUninitFieldsToAssign), Std.Strings.__default.OfBool(_5_wasFunction), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_6_overridingPath, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_14_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _14_x);
        }))), DafnyToSExpressionCompiler.__default.NameToSexpr(_7_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _8_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _9_params), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _10_inheritedParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _11_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _12_outTypes), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_13_outVars, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_15_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.VarNameToSexpr, _15_x);
        })))));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> CallSignatureToSexpr(DAST._ICallSignature signature) {
      DAST._ICallSignature _source0 = signature;
      {
        Dafny.ISequence<DAST._IFormal> _0_parameters = _source0.dtor_parameters;
        Dafny.ISequence<DAST._IFormal> _1_inheritedParams = _source0.dtor_inheritedParams;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallSignature.CallSignature"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _0_parameters), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _1_inheritedParams)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> CallNameToSexpr(DAST._ICallName callName) {
      DAST._ICallName _source0 = callName;
      {
        if (_source0.is_CallName) {
          Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
          Std.Wrappers._IOption<DAST._IType> _1_onType = _source0.dtor_onType;
          Std.Wrappers._IOption<DAST._IFormal> _2_receiverArgs = _source0.dtor_receiverArg;
          bool _3_receiverAsArgument = _source0.dtor_receiverAsArgument;
          DAST._ICallSignature _4_signature = _source0.dtor_signature;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.CallName"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IType>(_1_onType, DafnyToSExpressionCompiler.__default.TypeToSexpr), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IFormal>(_2_receiverArgs, DafnyToSExpressionCompiler.__default.FormalToSexpr), Std.Strings.__default.OfBool(_3_receiverAsArgument), DafnyToSExpressionCompiler.__default.CallSignatureToSexpr(_4_signature)));
        }
      }
      {
        if (_source0.is_MapBuilderAdd) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.MapBuilderAdd")));
        }
      }
      {
        if (_source0.is_MapBuilderBuild) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.MapBuilderBuild")));
        }
      }
      {
        if (_source0.is_SetBuilderAdd) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.SetBuilderAdd")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.SetBuilderBuild")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> SelectContextToSexpr(DAST._ISelectContext sc) {
      DAST._ISelectContext _source0 = sc;
      {
        if (_source0.is_SelectContextDatatype) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("SelectContext.SelectContextDatatype")));
        }
      }
      {
        if (_source0.is_SelectContextGeneralTrait) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("SelectContext.SelectContextGeneralTrait")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("SelectContext.SelectContextClassOrObjectTrait")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> StatementToSexpr(DAST._IStatement stmt) {
      DAST._IStatement _source0 = stmt;
      {
        if (_source0.is_DeclareVar) {
          Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
          DAST._IType _1_typ = _source0.dtor_typ;
          Std.Wrappers._IOption<DAST._IExpression> _2_maybeValue = _source0.dtor_maybeValue;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.DeclareVar"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1_typ), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_2_maybeValue, Dafny.Helpers.Id<Func<Std.Wrappers._IOption<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_3_maybeValue) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_4_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_4_x);
          })))(_2_maybeValue))));
        }
      }
      {
        if (_source0.is_Assign) {
          DAST._IAssignLhs _5_lhs = _source0.dtor_lhs;
          DAST._IExpression _6_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Assign"), DafnyToSExpressionCompiler.__default.AssignLhsToSexpr(_5_lhs), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_6_value)));
        }
      }
      {
        if (_source0.is_If) {
          DAST._IExpression _7_cond = _source0.dtor_cond;
          Dafny.ISequence<DAST._IStatement> _8_thn = _source0.dtor_thn;
          Dafny.ISequence<DAST._IStatement> _9_els = _source0.dtor_els;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.If"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_7_cond), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_8_thn), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_9_els)));
        }
      }
      {
        if (_source0.is_Labeled) {
          Dafny.ISequence<Dafny.Rune> _10_lbl = _source0.dtor_lbl;
          Dafny.ISequence<DAST._IStatement> _11_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Labeled"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_10_lbl), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_11_body)));
        }
      }
      {
        if (_source0.is_While) {
          DAST._IExpression _12_cond = _source0.dtor_cond;
          Dafny.ISequence<DAST._IStatement> _13_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.While"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_12_cond), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_13_body)));
        }
      }
      {
        if (_source0.is_Foreach) {
          Dafny.ISequence<Dafny.Rune> _14_boundName = _source0.dtor_boundName;
          DAST._IType _15_boundType = _source0.dtor_boundType;
          DAST._IExpression _16_over = _source0.dtor_over;
          Dafny.ISequence<DAST._IStatement> _17_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Foreach"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_14_boundName), DafnyToSExpressionCompiler.__default.TypeToSexpr(_15_boundType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_16_over), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_17_body)));
        }
      }
      {
        if (_source0.is_Call) {
          DAST._IExpression _18_on = _source0.dtor_on;
          DAST._ICallName _19_callName = _source0.dtor_callName;
          Dafny.ISequence<DAST._IType> _20_typeArgs = _source0.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _21_args = _source0.dtor_args;
          Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _22_outs = _source0.dtor_outs;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Call"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_18_on), DafnyToSExpressionCompiler.__default.CallNameToSexpr(_19_callName), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _20_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_21_args), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_22_outs, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_23_x) => {
            return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.VarNameToSexpr, _23_x);
          })))));
        }
      }
      {
        if (_source0.is_Return) {
          DAST._IExpression _24_expr = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Return"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_24_expr)));
        }
      }
      {
        if (_source0.is_EarlyReturn) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.EarlyReturn")));
        }
      }
      {
        if (_source0.is_Break) {
          Std.Wrappers._IOption<Dafny.ISequence<Dafny.Rune>> _25_toLabel = _source0.dtor_toLabel;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Break"), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.Rune>>(_25_toLabel, DafnyToSExpressionCompiler.__default.EscapeAndQuote)));
        }
      }
      {
        if (_source0.is_TailRecursive) {
          Dafny.ISequence<DAST._IStatement> _26_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.TailRecursive"), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_26_body)));
        }
      }
      {
        if (_source0.is_JumpTailCallStart) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.JumpTailCallStart")));
        }
      }
      {
        if (_source0.is_Halt) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Halt")));
        }
      }
      {
        if (_source0.is_Print) {
          DAST._IExpression _27_expr = _source0.dtor_Print_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Print"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_27_expr)));
        }
      }
      {
        Dafny.ISequence<DAST._IField> _28_fields = _source0.dtor_fields;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.ConstructorNewSeparator"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IField>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IField>, Func<DAST._IField, Dafny.ISequence<Dafny.Rune>>>>((_29_fields) => ((System.Func<DAST._IField, Dafny.ISequence<Dafny.Rune>>)((_30_x) => {
          return DafnyToSExpressionCompiler.__default.FieldToSexpr(_30_x);
        })))(_28_fields), _28_fields)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinStatementToSexpr(Dafny.ISequence<DAST._IStatement> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IStatement>, Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>>>((_0_ts) => ((System.Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>)((_1_x) => {
        return DafnyToSExpressionCompiler.__default.StatementToSexpr(_1_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> AssignLhsToSexpr(DAST._IAssignLhs lhs) {
      DAST._IAssignLhs _source0 = lhs;
      {
        if (_source0.is_Ident) {
          Dafny.ISequence<Dafny.Rune> _0_ident = _source0.dtor_ident;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Ident"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_0_ident)));
        }
      }
      {
        if (_source0.is_Select) {
          DAST._IExpression _1_expr = _source0.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _2_field = _source0.dtor_field;
          bool _3_isConstant = _source0.dtor_isConstant;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1_expr), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_2_field), Std.Strings.__default.OfBool(_3_isConstant)));
        }
      }
      {
        DAST._IExpression _4_expr = _source0.dtor_expr;
        Dafny.ISequence<DAST._IExpression> _5_indices = _source0.dtor_indices;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_4_expr), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_5_indices)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> CollKindToSexpr(DAST._ICollKind collKind) {
      DAST._ICollKind _source0 = collKind;
      {
        if (_source0.is_Seq) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Seq")));
        }
      }
      {
        if (_source0.is_Array) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Array")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Map")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TypedBinOpToSexpr(DAST._ITypedBinOp tbop) {
      DAST._ITypedBinOp _source0 = tbop;
      {
        DAST._IBinOp _0_op = _source0.dtor_op;
        DAST._IType _1_leftType = _source0.dtor_leftType;
        DAST._IType _2_rightType = _source0.dtor_rightType;
        DAST._IType _3_resultType = _source0.dtor_resultType;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypedBinOp.TypedBinOp"), DafnyToSExpressionCompiler.__default.BinOpToSexpr(_0_op), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1_leftType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2_rightType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_3_resultType)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> BinOpToSexpr(DAST._IBinOp op) {
      DAST._IBinOp _source0 = op;
      {
        if (_source0.is_Eq) {
          bool _0_referential = _source0.dtor_referential;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Eq"), Std.Strings.__default.OfBool(_0_referential)));
        }
      }
      {
        if (_source0.is_Div) {
          bool _1_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Div"), Std.Strings.__default.OfBool(_1_overflow)));
        }
      }
      {
        if (_source0.is_EuclidianDiv) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.EuclidianDiv")));
        }
      }
      {
        if (_source0.is_Mod) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Mod")));
        }
      }
      {
        if (_source0.is_EuclidianMod) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.EuclidianMod")));
        }
      }
      {
        if (_source0.is_Lt) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Lt")));
        }
      }
      {
        if (_source0.is_LtChar) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.LtChar")));
        }
      }
      {
        if (_source0.is_Plus) {
          bool _2_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Plus"), Std.Strings.__default.OfBool(_2_overflow)));
        }
      }
      {
        if (_source0.is_Minus) {
          bool _3_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Minus"), Std.Strings.__default.OfBool(_3_overflow)));
        }
      }
      {
        if (_source0.is_Times) {
          bool _4_overflow = _source0.dtor_overflow;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Times"), Std.Strings.__default.OfBool(_4_overflow)));
        }
      }
      {
        if (_source0.is_BitwiseAnd) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseAnd")));
        }
      }
      {
        if (_source0.is_BitwiseOr) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseOr")));
        }
      }
      {
        if (_source0.is_BitwiseXor) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseXor")));
        }
      }
      {
        if (_source0.is_BitwiseShiftRight) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseShiftRight")));
        }
      }
      {
        if (_source0.is_BitwiseShiftLeft) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseShiftLeft")));
        }
      }
      {
        if (_source0.is_And) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.And")));
        }
      }
      {
        if (_source0.is_Or) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Or")));
        }
      }
      {
        if (_source0.is_In) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.In")));
        }
      }
      {
        if (_source0.is_SeqProperPrefix) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SeqProperPrefix")));
        }
      }
      {
        if (_source0.is_SeqPrefix) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SeqPrefix")));
        }
      }
      {
        if (_source0.is_SetMerge) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetMerge")));
        }
      }
      {
        if (_source0.is_SetSubtraction) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetSubtraction")));
        }
      }
      {
        if (_source0.is_SetIntersection) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetIntersection")));
        }
      }
      {
        if (_source0.is_Subset) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Subset")));
        }
      }
      {
        if (_source0.is_ProperSubset) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.ProperSubset")));
        }
      }
      {
        if (_source0.is_SetDisjoint) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetDisjoint")));
        }
      }
      {
        if (_source0.is_MapMerge) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MapMerge")));
        }
      }
      {
        if (_source0.is_MapSubtraction) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MapSubtraction")));
        }
      }
      {
        if (_source0.is_MultisetMerge) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetMerge")));
        }
      }
      {
        if (_source0.is_MultisetSubtraction) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetSubtraction")));
        }
      }
      {
        if (_source0.is_MultisetIntersection) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetIntersection")));
        }
      }
      {
        if (_source0.is_Submultiset) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Submultiset")));
        }
      }
      {
        if (_source0.is_ProperSubmultiset) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.ProperSubmultiset")));
        }
      }
      {
        if (_source0.is_MultisetDisjoint) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetDisjoint")));
        }
      }
      {
        if (_source0.is_Concat) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Concat")));
        }
      }
      {
        Dafny.ISequence<Dafny.Rune> _5_str = _source0.dtor_Passthrough_a0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Passthrough"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_5_str)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ExpressionToSexpr(DAST._IExpression expr) {
      DAST._IExpression _source0 = expr;
      {
        if (_source0.is_Literal) {
          DAST._ILiteral _0_literal = _source0.dtor_Literal_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Literal"), DafnyToSExpressionCompiler.__default.LiteralToSexpr(_0_literal)));
        }
      }
      {
        if (_source0.is_Ident) {
          Dafny.ISequence<Dafny.Rune> _1_name = _source0.dtor_name;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Ident"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_1_name)));
        }
      }
      {
        if (_source0.is_Companion) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _2_ids = _source0.dtor_Companion_a0;
          Dafny.ISequence<DAST._IType> _3_typeArgs = _source0.dtor_typeArgs;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Companion"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2_ids), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _3_typeArgs)));
        }
      }
      {
        if (_source0.is_ExternCompanion) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _4_ids = _source0.dtor_ExternCompanion_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ExternCompanion"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _4_ids)));
        }
      }
      {
        if (_source0.is_Tuple) {
          Dafny.ISequence<DAST._IExpression> _5_exprs = _source0.dtor_Tuple_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Tuple"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_5_exprs)));
        }
      }
      {
        if (_source0.is_New) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _6_path = _source0.dtor_path;
          Dafny.ISequence<DAST._IType> _7_typeArgs = _source0.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _8_args = _source0.dtor_args;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.New"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _6_path), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _7_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_8_args)));
        }
      }
      {
        if (_source0.is_NewUninitArray) {
          Dafny.ISequence<DAST._IExpression> _9_dims = _source0.dtor_dims;
          DAST._IType _10_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.NewUninitArray"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_9_dims), DafnyToSExpressionCompiler.__default.TypeToSexpr(_10_typ)));
        }
      }
      {
        if (_source0.is_ArrayIndexToInt) {
          DAST._IExpression _11_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ArrayIndexToInt"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_11_value)));
        }
      }
      {
        if (_source0.is_FinalizeNewArray) {
          DAST._IExpression _12_value = _source0.dtor_value;
          DAST._IType _13_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.FinalizeNewArray"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_12_value), DafnyToSExpressionCompiler.__default.TypeToSexpr(_13_typ)));
        }
      }
      {
        if (_source0.is_DatatypeValue) {
          DAST._IResolvedType _14_datatypeType = _source0.dtor_datatypeType;
          Dafny.ISequence<DAST._IType> _15_typeArgs = _source0.dtor_typeArgs;
          Dafny.ISequence<Dafny.Rune> _16_variant = _source0.dtor_variant;
          bool _17_isCo = _source0.dtor_isCo;
          Dafny.ISequence<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>> _18_contents = _source0.dtor_contents;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.DatatypeValue"), DafnyToSExpressionCompiler.__default.ResolvedTypeToSexpr(_14_datatypeType), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _15_typeArgs), DafnyToSExpressionCompiler.__default.NameToSexpr(_16_variant), Std.Strings.__default.OfBool(_17_isCo), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_19_contents, _20_expr) => ((System.Func<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_21_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>(_21_x, DafnyToSExpressionCompiler.__default.VarNameToSexpr, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_22_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_23_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_23_z);
            })))(_20_expr));
          })))(_18_contents, expr), _18_contents)));
        }
      }
      {
        if (_source0.is_Convert) {
          DAST._IExpression _24_value = _source0.dtor_value;
          DAST._IType _25_from = _source0.dtor_from;
          DAST._IType _26_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Convert"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_24_value), DafnyToSExpressionCompiler.__default.TypeToSexpr(_25_from), DafnyToSExpressionCompiler.__default.TypeToSexpr(_26_typ)));
        }
      }
      {
        if (_source0.is_SeqConstruct) {
          DAST._IExpression _27_length = _source0.dtor_length;
          DAST._IExpression _28_elem = _source0.dtor_elem;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqConstruct"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_27_length), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_28_elem)));
        }
      }
      {
        if (_source0.is_SeqValue) {
          Dafny.ISequence<DAST._IExpression> _29_elements = _source0.dtor_elements;
          DAST._IType _30_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_29_elements), DafnyToSExpressionCompiler.__default.TypeToSexpr(_30_typ)));
        }
      }
      {
        if (_source0.is_SetValue) {
          Dafny.ISequence<DAST._IExpression> _31_elements = _source0.dtor_elements;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_31_elements)));
        }
      }
      {
        if (_source0.is_MultisetValue) {
          Dafny.ISequence<DAST._IExpression> _32_elements = _source0.dtor_elements;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MultisetValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_32_elements)));
        }
      }
      {
        if (_source0.is_MapValue) {
          Dafny.ISequence<_System._ITuple2<DAST._IExpression, DAST._IExpression>> _33_mapElems = _source0.dtor_mapElems;
          DAST._IType _34_domainType = _source0.dtor_domainType;
          DAST._IType _35_rangeType = _source0.dtor_rangeType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValue"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IExpression, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IExpression, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_36_mapElems, _37_expr) => ((System.Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_38_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IExpression, DAST._IExpression>(_38_x, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_39_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_40_y) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_40_y);
            })))(_37_expr), Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_41_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_42_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_42_z);
            })))(_37_expr));
          })))(_33_mapElems, expr), _33_mapElems), DafnyToSExpressionCompiler.__default.TypeToSexpr(_34_domainType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_35_rangeType)));
        }
      }
      {
        if (_source0.is_MapBuilder) {
          DAST._IType _43_keyType = _source0.dtor_keyType;
          DAST._IType _44_valueType = _source0.dtor_valueType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_43_keyType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_44_valueType)));
        }
      }
      {
        if (_source0.is_SeqUpdate) {
          DAST._IExpression _45_expr_k = _source0.dtor_expr;
          DAST._IExpression _46_indexExpr = _source0.dtor_indexExpr;
          DAST._IExpression _47_value = _source0.dtor_value;
          DAST._IType _48_collectionType = _source0.dtor_collectionType;
          DAST._IType _49_exprType = _source0.dtor_exprType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_45_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_46_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_47_value), DafnyToSExpressionCompiler.__default.TypeToSexpr(_48_collectionType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_49_exprType)));
        }
      }
      {
        if (_source0.is_MapUpdate) {
          DAST._IExpression _50_expr_k = _source0.dtor_expr;
          DAST._IExpression _51_indexExpr = _source0.dtor_indexExpr;
          DAST._IExpression _52_value = _source0.dtor_value;
          DAST._IType _53_collectionType = _source0.dtor_collectionType;
          DAST._IType _54_exprType = _source0.dtor_exprType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_50_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_51_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_52_value), DafnyToSExpressionCompiler.__default.TypeToSexpr(_53_collectionType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_54_exprType)));
        }
      }
      {
        if (_source0.is_SetBuilder) {
          DAST._IType _55_elemType = _source0.dtor_elemType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_55_elemType)));
        }
      }
      {
        if (_source0.is_ToMultiset) {
          DAST._IExpression _56_expr_k = _source0.dtor_ToMultiset_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ToMultiset"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_56_expr_k)));
        }
      }
      {
        if (_source0.is_This) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.This")));
        }
      }
      {
        if (_source0.is_Ite) {
          DAST._IExpression _57_cond = _source0.dtor_cond;
          DAST._IExpression _58_thn = _source0.dtor_thn;
          DAST._IExpression _59_els = _source0.dtor_els;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Ite"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_57_cond), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_58_thn), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_59_els)));
        }
      }
      {
        if (_source0.is_UnOp) {
          DAST._IUnaryOp _60_unOp = _source0.dtor_unOp;
          DAST._IExpression _61_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.UnOp"), DafnyToSExpressionCompiler.__default.UnaryOpToSexpr(_60_unOp), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_61_expr_k)));
        }
      }
      {
        if (_source0.is_BinOp) {
          DAST._ITypedBinOp _62_tbop = _source0.dtor_op;
          DAST._IExpression _63_left = _source0.dtor_left;
          DAST._IExpression _64_right = _source0.dtor_right;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BinOp"), DafnyToSExpressionCompiler.__default.TypedBinOpToSexpr(_62_tbop), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_63_left), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_64_right)));
        }
      }
      {
        if (_source0.is_ArrayLen) {
          DAST._IExpression _65_expr_k = _source0.dtor_expr;
          DAST._IType _66_exprType = _source0.dtor_exprType;
          BigInteger _67_dim = _source0.dtor_dim;
          bool _68_native = _source0.dtor_native;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ArrayLen"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_65_expr_k), DafnyToSExpressionCompiler.__default.TypeToSexpr(_66_exprType), Std.Strings.__default.OfNat(_67_dim), Std.Strings.__default.OfBool(_68_native)));
        }
      }
      {
        if (_source0.is_MapKeys) {
          DAST._IExpression _69_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapKeys"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_69_expr_k)));
        }
      }
      {
        if (_source0.is_MapValues) {
          DAST._IExpression _70_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValues"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_70_expr_k)));
        }
      }
      {
        if (_source0.is_MapItems) {
          DAST._IExpression _71_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapItems"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_71_expr_k)));
        }
      }
      {
        if (_source0.is_Select) {
          DAST._IExpression _72_expr_k = _source0.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _73_field = _source0.dtor_field;
          DAST._IFieldMutability _74_fieldMutability = _source0.dtor_fieldMutability;
          DAST._ISelectContext _75_selectContext = _source0.dtor_selectContext;
          DAST._IType _76_fieldType = _source0.dtor_isfieldType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_72_expr_k), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_73_field), DafnyToSExpressionCompiler.__default.FieldMutabilityToSexpr(_74_fieldMutability), DafnyToSExpressionCompiler.__default.SelectContextToSexpr(_75_selectContext), DafnyToSExpressionCompiler.__default.TypeToSexpr(_76_fieldType)));
        }
      }
      {
        if (_source0.is_SelectFn) {
          DAST._IExpression _77_expr_k = _source0.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _78_field = _source0.dtor_field;
          bool _79_onDatatype = _source0.dtor_onDatatype;
          bool _80_isStatic = _source0.dtor_isStatic;
          bool _81_isConstant = _source0.dtor_isConstant;
          Dafny.ISequence<DAST._IType> _82_arguments = _source0.dtor_arguments;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SelectFn"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_77_expr_k), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_78_field), Std.Strings.__default.OfBool(_79_onDatatype), Std.Strings.__default.OfBool(_80_isStatic), Std.Strings.__default.OfBool(_81_isConstant), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _82_arguments)));
        }
      }
      {
        if (_source0.is_Index) {
          DAST._IExpression _83_expr_k = _source0.dtor_expr;
          DAST._ICollKind _84_collKind = _source0.dtor_collKind;
          Dafny.ISequence<DAST._IExpression> _85_indices = _source0.dtor_indices;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_83_expr_k), DafnyToSExpressionCompiler.__default.CollKindToSexpr(_84_collKind), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_85_indices)));
        }
      }
      {
        if (_source0.is_IndexRange) {
          DAST._IExpression _86_expr_k = _source0.dtor_expr;
          bool _87_isArray = _source0.dtor_isArray;
          Std.Wrappers._IOption<DAST._IExpression> _88_low = _source0.dtor_low;
          Std.Wrappers._IOption<DAST._IExpression> _89_high = _source0.dtor_high;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IndexRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_86_expr_k), Std.Strings.__default.OfBool(_87_isArray), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_88_low, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_90_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_91_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_91_x);
          })))(expr)), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_89_high, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_92_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_93_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_93_x);
          })))(expr))));
        }
      }
      {
        if (_source0.is_TupleSelect) {
          DAST._IExpression _94_expr_k = _source0.dtor_expr;
          BigInteger _95_index = _source0.dtor_index;
          DAST._IType _96_fieldType = _source0.dtor_fieldType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TupleSelect"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_94_expr_k), Std.Strings.__default.OfNat(_95_index), DafnyToSExpressionCompiler.__default.TypeToSexpr(_96_fieldType)));
        }
      }
      {
        if (_source0.is_Call) {
          DAST._IExpression _97_on = _source0.dtor_on;
          DAST._ICallName _98_callName = _source0.dtor_callName;
          Dafny.ISequence<DAST._IType> _99_typeArgs = _source0.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _100_args = _source0.dtor_args;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Call"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_97_on), DafnyToSExpressionCompiler.__default.CallNameToSexpr(_98_callName), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _99_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_100_args)));
        }
      }
      {
        if (_source0.is_Lambda) {
          Dafny.ISequence<DAST._IFormal> _101_params = _source0.dtor_params;
          DAST._IType _102_retType = _source0.dtor_retType;
          Dafny.ISequence<DAST._IStatement> _103_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Lambda"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _101_params), DafnyToSExpressionCompiler.__default.TypeToSexpr(_102_retType), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_103_body)));
        }
      }
      {
        if (_source0.is_BetaRedex) {
          Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>> _104_values = _source0.dtor_values;
          DAST._IType _105_retType = _source0.dtor_retType;
          DAST._IExpression _106_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BetaRedex"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IFormal, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_107_values, _108_expr) => ((System.Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_109_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IFormal, DAST._IExpression>(_109_x, DafnyToSExpressionCompiler.__default.FormalToSexpr, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_110_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_111_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_111_z);
            })))(_108_expr));
          })))(_104_values, expr), _104_values), DafnyToSExpressionCompiler.__default.TypeToSexpr(_105_retType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_106_expr_k)));
        }
      }
      {
        if (_source0.is_IIFE) {
          Dafny.ISequence<Dafny.Rune> _112_name = _source0.dtor_ident;
          DAST._IType _113_typ = _source0.dtor_typ;
          DAST._IExpression _114_value = _source0.dtor_value;
          DAST._IExpression _115_iifeBody = _source0.dtor_iifeBody;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IIFE"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_112_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_113_typ), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_114_value), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_115_iifeBody)));
        }
      }
      {
        if (_source0.is_Apply) {
          DAST._IExpression _116_expr_k = _source0.dtor_expr;
          Dafny.ISequence<DAST._IExpression> _117_args = _source0.dtor_args;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Apply"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_116_expr_k), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_117_args)));
        }
      }
      {
        if (_source0.is_TypeTest) {
          DAST._IExpression _118_on = _source0.dtor_on;
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _119_dType = _source0.dtor_dType;
          Dafny.ISequence<Dafny.Rune> _120_variant = _source0.dtor_variant;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TypeTest"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_118_on), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _119_dType), DafnyToSExpressionCompiler.__default.NameToSexpr(_120_variant)));
        }
      }
      {
        if (_source0.is_Is) {
          DAST._IExpression _121_expr_k = _source0.dtor_expr;
          DAST._IType _122_fromType = _source0.dtor_fromType;
          DAST._IType _123_toType = _source0.dtor_toType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Is"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_121_expr_k), DafnyToSExpressionCompiler.__default.TypeToSexpr(_122_fromType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_123_toType)));
        }
      }
      {
        if (_source0.is_InitializationValue) {
          DAST._IType _124_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.InitializationValue"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_124_typ)));
        }
      }
      {
        if (_source0.is_BoolBoundedPool) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BoolBoundedPool")));
        }
      }
      {
        if (_source0.is_SetBoundedPool) {
          DAST._IExpression _125_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_125_of)));
        }
      }
      {
        if (_source0.is_MapBoundedPool) {
          DAST._IExpression _126_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_126_of)));
        }
      }
      {
        if (_source0.is_SeqBoundedPool) {
          DAST._IExpression _127_of = _source0.dtor_of;
          bool _128_includeDuplicates = _source0.dtor_includeDuplicates;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_127_of), Std.Strings.__default.OfBool(_128_includeDuplicates)));
        }
      }
      {
        if (_source0.is_MultisetBoundedPool) {
          DAST._IExpression _129_of = _source0.dtor_of;
          bool _130_includeDuplicates = _source0.dtor_includeDuplicates;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MultisetBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_129_of), Std.Strings.__default.OfBool(_130_includeDuplicates)));
        }
      }
      {
        if (_source0.is_ExactBoundedPool) {
          DAST._IExpression _131_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ExactBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_131_of)));
        }
      }
      {
        if (_source0.is_IntRange) {
          DAST._IType _132_elemType = _source0.dtor_elemType;
          DAST._IExpression _133_lo = _source0.dtor_lo;
          DAST._IExpression _134_hi = _source0.dtor_hi;
          bool _135_up = _source0.dtor_up;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IntRange"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_132_elemType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_133_lo), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_134_hi), Std.Strings.__default.OfBool(_135_up)));
        }
      }
      {
        if (_source0.is_UnboundedIntRange) {
          DAST._IExpression _136_start = _source0.dtor_start;
          bool _137_up = _source0.dtor_up;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.UnboundedIntRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_136_start), Std.Strings.__default.OfBool(_137_up)));
        }
      }
      {
        DAST._IType _138_elemType = _source0.dtor_elemType;
        DAST._IExpression _139_collection = _source0.dtor_collection;
        bool _140_is__forall = _source0.dtor_is__forall;
        DAST._IExpression _141_lambda = _source0.dtor_lambda;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Quantifier"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_138_elemType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_139_collection), Std.Strings.__default.OfBool(_140_is__forall), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_141_lambda)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinExpressionToSexpr(Dafny.ISequence<DAST._IExpression> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IExpression>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_0_ts) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_1_x) => {
        return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> FieldMutabilityToSexpr(DAST._IFieldMutability fm) {
      DAST._IFieldMutability _source0 = fm;
      {
        if (_source0.is_ConstantField) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("FieldMutability.ConstantField")));
        }
      }
      {
        if (_source0.is_InternalClassConstantFieldOrDatatypeDestructor) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("FieldMutability.InternalClassConstantFieldOrDatatypeDestructor")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("FieldMutability.ClassMutableField")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> UnaryOpToSexpr(DAST._IUnaryOp unOp) {
      DAST._IUnaryOp _source0 = unOp;
      {
        if (_source0.is_Not) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.Not")));
        }
      }
      {
        if (_source0.is_BitwiseNot) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.BitwiseNot")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.Cardinality")));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> LiteralToSexpr(DAST._ILiteral literal) {
      DAST._ILiteral _source0 = literal;
      {
        if (_source0.is_BoolLiteral) {
          bool _0_b = _source0.dtor_BoolLiteral_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.BoolLiteral"), Std.Strings.__default.OfBool(_0_b)));
        }
      }
      {
        if (_source0.is_IntLiteral) {
          Dafny.ISequence<Dafny.Rune> _1_str = _source0.dtor_IntLiteral_a0;
          DAST._IType _2_t = _source0.dtor_IntLiteral_a1;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.IntLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_str), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2_t)));
        }
      }
      {
        if (_source0.is_DecLiteral) {
          Dafny.ISequence<Dafny.Rune> _3_str1 = _source0.dtor_DecLiteral_a0;
          Dafny.ISequence<Dafny.Rune> _4_str2 = _source0.dtor_DecLiteral_a1;
          DAST._IType _5_t = _source0.dtor_DecLiteral_a2;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.DecLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_3_str1), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_4_str2), DafnyToSExpressionCompiler.__default.TypeToSexpr(_5_t)));
        }
      }
      {
        if (_source0.is_StringLiteral) {
          Dafny.ISequence<Dafny.Rune> _6_str = _source0.dtor_StringLiteral_a0;
          bool _7_verbatim = _source0.dtor_verbatim;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.StringLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_6_str), Std.Strings.__default.OfBool(_7_verbatim)));
        }
      }
      {
        if (_source0.is_CharLiteral) {
          Dafny.Rune _8_c = _source0.dtor_CharLiteral_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.CharLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(Std.Strings.__default.OfChar(_8_c))));
        }
      }
      {
        if (_source0.is_CharLiteralUTF16) {
          BigInteger _9_n = _source0.dtor_CharLiteralUTF16_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.CharLiteralUTF16"), Std.Strings.__default.OfNat(_9_n)));
        }
      }
      {
        DAST._IType _10_t = _source0.dtor_Null_a0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.Null"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_10_t)));
      }
    }
  }
} // end of namespace DafnyToSExpressionCompiler