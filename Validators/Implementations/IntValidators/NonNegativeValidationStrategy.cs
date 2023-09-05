using Validators.Interfaces.Generic;

namespace Validators.Implementations.IntValidators
{
    public class NonNegativeValidationStrategy : IValidationStrategy<int>
    {
        public string errorMessage => "Value is negative.";
        public string Validate(int value)
        {
            return value < 0 ? errorMessage : null;
        }
    }
}