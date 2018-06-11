using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Yanyitec.Accessor
{
    public interface IObjectAccessor<T>:IObjectAccessor,IEnumerable<IPropertyAccessor<T>>
        where T:class 
    {

        

        
        new IPropertyAccessor<T> this[string memberName] { get; }
    }
}
