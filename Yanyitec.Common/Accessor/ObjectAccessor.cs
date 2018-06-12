using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yanyitec.Accessor
{
    public class ObjectAccessor : IObjectAccessor
    {
        public ObjectAccessor(Type objectType, IObjectAccessorFactory factory) {
            this.ObjectType = ObjectType;
            this.ObjectAccessorFactory = factory;
        }

        public IObjectAccessorFactory ObjectAccessorFactory { get;private set; }

        protected virtual IPropertyAccessor CreatePropertyAccessor(MemberInfo memberInfo) {
            return new PropertyAccessor(memberInfo,this);
        }
        public Type ObjectType { get; private set; }

        protected Dictionary<string, IPropertyAccessor> _Props;

        public IPropertyAccessor this[string memberName] {
            get
            {
                if (_Props == null) {
                    lock (this) {
                        if (this._Props == null) {
                            InitMembers();
                        }
                    }
                }
                IPropertyAccessor member = null;
                this._Props.TryGetValue(memberName,out member);
                return member;
            }
        }

        public IEnumerable<string> PropertyNames {
            get {
                if (this._Props == null)
                {
                    lock (this)
                    {
                        if (this._Props == null)
                        {
                            InitMembers();
                        }
                    }
                }
                return _Props.Keys;
            }
        }

        protected virtual void InitMembers() {
            var members = this.ObjectType.GetMembers();
            var result = new Dictionary<string, IPropertyAccessor>();
            foreach(MemberInfo member in members) {
                if (member.MemberType == MemberTypes.Property || member.MemberType == MemberTypes.Field)
                {
                    var prop = this.CreatePropertyAccessor(member);
                    if(prop!=null)result.Add(member.Name, prop);
                }
            }
            this._Props = result;
        }

        public IEnumerator<IPropertyAccessor> GetEnumerator()
        {
            return this._Props.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._Props.Values.GetEnumerator();
        }

        
    }
}
