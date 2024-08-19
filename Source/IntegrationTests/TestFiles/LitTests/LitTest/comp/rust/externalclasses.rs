#![allow(warnings, unconditional_panic)]
#![allow(nonstandard_style)]

pub mod External {
  pub mod Class {
    pub mod Container {
      use crate::*;

      pub struct ExternalClass {}
      impl ExternalClass {
        pub fn _allocate_object(_cmc: ::dafny_runtime::DafnyInt) -> ::dafny_runtime::Object<Self> {
          // SAFETY: The Rc has not been shared before
          unsafe {
            ::dafny_runtime::Object::from_rc(::std::rc::Rc::new(ExternalClass {}))
          }
        }
      }

      pub struct ExternalPartialClass {}
      impl ExternalPartialClass {
        pub fn _allocate_object() -> ::dafny_runtime::Object<Self> {
          // SAFETY: The Rc has not been shared before
          unsafe {
            ::dafny_runtime::Object::from_rc(::std::rc::Rc::new(ExternalPartialClass {}))
          }
        }
      }

      impl crate::External::Class::Container::GetValueHolder
        for ExternalPartialClass {
        fn GetValue(&self) -> dafny_runtime::DafnyInt {
          ::dafny_runtime::int!(2)
        }
      }

      impl ::dafny_runtime::UpcastObject<dyn crate::External::Class::Container::GetValueHolder>
        for ExternalPartialClass {
        ::dafny_runtime::UpcastObjectFn!(dyn crate::External::Class::Container::GetValueHolder);
      }

      pub struct ExternalPartialClass2 {}
      impl ExternalPartialClass2 {
        pub fn _allocate_object() -> ::dafny_runtime::Object<Self> {
          // SAFETY: The Rc has not been shared before
          unsafe {
            ::dafny_runtime::Object::from_rc(::std::rc::Rc::new(ExternalPartialClass2 {}))
          }
        }
      }
      pub struct _default {}

      impl _default {
        pub fn Test() -> ::dafny_runtime::DafnyInt {
          ::dafny_runtime::int!(2)
        }
      }
    }
  }
}

pub mod ExternWithOnlyAStaticMethodUninmplemented {
  pub struct _default {}
  
  impl _default {
    pub fn DoThis(i: &::dafny_runtime::DafnyInt) -> ::dafny_runtime::DafnyInt {
      i.clone() + ::dafny_runtime::int!(1)
    }
  }
}

pub mod DafnyLibraries {
  pub mod FileIO {
    pub fn INTERNAL_ReadBytesFromFile(path: &::dafny_runtime::DafnyString)
      -> ::dafny_runtime::DafnyString {
      return ::dafny_runtime::string_of("Everything is ok.");
    }
    
    pub fn INTERNAL_WriteBytesToFile(path: &::dafny_runtime::DafnyString, content: &::dafny_runtime::DafnyString) {
      // Nothing to do, we mock writing to a file
    }
  }
}

pub mod ExternModuleWithOneClassToImport {
  pub struct NonShareableBox {
    s: ::dafny_runtime::DafnyString
  }
  impl NonShareableBox {
    pub fn _allocate_object() -> ::dafny_runtime::Object<Self> {
      // SAFETY: The Rc has not been shared before
      unsafe {
        ::dafny_runtime::Object::from_rc(::std::rc::Rc::new(NonShareableBox {
          s: ::dafny_runtime::string_of("")
        }))
      }
    }
  }
  impl crate::ExternModuleWithOneClassToImport::TraitDefinedInModule
    for NonShareableBox {
    fn Get(&self) -> ::dafny_runtime::DafnyString {
      self.s.clone()
    }
    fn Put(&mut self, c: &::dafny_runtime::DafnyString) {
      self.s = c.clone();
    }
  }
}