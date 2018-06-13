using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Yanyitec.Reflection;

namespace Yanyitec.Validation
{
    public class ValidatableProperty : Property, IValidatableProperty
    {
        public ValidatableProperty(MemberInfo memberInfo, IClass Class):base(memberInfo,Class) {

        }
        List<ValidationRule> _ValidationRules;
        public IReadOnlyList<ValidationRule> ValidationRules {
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
        List<ValidationRule> MakeValidationRules() {
            List<ValidationRule> result = new List<ValidationRule>();
            var objAccessor = this.Class as IValidatableClass;
            var objSettings = objAccessor.ValidationSettings;
            var propSettings = objSettings[this.Name] as JObject;
            if (propSettings == null || propSettings.Type == JTokenType.Null || propSettings.Type == JTokenType.Undefined) return result;
            foreach (var pair in propSettings) {
                
                var rule = new ValidationRule(pair.Key,pair.Value);
                if (rule.Check != null) {
                    result.Add(rule);
                } else {
                    //TOLOG:
                }
            }
            return result;

        }

        public ValidationResult Validate(object value, object entity) {
            if (this.ValidationRules.Count == 0) return null;
            foreach (var rule in this.ValidationRules) {
                if (!rule.Check(value, entity, this)) {
                    return new ValidationResult() {
                        Entity = entity,
                        Value = value,
                        Property = this,
                        ValidationRule = rule
                    };
                }
                
            }
            return null;
        }
    }
}
