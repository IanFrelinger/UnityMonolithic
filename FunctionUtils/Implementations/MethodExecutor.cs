using System;
using FunctionUtils.Templates;

// Executor class for invoking methods
namespace FunctionUtils.Implementations
{
    public class MethodExecutor
    {
        private readonly IMethodRetriever _methodRetriever;

        // Dependency Injection to allow for different implementations of IMethodRetriever in the future
        public MethodExecutor(IMethodRetriever methodRetriever)
        {
            _methodRetriever = methodRetriever;
        }

        // Execute methods with a specific tag
        public void ExecuteMethodsWithTag(object instance, string tag)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            var methods = _methodRetriever.GetMethodsWithTag(instance.GetType(), tag);
            foreach (var method in methods)
            {
                method.Invoke(instance, null);
            }
        }
    }
}