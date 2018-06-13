using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public class ClassFactory : IClassFactory
    {
        ConcurrentDictionary<Guid, IClass> _Classs = new ConcurrentDictionary<Guid, IClass>();

        public ClassFactory(Func<Type, IClass> ClassFactory = null) {
            
        }
        protected virtual IClass<T> CreateClass<T>(Type type) where T:class {
            return new Class<T>(this);
        }

        public IClass<T> Aquire<T>()where T:class {
            return _Classs.GetOrAdd(typeof(T).GUID, (id) => new Class<T>(this) ) as IClass<T>;
        }
        static Type ClassType = typeof(Class<>);
        public virtual IClass Aquire(Type type) {
            return _Classs.GetOrAdd(type.GUID,(id)=> {
                var realType = ClassType.MakeGenericType(type);
                return Activator.CreateInstance(realType,type,this) as IClass;
            });
        }

        public static IClassFactory Default = new ClassFactory();
    }
}
