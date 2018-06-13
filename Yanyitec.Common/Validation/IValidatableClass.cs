using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Reflection;

namespace Yanyitec.Validation
{
    public interface IValidatableClass : IClass
    {
        JObject ValidationSettings { get; }

        JObject Validate(object entity,string accessableFields=null);
    }
}
