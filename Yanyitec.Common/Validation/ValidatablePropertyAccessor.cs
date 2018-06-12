using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Yanyitec.Accessor;

namespace Yanyitec.Validation
{
    public class ValidatablePropertyAccessor : PropertyAccessor
    {
        public ValidatablePropertyAccessor(MemberInfo memberInfo, IObjectAccessor objectAccessor):base(memberInfo,objectAccessor) {

        }
        ValidationRules _ValidationRules;
        public ValidationRules ValidationRules {
            get {
                if (_ValidationRules == null) {
                    lock (this) {
                        if (_ValidationRules == null) {
                            _ValidationRules = MakeValidationRules();
                        }
                    }
                }
                return _ValidationRules;
            }
        }
        ValidationRules MakeValidationRules() {
            ValidationRules result = new ValidationRules();
            var objAccessor = this.ObjectAccessor as IValidatableObjectAccessor;
            var objSettings = objAccessor.ValidationSettings;
            var propSettings = objSettings[this.Name] as JObject;
            if (propSettings == null || propSettings.Type == JTokenType.Null || propSettings.Type == JTokenType.Undefined) return result;
            foreach (var pair in propSettings) {
                var validName = pair.Key;
                var validParam = pair.Value;
                Func<object, object, string, bool> validateFn = null;
                if (ValidationRule.Validates.TryGetValue(validName, out validateFn)) {
                    result.Add(pair.Key,new ValidationRule() {
                        Rule = validateFn,
                        Params = pair.Value
                    });
                }
            }
            return result;

        }

    }
}
