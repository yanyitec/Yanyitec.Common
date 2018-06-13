using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Reflection;

namespace Yanyitec.Validation
{
    public interface IValidatableClassFactory :IClassFactory
    {
        Func<Type, string> GetEntityConfigFilename { get; set; }
    }
}
