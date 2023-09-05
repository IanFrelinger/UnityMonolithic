using Validators.Interfaces.Generic;

namespace Validators.Implementations.StringValidators
{
    public class NullOrWhiteSpaceValidationStrategy : IValidationStrategy<string>
    {
        public string errorMessage => "Value is null or whitespace.";

        public string Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? errorMessage : null;
        }
    }
}