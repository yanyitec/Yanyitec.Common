using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Validation
{
    public class ValidationResult
    {
        public object Value { get; set; }
        public object Entity { get; set; }
        public IValidatableProperty Property { get; set; }

        public ValidationRule ValidationRule { get; set; }
    }
}
