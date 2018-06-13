using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Validation
{
    public class ValidationRule
    {
        public ValidationRule(string name, JToken param) {
            Func<object, object, IValidatableProperty, bool> rule = null;
            if (!Checkers.TryGetValue(name, out rule)) return;
            this.Check = rule;
            this.Name = name;
            this.Params = param;
        }
        public string Name { get; private set; }
        public JToken Params { get;private set; }

        public Func<object, object, IValidatableProperty, bool> Check { get; private set; }

        public readonly static Dictionary<string, Func<object, object,IValidatableProperty , bool>> Checkers = new Dictionary<string, Func<object, object, IValidatableProperty, bool>>()
        {

        };
    }
}
