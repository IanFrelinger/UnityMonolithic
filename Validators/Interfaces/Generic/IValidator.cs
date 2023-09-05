using JetBrains.Annotations;

namespace Validators.Interfaces.Generic
{
    public interface IValidator<in TInputType>
    {
        public string errorMessage { get; }
        [CanBeNull]
        public string ReturnErrorMessageIfInvalid(TInputType item);
    }
}