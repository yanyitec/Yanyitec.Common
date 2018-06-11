using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Accessor
{
    public interface IPropertyAccessor<T>:IPropertyAccessor
        where T:class
    {
        new Func<T, bool, object> GetValue { get; }
        new Action<T,  object> SetValue { get; }

    }
}
