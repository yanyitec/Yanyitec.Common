using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Validation
{
    public class ValidationResults:Dictionary<string,ValidationResult>
    {
        public object Entity { get; set; }
        public IValidatableClass Class { get; set; }
    }
}
