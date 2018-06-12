using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Accessor;

namespace Yanyitec.Validation
{
    public interface IValidatableObjectAccessor : IObjectAccessor
    {
        JObject ValidationSettings { get; }

        JObject Validate(object entity,string accessableFields=null);
    }
}
