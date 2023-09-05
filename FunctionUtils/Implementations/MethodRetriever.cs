using System;
using System.Collections.Generic;
using System.Reflection;
using FunctionUtils.Attribute;
using FunctionUtils.Templates;

// Concrete implementation of method retriever
namespace FunctionUtils.Implementations
{
    public class MethodRetriever : IMethodRetriever
    {
        // Retrieve methods with a specific tag using reflection
        public IEnumerable<MethodInfo> GetMethodsWithTag(Type type, string tag)
        {
            foreach (var method in type.GetMethods())
            {
                var attributes = method.GetCustomAttributes(typeof(FunctionTagAttribute), false);
                if (attributes.Length > 0)
                {
                    var functionTagAttribute = (FunctionTagAttribute)attributes[0];
                    if (functionTagAttribute.Tag == tag)
                    {
                        yield return method;
                    }
                }
            }
        }
    }
}