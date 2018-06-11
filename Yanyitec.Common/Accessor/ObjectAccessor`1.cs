using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yanyitec.Accessor
{
    public class ObjectAccessor<T> : ObjectAccessor, IObjectAccessor<T>
        where T : class
    {

        public ObjectAccessor(IObjectAccessorFactory factory)
            : base(typeof(T),factory)
        {
            

        }
        protected override IPropertyAccessor CreatePropertyAccessor(MemberInfo memberInfo)
        {
            return new PropertyAccessor<T>(memberInfo,this);
        }



        public new IPropertyAccessor<T> this[string memberName] {
            get
            {

                IPropertyAccessor member = base[memberName];
                return member as IPropertyAccessor<T>;
            }
        }

        IEnumerator<IPropertyAccessor<T>> IEnumerable<IPropertyAccessor<T>>.GetEnumerator()
        {
            return new Enumerator(base.GetEnumerator());
        }

        public class Enumerator : IEnumerator<IPropertyAccessor<T>>
        {
            IEnumerator<IPropertyAccessor> Internal;
            public Enumerator(IEnumerator<IPropertyAccessor> internalen) {
                this.Internal = internalen;
            }
            public IPropertyAccessor<T> Current => this.Internal.Current as IPropertyAccessor<T>;

            object IEnumerator.Current => this.Internal.Current;

            public void Dispose()
            {
                this.Internal.Dispose();
            }

            public bool MoveNext()
            {
                return this.Internal.MoveNext();
            }

            public void Reset()
            {
                this.Internal.Reset();
            }
        }


    
        
    }
}
