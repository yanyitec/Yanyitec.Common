using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public interface IProperty
    {
        IClass Class { get; }

        bool IsNullable { get;  }

        Type EntitativeType { get;  }

        string Name { get; }

        Func<object,bool,object> GetValue { get; }
        Action<object, object> SetValue { get; }

        IClass ItemAccessor { get; }



    }
}
