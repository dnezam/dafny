// Dafny program the_program compiled into C#
// To recompile, you will need the libraries
//     System.Runtime.Numerics.dll System.Collections.Immutable.dll
// but the 'dotnet' tool in net6.0 should pick those up automatically.
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
      DAST._IModule _source0 = mod;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._IAttribute> _1_attributes = _source0.dtor_attributes;
        bool _2_requiresExterns = _source0.dtor_requiresExterns;
        Std.Wrappers._IOption<Dafny.ISequence<DAST._IModuleItem>> _3_body = _source0.dtor_body;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Module.Module"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _1_attributes), Std.Strings.__default.OfBool(_2_requiresExterns), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<DAST._IModuleItem>>(_3_body, Dafny.Helpers.Id<Func<DAST._IModule, Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>>>((_4_mod) => ((System.Func<Dafny.ISequence<DAST._IModuleItem>, Dafny.ISequence<Dafny.Rune>>)((_5_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IModuleItem>(Dafny.Helpers.Id<Func<DAST._IModule, Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>>>((_6_mod) => ((System.Func<DAST._IModuleItem, Dafny.ISequence<Dafny.Rune>>)((_7_i) => {
            return DafnyToSExpressionCompiler.__default.ModuleItemToSexpr(_7_i);
          })))(_4_mod), _5_x);
        })))(mod))));
      }
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
    public static Dafny.ISequence<Dafny.Rune> AttributeToSexpr(DAST._IAttribute attribute) {
      DAST._IAttribute _source0 = attribute;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _1_args = _source0.dtor_args;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Attribute.Attribute"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.EscapeAndQuote, _1_args)));
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
    public static Dafny.ISequence<Dafny.Rune> ClassToSexpr(DAST._IClass cls) {
      DAST._IClass _source0 = cls;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_enclosingModule = _source0.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _2_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IType> _3_superClasses = _source0.dtor_superClasses;
        Dafny.ISequence<DAST._IField> _4_fields = _source0.dtor_fields;
        Dafny.ISequence<DAST._IMethod> _5_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _6_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Class.Class"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _3_superClasses), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IField>(DafnyToSExpressionCompiler.__default.FieldToSexpr, _4_fields), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _5_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _6_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> TraitToSexpr(DAST._ITrait trt) {
      DAST._ITrait _source0 = trt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _1_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IType> _2_parents = _source0.dtor_parents;
        Dafny.ISequence<DAST._IMethod> _3_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IAttribute> _4_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Trait.Trait"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _2_parents), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _3_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _4_attributes)));
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
    public static Dafny.ISequence<Dafny.Rune> NewtypeToSexpr(DAST._INewtype nt) {
      DAST._INewtype _source0 = nt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _1_typeParams = _source0.dtor_typeParams;
        DAST._IType _2_base = _source0.dtor_base;
        DAST._INewtypeRange _3_range = _source0.dtor_range;
        Std.Wrappers._IOption<DAST._INewtypeConstraint> _4_constraint = _source0.dtor_constraint;
        Dafny.ISequence<DAST._IStatement> _5_witnessStmts = _source0.dtor_witnessStmts;
        Std.Wrappers._IOption<DAST._IExpression> _6_witnessExpr = _source0.dtor_witnessExpr;
        Dafny.ISequence<DAST._IAttribute> _7_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Newtype.Newtype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1_typeParams), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2_base), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_3_range), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._INewtypeConstraint>(_4_constraint, DafnyToSExpressionCompiler.__default.NewtypeConstraintToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _5_witnessStmts), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_6_witnessExpr, DafnyToSExpressionCompiler.__default.ExpressionToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _7_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> SynonymTypeToSexpr(DAST._ISynonymType st) {
      DAST._ISynonymType _source0 = st;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _1_typeParams = _source0.dtor_typeParams;
        DAST._IType _2_base = _source0.dtor_base;
        Dafny.ISequence<DAST._IStatement> _3_witnessStmts = _source0.dtor_witnessStmts;
        Std.Wrappers._IOption<DAST._IExpression> _4_witnessExpr = _source0.dtor_witnessExpr;
        Dafny.ISequence<DAST._IAttribute> _5_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("SynonymType.SynonymType"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _1_typeParams), DafnyToSExpressionCompiler.__default.TypeToSexpr(_2_base), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _3_witnessStmts), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_4_witnessExpr, DafnyToSExpressionCompiler.__default.ExpressionToSexpr), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _5_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeToSexpr(DAST._IDatatype dt) {
      DAST._IDatatype _source0 = dt;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<Dafny.Rune> _1_enclosingModule = _source0.dtor_enclosingModule;
        Dafny.ISequence<DAST._ITypeArgDecl> _2_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IDatatypeCtor> _3_ctors = _source0.dtor_ctors;
        Dafny.ISequence<DAST._IMethod> _4_body = _source0.dtor_body;
        bool _5_isCo = _source0.dtor_isCo;
        Dafny.ISequence<DAST._IAttribute> _6_attributes = _source0.dtor_attributes;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Datatype.Datatype"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.IdentToSexpr(_1_enclosingModule), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _2_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeCtor>(DafnyToSExpressionCompiler.__default.DatatypeCtorToSexpr, _3_ctors), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IMethod>(DafnyToSExpressionCompiler.__default.ClassItemToSexpr, _4_body), Std.Strings.__default.OfBool(_5_isCo), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _6_attributes)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> IdentToSexpr(Dafny.ISequence<Dafny.Rune> ident) {
      Dafny.ISequence<Dafny.Rune> _source0 = ident;
      {
        Dafny.ISequence<Dafny.Rune> _0_id = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Ident.Ident"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_id)));
      }
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
        DAST._IVariance _2_variance = _source0.dtor_variance;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgDecl.TypeArgDecl"), DafnyToSExpressionCompiler.__default.IdentToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgBound>(DafnyToSExpressionCompiler.__default.TypeArgBoundToSexpr, _1_bounds), DafnyToSExpressionCompiler.__default.VarianceToSexpr(_2_variance)));
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
    public static Dafny.ISequence<Dafny.Rune> FieldToSexpr(DAST._IField field) {
      DAST._IField _source0 = field;
      {
        DAST._IFormal _0_formal = _source0.dtor_formal;
        Std.Wrappers._IOption<DAST._IExpression> _1_defaultValue = _source0.dtor_defaultValue;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Field.Field"), DafnyToSExpressionCompiler.__default.FormalToSexpr(_0_formal), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_1_defaultValue, DafnyToSExpressionCompiler.__default.ExpressionToSexpr)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> ClassItemToSexpr(DAST._IMethod classItem) {
      DAST._IMethod _source0 = classItem;
      {
        DAST._IMethod _0_m = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ClassItem.Method"), DafnyToSExpressionCompiler.__default.MethodToSexpr(_0_m)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> NewtypeRangeToSexpr(DAST._INewtypeRange range) {
      DAST._INewtypeRange _source0 = range;
      {
        if (_source0.is_U8) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U8")));
        }
      }
      {
        if (_source0.is_I8) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I8")));
        }
      }
      {
        if (_source0.is_U16) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U16")));
        }
      }
      {
        if (_source0.is_I16) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I16")));
        }
      }
      {
        if (_source0.is_U32) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U32")));
        }
      }
      {
        if (_source0.is_I32) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I32")));
        }
      }
      {
        if (_source0.is_U64) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U64")));
        }
      }
      {
        if (_source0.is_I64) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I64")));
        }
      }
      {
        if (_source0.is_U128) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.U128")));
        }
      }
      {
        if (_source0.is_I128) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.I128")));
        }
      }
      {
        if (_source0.is_USIZE) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.USIZE")));
        }
      }
      {
        if (_source0.is_BigInt) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.BigInt")));
        }
      }
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("NewtypeRange.NoRange")));
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
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValue"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IExpression, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IExpression, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_34_mapElems, _35_expr) => ((System.Func<_System._ITuple2<DAST._IExpression, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_36_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IExpression, DAST._IExpression>(_36_x, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_37_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_38_y) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_38_y);
            })))(_35_expr), Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_39_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_40_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_40_z);
            })))(_35_expr));
          })))(_33_mapElems, expr), _33_mapElems)));
        }
      }
      {
        if (_source0.is_MapBuilder) {
          DAST._IType _41_keyType = _source0.dtor_keyType;
          DAST._IType _42_valueType = _source0.dtor_valueType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_41_keyType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_42_valueType)));
        }
      }
      {
        if (_source0.is_SeqUpdate) {
          DAST._IExpression _43_expr_k = _source0.dtor_expr;
          DAST._IExpression _44_indexExpr = _source0.dtor_indexExpr;
          DAST._IExpression _45_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_43_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_44_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_45_value)));
        }
      }
      {
        if (_source0.is_MapUpdate) {
          DAST._IExpression _46_expr_k = _source0.dtor_expr;
          DAST._IExpression _47_indexExpr = _source0.dtor_indexExpr;
          DAST._IExpression _48_value = _source0.dtor_value;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapUpdate"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_46_expr_k), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_47_indexExpr), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_48_value)));
        }
      }
      {
        if (_source0.is_SetBuilder) {
          DAST._IType _49_elemType = _source0.dtor_elemType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBuilder"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_49_elemType)));
        }
      }
      {
        if (_source0.is_ToMultiset) {
          DAST._IExpression _50_expr_k = _source0.dtor_ToMultiset_a0;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ToMultiset"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_50_expr_k)));
        }
      }
      {
        if (_source0.is_This) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.This")));
        }
      }
      {
        if (_source0.is_Ite) {
          DAST._IExpression _51_cond = _source0.dtor_cond;
          DAST._IExpression _52_thn = _source0.dtor_thn;
          DAST._IExpression _53_els = _source0.dtor_els;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Ite"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_51_cond), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_52_thn), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_53_els)));
        }
      }
      {
        if (_source0.is_UnOp) {
          DAST._IUnaryOp _54_unOp = _source0.dtor_unOp;
          DAST._IExpression _55_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.UnOp"), DafnyToSExpressionCompiler.__default.UnaryOpToSexpr(_54_unOp), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_55_expr_k)));
        }
      }
      {
        if (_source0.is_BinOp) {
          DAST._IBinOp _56_op = _source0.dtor_op;
          DAST._IExpression _57_left = _source0.dtor_left;
          DAST._IExpression _58_right = _source0.dtor_right;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BinOp"), DafnyToSExpressionCompiler.__default.BinOpToSexpr(_56_op), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_57_left), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_58_right)));
        }
      }
      {
        if (_source0.is_ArrayLen) {
          DAST._IExpression _59_expr_k = _source0.dtor_expr;
          DAST._IType _60_exprType = _source0.dtor_exprType;
          BigInteger _61_dim = _source0.dtor_dim;
          bool _62_native = _source0.dtor_native;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ArrayLen"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_59_expr_k), DafnyToSExpressionCompiler.__default.TypeToSexpr(_60_exprType), Std.Strings.__default.OfNat(_61_dim), Std.Strings.__default.OfBool(_62_native)));
        }
      }
      {
        if (_source0.is_MapKeys) {
          DAST._IExpression _63_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapKeys"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_63_expr_k)));
        }
      }
      {
        if (_source0.is_MapValues) {
          DAST._IExpression _64_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapValues"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_64_expr_k)));
        }
      }
      {
        if (_source0.is_MapItems) {
          DAST._IExpression _65_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapItems"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_65_expr_k)));
        }
      }
      {
        if (_source0.is_Select) {
          DAST._IExpression _66_expr_k = _source0.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _67_field = _source0.dtor_field;
          bool _68_isConstant = _source0.dtor_isConstant;
          bool _69_onDatatype = _source0.dtor_onDatatype;
          DAST._IType _70_fieldType = _source0.dtor_fieldType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_66_expr_k), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_67_field), Std.Strings.__default.OfBool(_68_isConstant), Std.Strings.__default.OfBool(_69_onDatatype), DafnyToSExpressionCompiler.__default.TypeToSexpr(_70_fieldType)));
        }
      }
      {
        if (_source0.is_SelectFn) {
          DAST._IExpression _71_expr_k = _source0.dtor_expr;
          Dafny.ISequence<Dafny.Rune> _72_field = _source0.dtor_field;
          bool _73_onDatatype = _source0.dtor_onDatatype;
          bool _74_isStatic = _source0.dtor_isStatic;
          bool _75_isConstant = _source0.dtor_isConstant;
          Dafny.ISequence<DAST._IType> _76_arguments = _source0.dtor_arguments;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SelectFn"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_71_expr_k), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_72_field), Std.Strings.__default.OfBool(_73_onDatatype), Std.Strings.__default.OfBool(_74_isStatic), Std.Strings.__default.OfBool(_75_isConstant), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _76_arguments)));
        }
      }
      {
        if (_source0.is_Index) {
          DAST._IExpression _77_expr_k = _source0.dtor_expr;
          DAST._ICollKind _78_collKind = _source0.dtor_collKind;
          Dafny.ISequence<DAST._IExpression> _79_indices = _source0.dtor_indices;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_77_expr_k), DafnyToSExpressionCompiler.__default.CollKindToSexpr(_78_collKind), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_79_indices)));
        }
      }
      {
        if (_source0.is_IndexRange) {
          DAST._IExpression _80_expr_k = _source0.dtor_expr;
          bool _81_isArray = _source0.dtor_isArray;
          Std.Wrappers._IOption<DAST._IExpression> _82_low = _source0.dtor_low;
          Std.Wrappers._IOption<DAST._IExpression> _83_high = _source0.dtor_high;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IndexRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_80_expr_k), Std.Strings.__default.OfBool(_81_isArray), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_82_low, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_84_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_85_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_85_x);
          })))(expr)), DafnyToSExpressionCompiler.__default.OptionToSexpr<DAST._IExpression>(_83_high, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_86_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_87_x) => {
            return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_87_x);
          })))(expr))));
        }
      }
      {
        if (_source0.is_TupleSelect) {
          DAST._IExpression _88_expr_k = _source0.dtor_expr;
          BigInteger _89_index = _source0.dtor_index;
          DAST._IType _90_fieldType = _source0.dtor_fieldType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TupleSelect"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_88_expr_k), Std.Strings.__default.OfNat(_89_index), DafnyToSExpressionCompiler.__default.TypeToSexpr(_90_fieldType)));
        }
      }
      {
        if (_source0.is_Call) {
          DAST._IExpression _91_on = _source0.dtor_on;
          DAST._ICallName _92_callName = _source0.dtor_callName;
          Dafny.ISequence<DAST._IType> _93_typeArgs = _source0.dtor_typeArgs;
          Dafny.ISequence<DAST._IExpression> _94_args = _source0.dtor_args;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Call"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_91_on), DafnyToSExpressionCompiler.__default.CallNameToSexpr(_92_callName), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _93_typeArgs), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_94_args)));
        }
      }
      {
        if (_source0.is_Lambda) {
          Dafny.ISequence<DAST._IFormal> _95_params = _source0.dtor_params;
          DAST._IType _96_retType = _source0.dtor_retType;
          Dafny.ISequence<DAST._IStatement> _97_body = _source0.dtor_body;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Lambda"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _95_params), DafnyToSExpressionCompiler.__default.TypeToSexpr(_96_retType), DafnyToSExpressionCompiler.__default.MapJoinStatementToSexpr(_97_body)));
        }
      }
      {
        if (_source0.is_BetaRedex) {
          Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>> _98_values = _source0.dtor_values;
          DAST._IType _99_retType = _source0.dtor_retType;
          DAST._IExpression _100_expr_k = _source0.dtor_expr;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BetaRedex"), DafnyToSExpressionCompiler.__default.MapJoin<_System._ITuple2<DAST._IFormal, DAST._IExpression>>(Dafny.Helpers.Id<Func<Dafny.ISequence<_System._ITuple2<DAST._IFormal, DAST._IExpression>>, DAST._IExpression, Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>>>((_101_values, _102_expr) => ((System.Func<_System._ITuple2<DAST._IFormal, DAST._IExpression>, Dafny.ISequence<Dafny.Rune>>)((_103_x) => {
            return DafnyToSExpressionCompiler.__default.TwoTupleToSexpr<DAST._IFormal, DAST._IExpression>(_103_x, DafnyToSExpressionCompiler.__default.FormalToSexpr, Dafny.Helpers.Id<Func<DAST._IExpression, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_104_expr) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_105_z) => {
              return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_105_z);
            })))(_102_expr));
          })))(_98_values, expr), _98_values), DafnyToSExpressionCompiler.__default.TypeToSexpr(_99_retType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_100_expr_k)));
        }
      }
      {
        if (_source0.is_IIFE) {
          Dafny.ISequence<Dafny.Rune> _106_name = _source0.dtor_ident;
          DAST._IType _107_typ = _source0.dtor_typ;
          DAST._IExpression _108_value = _source0.dtor_value;
          DAST._IExpression _109_iifeBody = _source0.dtor_iifeBody;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IIFE"), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_106_name), DafnyToSExpressionCompiler.__default.TypeToSexpr(_107_typ), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_108_value), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_109_iifeBody)));
        }
      }
      {
        if (_source0.is_Apply) {
          DAST._IExpression _110_expr_k = _source0.dtor_expr;
          Dafny.ISequence<DAST._IExpression> _111_args = _source0.dtor_args;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Apply"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_110_expr_k), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_111_args)));
        }
      }
      {
        if (_source0.is_TypeTest) {
          DAST._IExpression _112_on = _source0.dtor_on;
          Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> _113_dType = _source0.dtor_dType;
          Dafny.ISequence<Dafny.Rune> _114_variant = _source0.dtor_variant;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.TypeTest"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_112_on), DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _113_dType), DafnyToSExpressionCompiler.__default.NameToSexpr(_114_variant)));
        }
      }
      {
        if (_source0.is_Is) {
          DAST._IExpression _115_expr_k = _source0.dtor_expr;
          DAST._IType _116_fromType = _source0.dtor_fromType;
          DAST._IType _117_toType = _source0.dtor_toType;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Is"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_115_expr_k), DafnyToSExpressionCompiler.__default.TypeToSexpr(_116_fromType), DafnyToSExpressionCompiler.__default.TypeToSexpr(_117_toType)));
        }
      }
      {
        if (_source0.is_InitializationValue) {
          DAST._IType _118_typ = _source0.dtor_typ;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.InitializationValue"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_118_typ)));
        }
      }
      {
        if (_source0.is_BoolBoundedPool) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.BoolBoundedPool")));
        }
      }
      {
        if (_source0.is_SetBoundedPool) {
          DAST._IExpression _119_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SetBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_119_of)));
        }
      }
      {
        if (_source0.is_MapBoundedPool) {
          DAST._IExpression _120_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.MapBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_120_of)));
        }
      }
      {
        if (_source0.is_SeqBoundedPool) {
          DAST._IExpression _121_of = _source0.dtor_of;
          bool _122_includeDuplicates = _source0.dtor_includeDuplicates;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.SeqBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_121_of), Std.Strings.__default.OfBool(_122_includeDuplicates)));
        }
      }
      {
        if (_source0.is_ExactBoundedPool) {
          DAST._IExpression _123_of = _source0.dtor_of;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.ExactBoundedPool"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_123_of)));
        }
      }
      {
        if (_source0.is_IntRange) {
          DAST._IType _124_elemType = _source0.dtor_elemType;
          DAST._IExpression _125_lo = _source0.dtor_lo;
          DAST._IExpression _126_hi = _source0.dtor_hi;
          bool _127_up = _source0.dtor_up;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.IntRange"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_124_elemType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_125_lo), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_126_hi), Std.Strings.__default.OfBool(_127_up)));
        }
      }
      {
        if (_source0.is_UnboundedIntRange) {
          DAST._IExpression _128_start = _source0.dtor_start;
          bool _129_up = _source0.dtor_up;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.UnboundedIntRange"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_128_start), Std.Strings.__default.OfBool(_129_up)));
        }
      }
      {
        DAST._IType _130_elemType = _source0.dtor_elemType;
        DAST._IExpression _131_collection = _source0.dtor_collection;
        bool _132_is__forall = _source0.dtor_is__forall;
        DAST._IExpression _133_lambda = _source0.dtor_lambda;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Expression.Quantifier"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_130_elemType), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_131_collection), Std.Strings.__default.OfBool(_132_is__forall), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_133_lambda)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinExpressionToSexpr(Dafny.ISequence<DAST._IExpression> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IExpression>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IExpression>, Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>>>((_0_ts) => ((System.Func<DAST._IExpression, Dafny.ISequence<Dafny.Rune>>)((_1_x) => {
        return DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1_x);
      })))(ts), ts);
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
        Dafny.ISequence<DAST._IFormal> _28_fields = _source0.dtor_fields;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Statement.ConstructorNewSeparator"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _28_fields)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> MapJoinStatementToSexpr(Dafny.ISequence<DAST._IStatement> ts) {
      return DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(Dafny.Helpers.Id<Func<Dafny.ISequence<DAST._IStatement>, Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>>>((_0_ts) => ((System.Func<DAST._IStatement, Dafny.ISequence<Dafny.Rune>>)((_1_x) => {
        return DafnyToSExpressionCompiler.__default.StatementToSexpr(_1_x);
      })))(ts), ts);
    }
    public static Dafny.ISequence<Dafny.Rune> DatatypeCtorToSexpr(DAST._IDatatypeCtor datatypeCtor) {
      DAST._IDatatypeCtor _source0 = datatypeCtor;
      {
        Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
        Dafny.ISequence<DAST._IDatatypeDtor> _1_args = _source0.dtor_args;
        bool _2_hasAnyArgs = _source0.dtor_hasAnyArgs;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeCtor.DatatypeCtor"), DafnyToSExpressionCompiler.__default.NameToSexpr(_0_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IDatatypeDtor>(DafnyToSExpressionCompiler.__default.DatatypeDtorToSexpr, _1_args), Std.Strings.__default.OfBool(_2_hasAnyArgs)));
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
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("TypeArgBound.SupportsDefault")));
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
    public static Dafny.ISequence<Dafny.Rune> ResolvedTypeBaseToSexpr(DAST._IResolvedTypeBase resolvedTypeBase) {
      DAST._IResolvedTypeBase _source0 = resolvedTypeBase;
      {
        if (_source0.is_Class) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Class")));
        }
      }
      {
        if (_source0.is_Datatype) {
          Dafny.ISequence<DAST._IVariance> _0_variances = _source0.dtor_variances;
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Datatype"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IVariance>(DafnyToSExpressionCompiler.__default.VarianceToSexpr, _0_variances)));
        }
      }
      {
        if (_source0.is_Trait) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Trait")));
        }
      }
      {
        DAST._IType _1_baseType = _source0.dtor_baseType;
        DAST._INewtypeRange _2_range = _source0.dtor_range;
        bool _3_erase = _source0.dtor_erase;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("ResolvedTypeBase.Newtype"), DafnyToSExpressionCompiler.__default.TypeToSexpr(_1_baseType), DafnyToSExpressionCompiler.__default.NewtypeRangeToSexpr(_2_range), Std.Strings.__default.OfBool(_3_erase)));
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
    public static Dafny.ISequence<Dafny.Rune> MethodToSexpr(DAST._IMethod m) {
      DAST._IMethod _source0 = m;
      {
        Dafny.ISequence<DAST._IAttribute> _0_attributes = _source0.dtor_attributes;
        bool _1_isStatic = _source0.dtor_isStatic;
        bool _2_hasBody = _source0.dtor_hasBody;
        bool _3_outVarsAreUninitFieldsToAssign = _source0.dtor_outVarsAreUninitFieldsToAssign;
        bool _4_wasFunction = _source0.dtor_wasFunction;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _5_overridingPath = _source0.dtor_overridingPath;
        Dafny.ISequence<Dafny.Rune> _6_name = _source0.dtor_name;
        Dafny.ISequence<DAST._ITypeArgDecl> _7_typeParams = _source0.dtor_typeParams;
        Dafny.ISequence<DAST._IFormal> _8_params = _source0.dtor_params;
        Dafny.ISequence<DAST._IStatement> _9_body = _source0.dtor_body;
        Dafny.ISequence<DAST._IType> _10_outTypes = _source0.dtor_outTypes;
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>> _11_outVars = _source0.dtor_outVars;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("Method.Method"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IAttribute>(DafnyToSExpressionCompiler.__default.AttributeToSexpr, _0_attributes), Std.Strings.__default.OfBool(_1_isStatic), Std.Strings.__default.OfBool(_2_hasBody), Std.Strings.__default.OfBool(_3_outVarsAreUninitFieldsToAssign), Std.Strings.__default.OfBool(_4_wasFunction), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_5_overridingPath, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_12_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.IdentToSexpr, _12_x);
        }))), DafnyToSExpressionCompiler.__default.NameToSexpr(_6_name), DafnyToSExpressionCompiler.__default.MapJoin<DAST._ITypeArgDecl>(DafnyToSExpressionCompiler.__default.TypeArgDeclToSexpr, _7_typeParams), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _8_params), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IStatement>(DafnyToSExpressionCompiler.__default.StatementToSexpr, _9_body), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IType>(DafnyToSExpressionCompiler.__default.TypeToSexpr, _10_outTypes), DafnyToSExpressionCompiler.__default.OptionToSexpr<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>>(_11_outVars, ((System.Func<Dafny.ISequence<Dafny.ISequence<Dafny.Rune>>, Dafny.ISequence<Dafny.Rune>>)((_13_x) => {
          return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(DafnyToSExpressionCompiler.__default.VarNameToSexpr, _13_x);
        })))));
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
    public static Dafny.ISequence<Dafny.Rune> DatatypeTypeToSexpr(DAST._IDatatypeType datatypeType) {
      DAST._IDatatypeType _source0 = datatypeType;
      {
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("DatatypeType.DatatypeType")));
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
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Div")));
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
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Plus")));
        }
      }
      {
        if (_source0.is_Minus) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Minus")));
        }
      }
      {
        if (_source0.is_Times) {
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Times")));
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
        Dafny.ISequence<Dafny.Rune> _1_str = _source0.dtor_Passthrough_a0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("BinOp.Passthrough"), DafnyToSExpressionCompiler.__default.EscapeAndQuote(_1_str)));
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
    public static Dafny.ISequence<Dafny.Rune> CallNameToSexpr(DAST._ICallName callName) {
      DAST._ICallName _source0 = callName;
      {
        if (_source0.is_CallName) {
          Dafny.ISequence<Dafny.Rune> _0_name = _source0.dtor_name;
          Std.Wrappers._IOption<DAST._IType> _1_onType = _source0.dtor_onType;
          Std.Wrappers._IOption<DAST._IFormal> _2_receiverArgs = _source0.dtor_receiverArg;
          bool _3_receiverAsArgument = _source0.dtor_receiverAsArgument;
          Dafny.ISequence<DAST._IFormal> _4_signature = _source0.dtor_signature;
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
          return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Select"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_1_expr), DafnyToSExpressionCompiler.__default.VarNameToSexpr(_2_field)));
        }
      }
      {
        DAST._IExpression _3_expr = _source0.dtor_expr;
        Dafny.ISequence<DAST._IExpression> _4_indices = _source0.dtor_indices;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("AssignLhs.Index"), DafnyToSExpressionCompiler.__default.ExpressionToSexpr(_3_expr), DafnyToSExpressionCompiler.__default.MapJoinExpressionToSexpr(_4_indices)));
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
    public static Dafny.ISequence<Dafny.Rune> CallSignatureToSexpr(Dafny.ISequence<DAST._IFormal> signature) {
      Dafny.ISequence<DAST._IFormal> _source0 = signature;
      {
        Dafny.ISequence<DAST._IFormal> _0_parameters = _source0;
        return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("CallSignature.CallSignature"), DafnyToSExpressionCompiler.__default.MapJoin<DAST._IFormal>(DafnyToSExpressionCompiler.__default.FormalToSexpr, _0_parameters)));
      }
    }
    public static Dafny.ISequence<Dafny.Rune> EscapeAndQuote(Dafny.ISequence<Dafny.Rune> str) {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""), Std.Strings.CharStrEscaping.__default.Escape(str, Dafny.Set<Dafny.Rune>.FromElements(new Dafny.Rune('\"'), new Dafny.Rune('\\')), new Dafny.Rune('\\'))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("\""));
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
    public static Dafny.ISequence<Dafny.Rune> MapJoin<__T>(Func<__T, Dafny.ISequence<Dafny.Rune>> f, Dafny.ISequence<__T> xs)
    {
      return Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.Concat(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("("), Std.Collections.Seq.__default.Join<Dafny.Rune>(Std.Collections.Seq.__default.Map<__T, Dafny.ISequence<Dafny.Rune>>(f, xs), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(" "))), Dafny.Sequence<Dafny.Rune>.UnicodeFromString(")"));
    }
    public static Dafny.ISequence<Dafny.Rune> StringSeqToSexpr(Dafny.ISequence<Dafny.ISequence<Dafny.Rune>> xs) {
      return DafnyToSExpressionCompiler.__default.MapJoin<Dafny.ISequence<Dafny.Rune>>(((System.Func<Dafny.ISequence<Dafny.Rune>, Dafny.ISequence<Dafny.Rune>>)((_0_x) => {
        return _0_x;
      })), xs);
    }
    public static Dafny.ISequence<Dafny.Rune> TwoTupleToSexpr<__T, __U>(_System._ITuple2<__T, __U> tuple, Func<__T, Dafny.ISequence<Dafny.Rune>> Tf, Func<__U, Dafny.ISequence<Dafny.Rune>> Uf)
    {
      return DafnyToSExpressionCompiler.__default.StringSeqToSexpr(Dafny.Sequence<Dafny.ISequence<Dafny.Rune>>.FromElements(Dafny.Helpers.Id<Func<__T, Dafny.ISequence<Dafny.Rune>>>(Tf)((tuple).dtor__0), Dafny.Helpers.Id<Func<__U, Dafny.ISequence<Dafny.Rune>>>(Uf)((tuple).dtor__1)));
    }
  }
} // end of namespace DafnyToSExpressionCompiler