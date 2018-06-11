using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Accessor
{
    public class ObjectAccessorFactory : IObjectAccessorFactory
    {
        ConcurrentDictionary<Guid, IObjectAccessor> _ObjectAccessors = new ConcurrentDictionary<Guid, IObjectAccessor>();

        public ObjectAccessorFactory(Func<Type, IObjectAccessor> objectAccessorFactory = null) {
            
        }
        protected virtual IObjectAccessor<T> CreateObjectAccessor<T>(Type type) where T:class {
            return new ObjectAccessor<T>(this);
        }

        public IObjectAccessor<T> Aquire<T>()where T:class {
            return _ObjectAccessors.GetOrAdd(typeof(T).GUID, (id) => new ObjectAccessor<T>(this) ) as IObjectAccessor<T>;
        }
        static Type ObjectAccessorType = typeof(ObjectAccessor<>);
        public virtual IObjectAccessor Aquire(Type type) {
            return _ObjectAccessors.GetOrAdd(type.GUID,(id)=> {
                var realType = ObjectAccessorType.MakeGenericType(type);
                return Activator.CreateInstance(realType,type,this) as IObjectAccessor;
            });
        }

        public static IObjectAccessorFactory Default = new ObjectAccessorFactory();
    }
}
