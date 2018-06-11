using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Yanyitec.Accessor;

namespace Yanyitec.ORM
{
    public class Field<T> : PropertyAccessor<T>
        where T : class
    {
        public Field(MemberInfo memberInfo, IObjectAccessor<T> objectAccessor)
            : base(memberInfo, objectAccessor)
        {
        }

        public string FieldName { get; private set; }

        

    }
}
