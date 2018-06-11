using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yanyitec.Accessor 
{
    public interface IObjectAccessor:IEnumerable<IPropertyAccessor>
    {

        
        Type ObjectType { get;  }

        //Func<MemberInfo, IObjectAccessor, IMemberAccessor> MemberAccessorFactory { get; }

        IPropertyAccessor this[string memberName] { get; }
    }
}
