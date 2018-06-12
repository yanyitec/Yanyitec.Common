using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Validation
{
    public class ValidationRule
    {
        public JToken Params { get; set; }

        public Func<object, object, string, bool> Rule { get; set; }

        public readonly static Dictionary<string, Func<object, object, string, bool>> Validates = new Dictionary<string, Func<object, object, string, bool>>()
        {

        };
    }
}
