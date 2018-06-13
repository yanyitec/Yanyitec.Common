using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Yanyitec.Reflection;

namespace Yanyitec.Validation
{
    public class ValidatableClass : Class, IValidatableClass
    {
        public ValidatableClass(Type objectType, IClassFactory factory):base(objectType,factory)
        {
            
        }

        JObject _ValidationSettings;
        public JObject ValidationSettings {
            get {
                if (_ValidationSettings == null) {
                    lock (this) {
                        if (_ValidationSettings == null) {
                            _ValidationSettings = LoadValidationSettings();
                        }
                    }
                }
                return _ValidationSettings;
            }
        }

        JObject LoadValidationSettings() {
            var filename = (this.ClassFactory as IValidatableClassFactory).GetEntityConfigFilename(this.ObjectType);
            var content = File.ReadAllText(filename);
            return content.ToJson() as JObject;
        }

        public JObject Validate(object entity, string accessableFields = null)
        {
            //a,b,c[{a,b,c}],d
            throw new NotImplementedException();

        }

        bool Validate(object entity, Visitor visitor, JObject validateResult )
        {
            //a,b,c[{a,b,c}],d
            var result = validateResult ?? new JObject();
            var hasValidation = false;
            

            foreach (var pair in this.ValidationSettings)
            {
                IValidatableProperty propAccessor = null;
                if (visitor == null)
                {
                    propAccessor = this[pair.Key] as IValidatableProperty;
                    
                }
                else {
                    Visitor subVisitor = null;
                    //if (visitor.Subsidaries.TryGetValue(pair.Key, out subVisitor)) {
                    //    propAccessor = subVisitor.Property as IValidatableProperty;
                    //}
                    

                }
                if (propAccessor == null) continue;

            }
            return hasValidation;

        }
    }
}
