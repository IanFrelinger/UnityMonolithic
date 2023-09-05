using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validators.Interfaces.Generic;

namespace Validators.Implementations.Generic
{
    public class GenericValidator<T, TDispatchEnum> : IValidator<T> where TDispatchEnum : Enum
    {
        private readonly List<IValidationStrategy<T>> _strategies = new();

        public GenericValidator(TDispatchEnum type)
        {
            InitializeStrategies(type);
        }
        private void InitializeStrategies(TDispatchEnum type)
        {
            // Convert the enum to string, assume this name is a class name
            var strategyName = type.ToString() + "ValidationStrategy";

            // Try to get the strategy type from the current assembly
            var strategyType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Equals(strategyName) && typeof(IValidationStrategy<T>).IsAssignableFrom(t));

            if (strategyType != null)
            {
                if (Activator.CreateInstance(strategyType) is IValidationStrategy<T> strategy)
                {
                    _strategies.Add(strategy);
                }
            }
            else
            {
                // You can throw an exception or handle this situation as required.
                Console.WriteLine($"No validation strategy found for {strategyName}.");
            }
        }

        public string errorMessage
        {
            get
            {
                foreach (var strategy in _strategies)
                {
                    if (!string.IsNullOrEmpty(strategy.errorMessage))
                        return strategy.errorMessage;
                }
                return "Unknown validation error.";
            }
        }

        public string ReturnErrorMessageIfInvalid(T value)
        {
            foreach (var strategy in _strategies)
            {
                var error = strategy.Validate(value);
                if (!string.IsNullOrEmpty(error))
                    return error;
            }
            return null;
        }
    }
}
