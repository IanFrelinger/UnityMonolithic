namespace Validators.Interfaces.Generic
{
    public interface IValidationStrategy<in T>
    {
        string errorMessage { get; }
        string Validate(T value);
    }
}