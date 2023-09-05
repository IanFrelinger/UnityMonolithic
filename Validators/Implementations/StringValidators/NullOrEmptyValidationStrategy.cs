using Validators.Interfaces.Generic;

namespace Validators.Implementations.StringValidators
{
    public class NullOrEmptyValidationStrategy : IValidationStrategy<string>
    {
        public string errorMessage => "Value is null or empty.";

        public string Validate(string value)
        {
            return string.IsNullOrEmpty(value) ? errorMessage : null;
        }
    }
}