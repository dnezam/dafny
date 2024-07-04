// Dafny program the_program compiled into C#
// To recompile, you will need the libraries
//     System.Runtime.Numerics.dll System.Collections.Immutable.dll
// but the 'dotnet' tool in net6.0 should pick those up automatically.
// Optionally, you may want to include compiler switches like
//     /debug /nowarn:162,164,168,183,219,436,1717,1718

using System;
using System.Numerics;
using System.Collections;

namespace DafnyToSExpressionCompiler {

  public partial class __default {
    public static Dafny.ISequence<Dafny.Rune> EmitCallToMain(Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> fullName)
    {
      Dafny.ISequence<Dafny.Rune> s = Dafny.Sequence<Dafny.Rune>.Empty;
      s = Dafny.Sequence<Dafny.Rune>.UnicodeFromString("");
      return s;
    }
    public static Dafny.ISequence<Dafny.Rune> Compile(Dafny.ISequence<DAST._IModule> p)
    {
      Dafny.ISequence<Dafny.Rune> s = Dafny.Sequence<Dafny.Rune>.Empty;
      s = DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Program"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IModule>(DafnyToSExpressionCompiler.__default.ModuleToSexpr, p)));
      return s;
    }
    public static Dafny.ISequence<Dafny.Rune> ModuleToSexpr(DAST._IModule mod) {
      var _pat_let_tv102 = mod;
      DAST._IModule _source81 = mod;
      bool unmatched81 = true;
      if (unmatched81) {
        Dafny.ISequence<Dafny.Rune> _1875_name = _source81.dtor_name;
        Dafny.ISequence<DAST._IAttribute> _1876_attributes = _source81.dtor_attributes;
        Std.Wrappers._IOption<Dafny.ISequence<DAST._IModuleItem>> _1877_body = _source81.dtor_body;
        unmatched81 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Module.Module"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1875_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1876_attributes), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<DAST._IModuleItem>>(_1877_body, Dafny.Helpers.Id<Func<DAST._IModule, Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>>>((_1878_mod) => ((System.Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>)((_1879_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IModuleItem>(Dafny.Helpers.Id<Func<DAST._IModule, Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>>>((_1880_mod) => ((System.Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>)((_1881_i) => {
            return DafnyToSExpressionCompiler.__default.ModuleItemToSexpr(_1881_i);
          })))(_1878_mod), _1879_x);
        })))(_pat_let_tv102))));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> NameToSexpr(Dafny.ISequence<Dafny.Rune> name) {
      Dafny.ISequence<Dafny.Rune> _source82 = name;
      bool unmatched82 = true;
      if (unmatched82) {
        Dafny.ISequence<Dafny.Rune> _1882_dafny__name = _source82;
        unmatched82 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Name.Name"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1882_dafny__name)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> AttributeToSexpr(DAST._IAttribute attribute) {
      DAST._IAttribute _source83 = attribute;
      bool unmatched83 = true;
      if (unmatched83) {
        Dafny.ISequence<Dafny.Rune> _1883_name = _source83.dtor_name;
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1884_args = _source83.dtor_args;
        unmatched83 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Attribute.Attribute"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1883_name), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.EscapeAndQuote, _1884_args)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> ModuleItemToSexpr(DAST._IModuleItem modItem)
    {
      DAST._IModuleItem _source84 = modItem;
      bool unmatched84 = true;
      if (unmatched84) {
        if (_source84.is_Module) {
          DAST._IModule _1885_mod = _source84.dtor_Module_a0;
          unmatched84 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Module"), DafnyToSExpressionCompiler.__default.ModuleToSexpr(_1885_mod)));
        }
      }
      if (unmatched84) {
        if (_source84.is_Class) {
          DAST._IClass _1886_cls = _source84.dtor_Class_a0;
          unmatched84 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Class"), DafnyToSExpressionCompiler.__default.ClassToSexpr(_1886_cls)));
        }
      }
      if (unmatched84) {
        if (_source84.is_Trait) {
          DAST._ITrait _1887_trt = _source84.dtor_Trait_a0;
          unmatched84 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Trait"), DafnyToSExpressionCompiler.__default.TraitToSexpr(_1887_trt)));
        }
      }
      if (unmatched84) {
        if (_source84.is_Newtype) {
          DAST._INewtype _1888_nt = _source84.dtor_Newtype_a0;
          unmatched84 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Newtype"), DafnyToSExpressionCompiler.__default.NewtypeToSexpr(_1888_nt)));
        }
      }
      if (unmatched84) {
        DAST._IDatatype _1889_dt = _source84.dtor_Datatype_a0;
        unmatched84 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ModuleItem.Datatype"), DafnyToSExpressionCompiler.__default.DatatypeToSexpr(_1889_dt)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> ClassToSexpr(DAST._IClass cls) {
      DAST._IClass _source85 = cls;
      bool unmatched85 = true;
      if (unmatched85) {
        Dafny.ISequence<Dafny.Rune> _1890_name = _source85.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1891_enclosingModule = _source85.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _1892_typeParams = _source85.dtor_typeParams;
        Dafny.ISequence<DAST._IType> _1893_superClasses = _source85.dtor_superClasses;
        Dafny.ISequence<DAST._IField> _1894_fields = _source85.dtor_fields;
        Dafny.ISequence<DAST._IMethod> _1895_body = _source85.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _1896_attributes = _source85.dtor_attributes;
        unmatched85 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Class.Class"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1890_name), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1891_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1892_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _1893_superClasses), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IField>(DafnyToSExpressionCompiler.__default.FieldToSexpr, _1894_fields), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _1895_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1896_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> TraitToSexpr(DAST._ITrait trt) {
      DAST._ITrait _source86 = trt;
      bool unmatched86 = true;
      if (unmatched86) {
        Dafny.ISequence<Dafny.Rune> _1897_name = _source86.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _1898_typeParams = _source86.dtor_typeParams;
        Dafny.ISequence<DAST._IMethod> _1899_body = _source86.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _1900_attributes = _source86.dtor_attributes;
        unmatched86 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Trait.Trait"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1897_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1898_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _1899_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1900_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeToSexpr(DAST._INewtype nt) {
      DAST._INewtype _source87 = nt;
      bool unmatched87 = true;
      if (unmatched87) {
        Dafny.ISequence<Dafny.Rune> _1901_name = _source87.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _1902_typeParams = _source87.dtor_typeParams;
        DAST._IType _1903_base = _source87.dtor_base;
        DAST._INewtypeRange _1904_range = _source87.dtor_range;
        Dafny.ISequence<DAST._IStatement> _1905_witnessStmts = _source87.dtor_witnessStmts;
        Std.Wrappers._IOption<DAST._IExpression> _1906_witnessExpr = _source87.dtor_witnessExpr;
        Dafny.ISequence<DAST._IAttribute> _1907_attributes = _source87.dtor_attributes;
        unmatched87 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Newtype.Newtype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1901_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1902_typeParams), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1903_base), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_1904_range), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _1905_witnessStmts), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_1906_witnessExpr, DafnyToSExpressionCompiler.__default.ExpressionToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1907_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeToSexpr(DAST._IDatatype dt) {
      DAST._IDatatype _source88 = dt;
      bool unmatched88 = true;
      if (unmatched88) {
        Dafny.ISequence<Dafny.Rune> _1908_name = _source88.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1909_enclosingModule = _source88.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _1910_typeParams = _source88.dtor_typeParams;
        Dafny.ISequence<DAST._IDatatypeCtor> _1911_ctors = _source88.dtor_ctors;
        Dafny.ISequence<DAST._IMethod> _1912_body = _source88.dtor_body;
        bool _1913_isCo = _source88.dtor_isCo;
        Dafny.ISequence<DAST._IAttribute> _1914_attributes = _source88.dtor_attributes;
        unmatched88 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Datatype.Datatype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1908_name), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1909_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1910_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeCtor>(DafnyToSExpressionCompiler.__default.DatatypeCtorToSexpr, _1911_ctors), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _1912_body), Std.Strings.__default.OfBool(_1913_isCo), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1914_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> IdentToSexpr(Dafny.ISequence<Dafny.Rune> ident) {
      Dafny.ISequence<Dafny.Rune> _source89 = ident;
      bool unmatched89 = true;
      if (unmatched89) {
        Dafny.ISequence<Dafny.Rune> _1915_id = _source89;
        unmatched89 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Ident.Ident"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1915_id)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> TypeArgDeclToSexpr(DAST._ITypeArgDecl typeArgDecl) {
      DAST._ITypeArgDecl _source90 = typeArgDecl;
      bool unmatched90 = true;
      if (unmatched90) {
        Dafny.ISequence<Dafny.Rune> _1916_name = _source90.dtor_name;
        Dafny.ISequence<DAST._ITypeArgBound> _1917_bounds = _source90.dtor_bounds;
        unmatched90 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgDecl.TypeArgDecl"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1916_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgBound>(DafnyToSExpressionCompiler.__default.TypeArgBoundToSexpr, _1917_bounds)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> TypeToSexpr(DAST._IType t) {
      DAST._IType _source91 = t;
      bool unmatched91 = true;
      if (unmatched91) {
        if (_source91.is_Path) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1918_ids = _source91.dtor_Path_a0;
          Dafny.ISequence<DAST._IType> _1919_typeArgs = _source91.dtor_typeArgs;
          DAST._IResolvedType _1920_resolved = _source91.dtor_resolved;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Path"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _1918_ids), DafnyToSExpressionCompiler.__default.MapJoinTypeToSexpr(_1919_typeArgs), DafnyToSExpressionCompiler.__default.ResolvedTypeToSexpr(_1920_resolved)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Nullable) {
          DAST._IType _1921_t_k = _source91.dtor_Nullable_a0;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Nullable"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1921_t_k)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Tuple) {
          Dafny.ISequence<DAST._IType> _1922_ts = _source91.dtor_Tuple_a0;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Tuple"), DafnyToSExpressionCompiler.__default.MapJoinTypeToSexpr(_1922_ts)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Array) {
          DAST._IType _1923_element = _source91.dtor_element;
          BigInteger _1924_dims = _source91.dtor_dims;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Array"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1923_element), Std.Strings.__default.OfNat(_1924_dims)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Seq) {
          DAST._IType _1925_element = _source91.dtor_element;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Seq"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1925_element)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Set) {
          DAST._IType _1926_element = _source91.dtor_element;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Set"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1926_element)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Multiset) {
          DAST._IType _1927_element = _source91.dtor_element;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Multiset"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1927_element)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Map) {
          DAST._IType _1928_key = _source91.dtor_key;
          DAST._IType _1929_value = _source91.dtor_value;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Map"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1928_key), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1929_value)));
        }
      }
      if (unmatched91) {
        if (_source91.is_SetBuilder) {
          DAST._IType _1930_element = _source91.dtor_element;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.SetBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1930_element)));
        }
      }
      if (unmatched91) {
        if (_source91.is_MapBuilder) {
          DAST._IType _1931_key = _source91.dtor_key;
          DAST._IType _1932_value = _source91.dtor_value;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.MapBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1931_key), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1932_value)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Arrow) {
          Dafny.ISequence<DAST._IType> _1933_args = _source91.dtor_args;
          DAST._IType _1934_result = _source91.dtor_result;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Arrow"), DafnyToSExpressionCompiler.__default.MapJoinTypeToSexpr(_1933_args), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1934_result)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Primitive) {
          DAST._IPrimitive _1935_primitive = _source91.dtor_Primitive_a0;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Primitive"), DafnyToSExpressionCompiler.__default.PrimitiveToSexpr(_1935_primitive)));
        }
      }
      if (unmatched91) {
        if (_source91.is_Passthrough) {
          Dafny.ISequence<Dafny.Rune> _1936_str = _source91.dtor_Passthrough_a0;
          unmatched91 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.Passthrough"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1936_str)));
        }
      }
      if (unmatched91) {
        Dafny.ISequence<Dafny.Rune> _1937_id = _source91.dtor_TypeArg_a0;
        unmatched91 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Type.TypeArg"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1937_id)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinTypeToSexpr(Dafny.ISequence<DAST._IType> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IType>, Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>>>((_1938_ts) => ((System.Func<DAST._IType, Dafny.ISequence<Dafny.Rune>>)((_1939_x) => {
        return DafnyToSExpressionCompiler.__default.TypeToSexpr(_1939_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> FieldToSexpr(DAST._IField field) {
      DAST._IField _source92 = field;
      bool unmatched92 = true;
      if (unmatched92) {
        DAST._IFormal _1940_formal = _source92.dtor_formal;
        Std.Wrappers._IOption<DAST._IExpression> _1941_defaultValue = _source92.dtor_defaultValue;
        unmatched92 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Field.Field"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_1940_formal), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_1941_defaultValue, DafnyToSExpressionCompiler.__default.ExpressionToSexpr)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> ClassItemToSexpr(DAST._IMethod classItem) {
      DAST._IMethod _source93 = classItem;
      bool unmatched93 = true;
      if (unmatched93) {
        DAST._IMethod _1942_m = _source93;
        unmatched93 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ClassItem.Method"), DafnyToSExpressionCompiler.__default.MethodToSexpr(_1942_m)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeRangeToSexpr(DAST._INewtypeRange range) {
      DAST._INewtypeRange _source94 = range;
      bool unmatched94 = true;
      if (unmatched94) {
        if (_source94.is_U8) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U8")));
        }
      }
      if (unmatched94) {
        if (_source94.is_I8) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I8")));
        }
      }
      if (unmatched94) {
        if (_source94.is_U16) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U16")));
        }
      }
      if (unmatched94) {
        if (_source94.is_I16) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I16")));
        }
      }
      if (unmatched94) {
        if (_source94.is_U32) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U32")));
        }
      }
      if (unmatched94) {
        if (_source94.is_I32) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I32")));
        }
      }
      if (unmatched94) {
        if (_source94.is_U64) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U64")));
        }
      }
      if (unmatched94) {
        if (_source94.is_I64) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I64")));
        }
      }
      if (unmatched94) {
        if (_source94.is_U128) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U128")));
        }
      }
      if (unmatched94) {
        if (_source94.is_I128) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I128")));
        }
      }
      if (unmatched94) {
        if (_source94.is_BigInt) {
          unmatched94 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.BigInt")));
        }
      }
      if (unmatched94) {
        unmatched94 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.NoRange")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> ExpressionToSexpr(DAST._IExpression expr) {
      var _pat_let_tv103 = expr;
      var _pat_let_tv104 = expr;
      var _pat_let_tv105 = expr;
      var _pat_let_tv106 = expr;
      var _pat_let_tv107 = expr;
      DAST._IExpression _source95 = expr;
      bool unmatched95 = true;
      if (unmatched95) {
        if (_source95.is_Literal) {
          DAST._ILiteral _1943_literal = _source95.dtor_Literal_a0;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Literal"), DafnyToSExpressionCompiler.__default.LiteralToSexpr(_1943_literal)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Ident) {
          Dafny.ISequence<Dafny.Rune> _1944_name = _source95.dtor_Ident_a0;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Ident"), DafnyToSExpressionCompiler.__default.NameToSexpr(_1944_name)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Companion) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1945_ids = _source95.dtor_Companion_a0;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Companion"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _1945_ids)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Tuple) {
          Dafny.ISequence<DAST._IExpression> _1946_exprs = _source95.dtor_Tuple_a0;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Tuple"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1946_exprs)));
        }
      }
      if (unmatched95) {
        if (_source95.is_New) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1947_path = _source95.dtor_path;
          Dafny.ISequence<DAST._IType> _1948_typeArgs = _source95.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _1949_args = _source95.dtor_args;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.New"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _1947_path), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _1948_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1949_args)));
        }
      }
      if (unmatched95) {
        if (_source95.is_NewArray) {
          Dafny.ISequence<DAST._IExpression> _1950_dims = _source95.dtor_dims;
          DAST._IType _1951_typ = _source95.dtor_typ;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.NewArray"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1950_dims), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1951_typ)));
        }
      }
      if (unmatched95) {
        if (_source95.is_DatatypeValue) {
          DAST._IDatatypeType _1952_datatypeType = _source95.dtor_datatypeType;
          Dafny.ISequence<DAST._IType> _1953_typeArgs = _source95.dtor_typeArgs;
          Dafny.ISequence<Dafny.Rune> _1954_variant = _source95.dtor_variant;
          bool _1955_isCo = _source95.dtor_isCo;
          Dafny.ISequence<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>> _1956_contents = _source95.dtor_contents;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.DatatypeValue"), DafnyToSExpressionCompiler.__default.DatatypeTypeToSexpr(_1952_datatypeType), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _1953_typeArgs), DafnyToSExpressionCompiler.__default.NameToSexpr(_1954_variant), Std.Strings.__default.OfBool(_1955_isCo), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_1957_contents, _1958_expr) => ((System.Func<_System._ITuple2<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_1959_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<Dafny.ISequence<Dafny.Rune>, DAST._IExpression>(_1959_x, DafnyToSExpressionCompiler.__default.EscapeAndQuote, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_1960_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_1961_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1961_z);
            })))(_1958_expr));
          })))(_1956_contents, _pat_let_tv103), _1956_contents)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Convert) {
          DAST._IExpression _1962_value = _source95.dtor_value;
          DAST._IType _1963_from = _source95.dtor_from;
          DAST._IType _1964_typ = _source95.dtor_typ;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Convert"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1962_value), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1963_from), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1964_typ)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SeqConstruct) {
          DAST._IExpression _1965_length = _source95.dtor_length;
          DAST._IExpression _1966_elem = _source95.dtor_elem;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqConstruct"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1965_length), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1966_elem)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SeqValue) {
          Dafny.ISequence<DAST._IExpression> _1967_elements = _source95.dtor_elements;
          DAST._IType _1968_typ = _source95.dtor_typ;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1967_elements), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1968_typ)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SetValue) {
          Dafny.ISequence<DAST._IExpression> _1969_elements = _source95.dtor_elements;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1969_elements)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MultisetValue) {
          Dafny.ISequence<DAST._IExpression> _1970_elements = _source95.dtor_elements;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MultisetValue"), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_1970_elements)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MapValue) {
          Dafny.ISequence<_System._ITuple2<DAST._IExpression, DAST._IExpression>> _1971_mapElems = _source95.dtor_mapElems;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValue"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IExpression, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IExpression, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_1972_mapElems, _1973_expr) => ((System.Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_1974_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IExpression, DAST._IExpression>(_1974_x, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_1975_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_1976_y) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1976_y);
            })))(_1973_expr), Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_1977_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_1978_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1978_z);
            })))(_1973_expr));
          })))(_1971_mapElems, _pat_let_tv104), _1971_mapElems)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MapBuilder) {
          DAST._IType _1979_keyType = _source95.dtor_keyType;
          DAST._IType _1980_valueType = _source95.dtor_valueType;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1979_keyType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1980_valueType)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SeqUpdate) {
          DAST._IExpression _1981_expr_k = _source95.dtor_expr;
          DAST._IExpression _1982_indexExpr = _source95.dtor_indexExpr;
          DAST._IExpression _1983_value = _source95.dtor_value;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1981_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1982_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1983_value)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MapUpdate) {
          DAST._IExpression _1984_expr_k = _source95.dtor_expr;
          DAST._IExpression _1985_indexExpr = _source95.dtor_indexExpr;
          DAST._IExpression _1986_value = _source95.dtor_value;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1984_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1985_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1986_value)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SetBuilder) {
          DAST._IType _1987_elemType = _source95.dtor_elemType;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1987_elemType)));
        }
      }
      if (unmatched95) {
        if (_source95.is_ToMultiset) {
          DAST._IExpression _1988_expr_k = _source95.dtor_ToMultiset_a0;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ToMultiset"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1988_expr_k)));
        }
      }
      if (unmatched95) {
        if (_source95.is_This) {
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.This")));
        }
      }
      if (unmatched95) {
        if (_source95.is_Ite) {
          DAST._IExpression _1989_cond = _source95.dtor_cond;
          DAST._IExpression _1990_thn = _source95.dtor_thn;
          DAST._IExpression _1991_els = _source95.dtor_els;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Ite"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1989_cond), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1990_thn), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1991_els)));
        }
      }
      if (unmatched95) {
        if (_source95.is_UnOp) {
          DAST._IUnaryOp _1992_unOp = _source95.dtor_unOp;
          DAST._IExpression _1993_expr_k = _source95.dtor_expr;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.UnOp"), DafnyToSExpressionCompiler.__default.UnaryOpToSexpr(_1992_unOp), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1993_expr_k)));
        }
      }
      if (unmatched95) {
        if (_source95.is_BinOp) {
          DAST._IBinOp _1994_op = _source95.dtor_op;
          DAST._IExpression _1995_left = _source95.dtor_left;
          DAST._IExpression _1996_right = _source95.dtor_right;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BinOp"), DafnyToSExpressionCompiler.__default.BinOpToSexpr(_1994_op), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1995_left), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1996_right)));
        }
      }
      if (unmatched95) {
        if (_source95.is_ArrayLen) {
          DAST._IExpression _1997_expr_k = _source95.dtor_expr;
          BigInteger _1998_dim = _source95.dtor_dim;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ArrayLen"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1997_expr_k), Std.Strings.__default.OfNat(_1998_dim)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MapKeys) {
          DAST._IExpression _1999_expr_k = _source95.dtor_expr;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapKeys"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1999_expr_k)));
        }
      }
      if (unmatched95) {
        if (_source95.is_MapValues) {
          DAST._IExpression _2000_expr_k = _source95.dtor_expr;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValues"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2000_expr_k)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Select) {
          DAST._IExpression _2001_expr_k = _source95.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _2002_field = _source95.dtor_field;
          bool _2003_isConstant = _source95.dtor_isConstant;
          bool _2004_onDatatype = _source95.dtor_onDatatype;
          DAST._IType _2005_fieldType = _source95.dtor_fieldType;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2001_expr_k), DafnyToSExpressionCompiler.__default.NameToSexpr(_2002_field), Std.Strings.__default.OfBool(_2003_isConstant), Std.Strings.__default.OfBool(_2004_onDatatype), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2005_fieldType)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SelectFn) {
          DAST._IExpression _2006_expr_k = _source95.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _2007_field = _source95.dtor_field;
          bool _2008_onDatatype = _source95.dtor_onDatatype;
          bool _2009_isStatic = _source95.dtor_isStatic;
          BigInteger _2010_arity = _source95.dtor_arity;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SelectFn"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2006_expr_k), DafnyToSExpressionCompiler.__default.NameToSexpr(_2007_field), Std.Strings.__default.OfBool(_2008_onDatatype), Std.Strings.__default.OfBool(_2009_isStatic), Std.Strings.__default.OfNat(_2010_arity)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Index) {
          DAST._IExpression _2011_expr_k = _source95.dtor_expr;
          DAST._ICollKind _2012_collKind = _source95.dtor_collKind;
          Dafny.ISequence<DAST._IExpression> _2013_indices = _source95.dtor_indices;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2011_expr_k), DafnyToSExpressionCompiler.__default.CollKindToSexpr(_2012_collKind), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_2013_indices)));
        }
      }
      if (unmatched95) {
        if (_source95.is_IndexRange) {
          DAST._IExpression _2014_expr_k = _source95.dtor_expr;
          bool _2015_isArray = _source95.dtor_isArray;
          Std.Wrappers._IOption<DAST._IExpression> _2016_low = _source95.dtor_low;
          Std.Wrappers._IOption<DAST._IExpression> _2017_high = _source95.dtor_high;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IndexRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2014_expr_k), Std.Strings.__default.OfBool(_2015_isArray), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_2016_low, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_2018_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_2019_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2019_x);
          })))(_pat_let_tv105)), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_2017_high, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_2020_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_2021_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2021_x);
          })))(_pat_let_tv106))));
        }
      }
      if (unmatched95) {
        if (_source95.is_TupleSelect) {
          DAST._IExpression _2022_expr_k = _source95.dtor_expr;
          BigInteger _2023_index = _source95.dtor_index;
          DAST._IType _2024_fieldType = _source95.dtor_fieldType;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TupleSelect"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2022_expr_k), Std.Strings.__default.OfNat(_2023_index), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2024_fieldType)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Call) {
          DAST._IExpression _2025_on = _source95.dtor_on;
          DAST._ICallName _2026_callName = _source95.dtor_callName;
          Dafny.ISequence<DAST._IType> _2027_typeArgs = _source95.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _2028_args = _source95.dtor_args;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Call"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2025_on), DafnyToSExpressionCompiler.__default.CallNameToSexpr(_2026_callName), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _2027_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_2028_args)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Lambda) {
          Dafny.ISequence<DAST._IFormal> _2029_params = _source95.dtor_params;
          DAST._IType _2030_retType = _source95.dtor_retType;
          Dafny.ISequence<DAST._IStatement> _2031_body = _source95.dtor_body;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Lambda"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _2029_params), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2030_retType), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2031_body)));
        }
      }
      if (unmatched95) {
        if (_source95.is_BetaRedex) {
          Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>> _2032_values = _source95.dtor_values;
          DAST._IType _2033_retType = _source95.dtor_retType;
          DAST._IExpression _2034_expr_k = _source95.dtor_expr;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BetaRedex"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IFormal, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_2035_values, _2036_expr) => ((System.Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_2037_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IFormal, DAST._IExpression>(_2037_x, DafnyToSExpressionCompiler.__default.FormalToSexpr, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_2038_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_2039_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2039_z);
            })))(_2036_expr));
          })))(_2032_values, _pat_let_tv107), _2032_values), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2033_retType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2034_expr_k)));
        }
      }
      if (unmatched95) {
        if (_source95.is_IIFE) {
          Dafny.ISequence<Dafny.Rune> _2040_name = _source95.dtor_name;
          DAST._IType _2041_typ = _source95.dtor_typ;
          DAST._IExpression _2042_value = _source95.dtor_value;
          DAST._IExpression _2043_iifeBody = _source95.dtor_iifeBody;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IIFE"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_2040_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2041_typ), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2042_value), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2043_iifeBody)));
        }
      }
      if (unmatched95) {
        if (_source95.is_Apply) {
          DAST._IExpression _2044_expr_k = _source95.dtor_expr;
          Dafny.ISequence<DAST._IExpression> _2045_args = _source95.dtor_args;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Apply"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2044_expr_k), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_2045_args)));
        }
      }
      if (unmatched95) {
        if (_source95.is_TypeTest) {
          DAST._IExpression _2046_on = _source95.dtor_on;
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _2047_dType = _source95.dtor_dType;
          Dafny.ISequence<Dafny.Rune> _2048_variant = _source95.dtor_variant;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TypeTest"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2046_on), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2047_dType), DafnyToSExpressionCompiler.__default.NameToSexpr(_2048_variant)));
        }
      }
      if (unmatched95) {
        if (_source95.is_InitializationValue) {
          DAST._IType _2049_typ = _source95.dtor_typ;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.InitializationValue"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2049_typ)));
        }
      }
      if (unmatched95) {
        if (_source95.is_BoolBoundedPool) {
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BoolBoundedPool")));
        }
      }
      if (unmatched95) {
        if (_source95.is_SetBoundedPool) {
          DAST._IExpression _2050_of = _source95.dtor_of;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2050_of)));
        }
      }
      if (unmatched95) {
        if (_source95.is_SeqBoundedPool) {
          DAST._IExpression _2051_of = _source95.dtor_of;
          bool _2052_includeDuplicates = _source95.dtor_includeDuplicates;
          unmatched95 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2051_of), Std.Strings.__default.OfBool(_2052_includeDuplicates)));
        }
      }
      if (unmatched95) {
        DAST._IExpression _2053_lo = _source95.dtor_lo;
        DAST._IExpression _2054_hi = _source95.dtor_hi;
        unmatched95 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IntRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2053_lo), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2054_hi)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinExpressionToSexpr(Dafny.ISequence<DAST._IExpression> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IExpression>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_2055_ts) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_2056_x) => {
        return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2056_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> StatementToSexpr(DAST._IStatement stmt) {
      DAST._IStatement _source96 = stmt;
      bool unmatched96 = true;
      if (unmatched96) {
        if (_source96.is_DeclareVar) {
          Dafny.ISequence<Dafny.Rune> _2057_name = _source96.dtor_name;
          DAST._IType _2058_typ = _source96.dtor_typ;
          Std.Wrappers._IOption<DAST._IExpression> _2059_maybeValue = _source96.dtor_maybeValue;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.DeclareVar"), DafnyToSExpressionCompiler.__default.NameToSexpr(_2057_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2058_typ), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_2059_maybeValue, Dafny.Helpers.Id<Func<Std.Wrappers._IOption<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_2060_maybeValue) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_2061_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2061_x);
          })))(_2059_maybeValue))));
        }
      }
      if (unmatched96) {
        if (_source96.is_Assign) {
          DAST._IAssignLhs _2062_lhs = _source96.dtor_lhs;
          DAST._IExpression _2063_value = _source96.dtor_value;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Assign"), DafnyToSExpressionCompiler.__default.AssignLhsToSexpr(_2062_lhs), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2063_value)));
        }
      }
      if (unmatched96) {
        if (_source96.is_If) {
          DAST._IExpression _2064_cond = _source96.dtor_cond;
          Dafny.ISequence<DAST._IStatement> _2065_thn = _source96.dtor_thn;
          Dafny.ISequence<DAST._IStatement> _2066_els = _source96.dtor_els;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.If"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2064_cond), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2065_thn), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2066_els)));
        }
      }
      if (unmatched96) {
        if (_source96.is_Labeled) {
          Dafny.ISequence<Dafny.Rune> _2067_lbl = _source96.dtor_lbl;
          Dafny.ISequence<DAST._IStatement> _2068_body = _source96.dtor_body;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Labeled"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2067_lbl), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2068_body)));
        }
      }
      if (unmatched96) {
        if (_source96.is_While) {
          DAST._IExpression _2069_cond = _source96.dtor_cond;
          Dafny.ISequence<DAST._IStatement> _2070_body = _source96.dtor_body;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.While"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2069_cond), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2070_body)));
        }
      }
      if (unmatched96) {
        if (_source96.is_Foreach) {
          Dafny.ISequence<Dafny.Rune> _2071_boundName = _source96.dtor_boundName;
          DAST._IType _2072_boundType = _source96.dtor_boundType;
          DAST._IExpression _2073_over = _source96.dtor_over;
          Dafny.ISequence<DAST._IStatement> _2074_body = _source96.dtor_body;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Foreach"), DafnyToSExpressionCompiler.__default.NameToSexpr(_2071_boundName), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2072_boundType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2073_over), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2074_body)));
        }
      }
      if (unmatched96) {
        if (_source96.is_Call) {
          DAST._IExpression _2075_on = _source96.dtor_on;
          DAST._ICallName _2076_callName = _source96.dtor_callName;
          Dafny.ISequence<DAST._IType> _2077_typeArgs = _source96.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _2078_args = _source96.dtor_args;
          Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _2079_outs = _source96.dtor_outs;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Call"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2075_on), DafnyToSExpressionCompiler.__default.CallNameToSexpr(_2076_callName), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _2077_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_2078_args), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_2079_outs, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_2080_x) => {
            return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2080_x);
          })))));
        }
      }
      if (unmatched96) {
        if (_source96.is_Return) {
          DAST._IExpression _2081_expr = _source96.dtor_expr;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Return"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2081_expr)));
        }
      }
      if (unmatched96) {
        if (_source96.is_EarlyReturn) {
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.EarlyReturn")));
        }
      }
      if (unmatched96) {
        if (_source96.is_Break) {
          Std.Wrappers._IOption<Dafny.ISequence<Dafny.Rune>> _2082_toLabel = _source96.dtor_toLabel;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Break"), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.Rune>>(_2082_toLabel, DafnyToSExpressionCompiler.__default.EscapeAndQuote)));
        }
      }
      if (unmatched96) {
        if (_source96.is_TailRecursive) {
          Dafny.ISequence<DAST._IStatement> _2083_body = _source96.dtor_body;
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.TailRecursive"), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_2083_body)));
        }
      }
      if (unmatched96) {
        if (_source96.is_JumpTailCallStart) {
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.JumpTailCallStart")));
        }
      }
      if (unmatched96) {
        if (_source96.is_Halt) {
          unmatched96 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Halt")));
        }
      }
      if (unmatched96) {
        DAST._IExpression _2084_expr = _source96.dtor_Print_a0;
        unmatched96 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.Print"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2084_expr)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinStatementToSexpr(Dafny.ISequence<DAST._IStatement> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IStatement>, Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>>>((_2085_ts) => ((System.Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>)((_2086_x) => {
        return DafnyToSExpressionCompiler.__default.StatementToSexpr(_2086_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeCtorToSexpr(DAST._IDatatypeCtor datatypeCtor) {
      DAST._IDatatypeCtor _source97 = datatypeCtor;
      bool unmatched97 = true;
      if (unmatched97) {
        Dafny.ISequence<Dafny.Rune> _2087_name = _source97.dtor_name;
        Dafny.ISequence<DAST._IDatatypeDtor> _2088_args = _source97.dtor_args;
        bool _2089_hasAnyArgs = _source97.dtor_hasAnyArgs;
        unmatched97 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeCtor.DatatypeCtor"), DafnyToSExpressionCompiler.__default.NameToSexpr(_2087_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeDtor>(DafnyToSExpressionCompiler.__default.DatatypeDtorToSexpr, _2088_args), Std.Strings.__default.OfBool(_2089_hasAnyArgs)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> TypeArgBoundToSexpr(DAST._ITypeArgBound typeArgBound) {
      DAST._ITypeArgBound _source98 = typeArgBound;
      bool unmatched98 = true;
      if (unmatched98) {
        if (_source98.is_SupportsEquality) {
          unmatched98 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.SupportsEquality")));
        }
      }
      if (unmatched98) {
        unmatched98 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.SupportsDefault")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> FormalToSexpr(DAST._IFormal formal) {
      DAST._IFormal _source99 = formal;
      bool unmatched99 = true;
      if (unmatched99) {
        Dafny.ISequence<Dafny.Rune> _2090_name = _source99.dtor_name;
        DAST._IType _2091_typ = _source99.dtor_typ;
        Dafny.ISequence<DAST._IAttribute> _2092_attributes = _source99.dtor_attributes;
        unmatched99 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Formal.Formal"), DafnyToSExpressionCompiler.__default.NameToSexpr(_2090_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2091_typ), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2092_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> ResolvedTypeToSexpr(DAST._IResolvedType resolvedType) {
      DAST._IResolvedType _source100 = resolvedType;
      bool unmatched100 = true;
      if (unmatched100) {
        if (_source100.is_Datatype) {
          DAST._IDatatypeType _2093_datatypeType = _source100.dtor_datatypeType;
          unmatched100 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedType.Datatype"), DafnyToSExpressionCompiler.__default.DatatypeTypeToSexpr(_2093_datatypeType)));
        }
      }
      if (unmatched100) {
        if (_source100.is_Trait) {
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _2094_path = _source100.dtor_path;
          Dafny.ISequence<DAST._IAttribute> _2095_attributes = _source100.dtor_attributes;
          unmatched100 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedType.Trait"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2094_path), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2095_attributes)));
        }
      }
      if (unmatched100) {
        DAST._IType _2096_baseType = _source100.dtor_baseType;
        DAST._INewtypeRange _2097_range = _source100.dtor_range;
        bool _2098_erase = _source100.dtor_erase;
        Dafny.ISequence<DAST._IAttribute> _2099_attributes = _source100.dtor_attributes;
        unmatched100 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedType.Newtype"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2096_baseType), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_2097_range), Std.Strings.__default.OfBool(_2098_erase), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2099_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> PrimitiveToSexpr(DAST._IPrimitive primitive) {
      DAST._IPrimitive _source101 = primitive;
      bool unmatched101 = true;
      if (unmatched101) {
        if (_source101.is_Int) {
          unmatched101 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Int")));
        }
      }
      if (unmatched101) {
        if (_source101.is_Real) {
          unmatched101 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Real")));
        }
      }
      if (unmatched101) {
        if (_source101.is_String) {
          unmatched101 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.String")));
        }
      }
      if (unmatched101) {
        if (_source101.is_Bool) {
          unmatched101 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Bool")));
        }
      }
      if (unmatched101) {
        unmatched101 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Primitive.Char")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> MethodToSexpr(DAST._IMethod m) {
      DAST._IMethod _source102 = m;
      bool unmatched102 = true;
      if (unmatched102) {
        bool _2100_isStatic = _source102.dtor_isStatic;
        bool _2101_hasBody = _source102.dtor_hasBody;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _2102_overridingPath = _source102.dtor_overridingPath;
        Dafny.ISequence<Dafny.Rune> _2103_name = _source102.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _2104_typeParams = _source102.dtor_typeParams;
        Dafny.ISequence<DAST._IFormal> _2105_params = _source102.dtor_params;
        Dafny.ISequence<DAST._IStatement> _2106_body = _source102.dtor_body;
        Dafny.ISequence<DAST._IType> _2107_outTypes = _source102.dtor_outTypes;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _2108_outVars = _source102.dtor_outVars;
        unmatched102 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Method.Method"), Std.Strings.__default.OfBool(_2100_isStatic), Std.Strings.__default.OfBool(_2101_hasBody), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_2102_overridingPath, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_2109_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2109_x);
        }))), DafnyToSExpressionCompiler.__default.NameToSexpr(_2103_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2104_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _2105_params), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _2106_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _2107_outTypes), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_2108_outVars, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_2110_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2110_x);
        })))));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> LiteralToSexpr(DAST._ILiteral literal) {
      DAST._ILiteral _source103 = literal;
      bool unmatched103 = true;
      if (unmatched103) {
        if (_source103.is_BoolLiteral) {
          bool _2111_b = _source103.dtor_BoolLiteral_a0;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.BoolLiteral"), Std.Strings.__default.OfBool(_2111_b)));
        }
      }
      if (unmatched103) {
        if (_source103.is_IntLiteral) {
          Dafny.ISequence<Dafny.Rune> _2112_str = _source103.dtor_IntLiteral_a0;
          DAST._IType _2113_t = _source103.dtor_IntLiteral_a1;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.IntLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2112_str), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2113_t)));
        }
      }
      if (unmatched103) {
        if (_source103.is_DecLiteral) {
          Dafny.ISequence<Dafny.Rune> _2114_str1 = _source103.dtor_DecLiteral_a0;
          Dafny.ISequence<Dafny.Rune> _2115_str2 = _source103.dtor_DecLiteral_a1;
          DAST._IType _2116_t = _source103.dtor_DecLiteral_a2;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.DecLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2114_str1), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2115_str2), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2116_t)));
        }
      }
      if (unmatched103) {
        if (_source103.is_StringLiteral) {
          Dafny.ISequence<Dafny.Rune> _2117_str = _source103.dtor_StringLiteral_a0;
          bool _2118_verbatim = _source103.dtor_verbatim;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.StringLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2117_str), Std.Strings.__default.OfBool(_2118_verbatim)));
        }
      }
      if (unmatched103) {
        if (_source103.is_CharLiteral) {
          Dafny.Rune _2119_c = _source103.dtor_CharLiteral_a0;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.CharLiteral"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(Std.Strings.__default.OfChar(_2119_c))));
        }
      }
      if (unmatched103) {
        if (_source103.is_CharLiteralUTF16) {
          BigInteger _2120_n = _source103.dtor_CharLiteralUTF16_a0;
          unmatched103 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.CharLiteralUTF16"), Std.Strings.__default.OfNat(_2120_n)));
        }
      }
      if (unmatched103) {
        DAST._IType _2121_t = _source103.dtor_Null_a0;
        unmatched103 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Literal.Null"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2121_t)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeTypeToSexpr(DAST._IDatatypeType datatypeType) {
      DAST._IDatatypeType _source104 = datatypeType;
      bool unmatched104 = true;
      if (unmatched104) {
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _2122_path = _source104.dtor_path;
        Dafny.ISequence<DAST._IAttribute> _2123_attributes = _source104.dtor_attributes;
        unmatched104 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeType.DatatypeType"), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _2122_path), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _2123_attributes)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> UnaryOpToSexpr(DAST._IUnaryOp unOp) {
      DAST._IUnaryOp _source105 = unOp;
      bool unmatched105 = true;
      if (unmatched105) {
        if (_source105.is_Not) {
          unmatched105 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.Not")));
        }
      }
      if (unmatched105) {
        if (_source105.is_BitwiseNot) {
          unmatched105 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.BitwiseNot")));
        }
      }
      if (unmatched105) {
        unmatched105 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("UnaryOp.Cardinality")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> BinOpToSexpr(DAST._IBinOp op) {
      DAST._IBinOp _source106 = op;
      bool unmatched106 = true;
      if (unmatched106) {
        if (_source106.is_Eq) {
          bool _2124_referential = _source106.dtor_referential;
          bool _2125_nullable = _source106.dtor_nullable;
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Eq"), Std.Strings.__default.OfBool(_2124_referential), Std.Strings.__default.OfBool(_2125_nullable)));
        }
      }
      if (unmatched106) {
        if (_source106.is_Div) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Div")));
        }
      }
      if (unmatched106) {
        if (_source106.is_EuclidianDiv) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.EuclidianDiv")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Mod) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Mod")));
        }
      }
      if (unmatched106) {
        if (_source106.is_EuclidianMod) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.EuclidianMod")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Lt) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Lt")));
        }
      }
      if (unmatched106) {
        if (_source106.is_LtChar) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.LtChar")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Plus) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Plus")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Minus) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Minus")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Times) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Times")));
        }
      }
      if (unmatched106) {
        if (_source106.is_BitwiseAnd) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseAnd")));
        }
      }
      if (unmatched106) {
        if (_source106.is_BitwiseOr) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseOr")));
        }
      }
      if (unmatched106) {
        if (_source106.is_BitwiseXor) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseXor")));
        }
      }
      if (unmatched106) {
        if (_source106.is_BitwiseShiftRight) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseShiftRight")));
        }
      }
      if (unmatched106) {
        if (_source106.is_BitwiseShiftLeft) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.BitwiseShiftLeft")));
        }
      }
      if (unmatched106) {
        if (_source106.is_And) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.And")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Or) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Or")));
        }
      }
      if (unmatched106) {
        if (_source106.is_In) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.In")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SeqProperPrefix) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SeqProperPrefix")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SeqPrefix) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SeqPrefix")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SetMerge) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetMerge")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SetSubtraction) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetSubtraction")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SetIntersection) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetIntersection")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Subset) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Subset")));
        }
      }
      if (unmatched106) {
        if (_source106.is_ProperSubset) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.ProperSubset")));
        }
      }
      if (unmatched106) {
        if (_source106.is_SetDisjoint) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.SetDisjoint")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MapMerge) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MapMerge")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MapSubtraction) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MapSubtraction")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MultisetMerge) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetMerge")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MultisetSubtraction) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetSubtraction")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MultisetIntersection) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetIntersection")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Submultiset) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Submultiset")));
        }
      }
      if (unmatched106) {
        if (_source106.is_ProperSubmultiset) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.ProperSubmultiset")));
        }
      }
      if (unmatched106) {
        if (_source106.is_MultisetDisjoint) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.MultisetDisjoint")));
        }
      }
      if (unmatched106) {
        if (_source106.is_Concat) {
          unmatched106 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Concat")));
        }
      }
      if (unmatched106) {
        Dafny.ISequence<Dafny.Rune> _2126_str = _source106.dtor_Passthrough_a0;
        unmatched106 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Passthrough"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_2126_str)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> CollKindToSexpr(DAST._ICollKind collKind) {
      DAST._ICollKind _source107 = collKind;
      bool unmatched107 = true;
      if (unmatched107) {
        if (_source107.is_Seq) {
          unmatched107 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Seq")));
        }
      }
      if (unmatched107) {
        if (_source107.is_Array) {
          unmatched107 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Array")));
        }
      }
      if (unmatched107) {
        unmatched107 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CollKind.Map")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> CallNameToSexpr(DAST._ICallName callName) {
      DAST._ICallName _source108 = callName;
      bool unmatched108 = true;
      if (unmatched108) {
        if (_source108.is_CallName) {
          Dafny.ISequence<Dafny.Rune> _2127_name = _source108.dtor_name;
          Std.Wrappers._IOption<DAST._IType> _2128_onType = _source108.dtor_onType;
          Dafny.ISequence<DAST._IFormal> _2129_signature = _source108.dtor_signature;
          unmatched108 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.CallName"), DafnyToSExpressionCompiler.__default.NameToSexpr(_2127_name), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IType>(_2128_onType, DafnyToSExpressionCompiler.__default.TypeToSexpr), DafnyToSExpressionCompiler.__default.CallSignatureToSexpr(_2129_signature)));
        }
      }
      if (unmatched108) {
        if (_source108.is_MapBuilderAdd) {
          unmatched108 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.MapBuilderAdd")));
        }
      }
      if (unmatched108) {
        if (_source108.is_MapBuilderBuild) {
          unmatched108 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.MapBuilderBuild")));
        }
      }
      if (unmatched108) {
        if (_source108.is_SetBuilderAdd) {
          unmatched108 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.SetBuilderAdd")));
        }
      }
      if (unmatched108) {
        unmatched108 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallName.SetBuilderBuild")));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> AssignLhsToSexpr(DAST._IAssignLhs lhs) {
      DAST._IAssignLhs _source109 = lhs;
      bool unmatched109 = true;
      if (unmatched109) {
        if (_source109.is_Ident) {
          Dafny.ISequence<Dafny.Rune> _2130_ident = _source109.dtor_ident;
          unmatched109 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Ident"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_2130_ident)));
        }
      }
      if (unmatched109) {
        if (_source109.is_Select) {
          DAST._IExpression _2131_expr = _source109.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _2132_field = _source109.dtor_field;
          unmatched109 = false;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2131_expr), DafnyToSExpressionCompiler.__default.NameToSexpr(_2132_field)));
        }
      }
      if (unmatched109) {
        DAST._IExpression _2133_expr = _source109.dtor_expr;
        Dafny.ISequence<DAST._IExpression> _2134_indices = _source109.dtor_indices;
        unmatched109 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_2133_expr), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_2134_indices)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeDtorToSexpr(DAST._IDatatypeDtor datatypeDtor) {
      DAST._IDatatypeDtor _source110 = datatypeDtor;
      bool unmatched110 = true;
      if (unmatched110) {
        DAST._IFormal _2135_formal = _source110.dtor_formal;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.Rune>> _2136_callName = _source110.dtor_callName;
        unmatched110 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeDtor.DatatypeDtor"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_2135_formal), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.Rune>>(_2136_callName, DafnyToSExpressionCompiler.__default.EscapeAndQuote)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> CallSignatureToSexpr(Dafny.ISequence<DAST._IFormal> signature) {
      Dafny.ISequence<DAST._IFormal> _source111 = signature;
      bool unmatched111 = true;
      if (unmatched111) {
        Dafny.ISequence<DAST._IFormal> _2137_parameters = _source111;
        unmatched111 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallSignature.CallSignature"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _2137_parameters)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> EscapeAndQuote(Dafny.ISequence<Dafny.Rune> str) {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""), Std.Strings.CharStrEscaping.__default.Escape(str, Dafny.Set<Dafny.Rune>.FromElements(new Dafny.Rune('\"'), new Dafny.Rune('\\')), new Dafny.Rune('\\'))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""));
    }
    public static Dafny.ISequence<Dafny.Rune> OptionToSexpr<__T>(Std.Wrappers._IOption<__T> opt, Func<__T, Dafny.ISequence<Dafny.Rune>> f)
    {
      var _pat_let_tv108 = f;
      Std.Wrappers._IOption<__T> _source112 = opt;
      bool unmatched112 = true;
      if (unmatched112) {
        if (_source112.is_None) {
          unmatched112 = false;
          return Dafny.Sequence<Dafny.Rune>.UnicodeFromString("(None)");
        }
      }
      if (unmatched112) {
        __T _2138_value = _source112.dtor_value;
        unmatched112 = false;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Some"), Dafny.Helpers.Id<Func<__T, Dafny.ISequence<Dafny.Rune>>>(_pat_let_tv108)(_2138_value)));
      }
      throw new System.Exception("unexpected control point");
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoin<__T>(Func<__T, Dafny.ISequence<Dafny.Rune>> f, Dafny.ISequence<__T> xs)
    {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("("), Std.Collections.Seq.__default.Join<Dafny.Rune>(Std.Collections.Seq.__default.Map<__T, Dafny.ISequence<Dafny.Rune>>(f, xs), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(" "))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(")"));
    }
    public static Dafny.ISequence<Dafny.Rune> StringSeqToSexpr(Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> xs) {
      return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(((System.Func<Dafny.ISequence<Dafny.Rune>, Dafny.ISequence<Dafny.Rune>>)((_2139_x) => {
        return _2139_x;
      })), xs);
    }
    public static Dafny.ISequence<Dafny.Rune> TwoTupleToSexpr<__T, __U>(_System._ITuple2<__T, __U> tuple, Func<__T, Dafny.ISequence<Dafny.Rune>> Tf, Func<__U, Dafny.ISequence<Dafny.Rune>> Uf)
    {
      return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Helpers.Id<Func<__T, Dafny.ISequence<Dafny.Rune>>>(Tf)((tuple).dtor__0), Dafny.Helpers.Id<Func<__U, Dafny.ISequence<Dafny.Rune>>>(Uf)((tuple).dtor__1)));
    }
  }
} // end of namespace DafnyToSExpressionCompiler