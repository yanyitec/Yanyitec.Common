using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yanyitec.Reflection 
{
    public interface IClass:IEnumerable<IProperty>
    {

        
        Type ObjectType { get;  }

        IClassFactory ClassFactory { get; }

        //Func<MemberInfo, IClass, IMemberAccessor> MemberAccessorFactory { get; }

        IProperty this[string memberName] { get; }

        IEnumerable<string> PropertyNames { get; }
    }
}
