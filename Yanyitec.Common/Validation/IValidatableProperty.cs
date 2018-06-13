using System.Collections.Generic;

namespace Yanyitec.Validation
{
    public interface IValidatableProperty
    {
        IReadOnlyList<ValidationRule> ValidationRules { get; }

        ValidationResult Validate(object value, object entity);
    }
}