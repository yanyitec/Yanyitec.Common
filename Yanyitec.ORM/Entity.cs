using System;
using Yanyitec.Accessor;

namespace Yanyitec.ORM
{
    public class Entity<T> : ObjectAccessor<T>
        where T:class
    {
        public Entity(IObjectAccessorFactory factory):base(factory) {

        }

        public string TableName { get; set; }

        public new Field<T> this[string name]
        {
            get
            {
                return base[name] as Field<T>;
            }
        }
    }
}
