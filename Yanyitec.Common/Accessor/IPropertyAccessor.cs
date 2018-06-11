using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Accessor
{
    public interface IPropertyAccessor
    {
        IObjectAccessor ObjectAccessor { get; }

        bool IsNullable { get;  }

        Type EntitativeType { get;  }

        string Name { get; }

        Func<object,bool,object> GetValue { get; }
        Action<object, object> SetValue { get; }

        IObjectAccessor ItemAccessor { get; }



    }
}
