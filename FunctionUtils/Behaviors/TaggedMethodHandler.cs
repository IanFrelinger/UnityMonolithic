using System;
using System.Collections.Generic;
using System.Reflection;
using FunctionUtils.Templates;

namespace FunctionUtils.Behaviors
{
    public class TaggedMethodHandler : ITaggedMethodHandler
    {
        private readonly IMethodRetriever _methodRetriever;
        private object _instance;
        private List<MethodInfo> _cachedMethods;

        public TaggedMethodHandler(IMethodRetriever methodRetriever)
        {
            _methodRetriever = methodRetriever;
            _cachedMethods = new List<MethodInfo>();
        }

        // Cache methods with a specific tag
        public void CacheTaggedMethods(object instance, string tag)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            _instance = instance;
            _cachedMethods.AddRange(_methodRetriever.GetMethodsWithTag(instance.GetType(), tag));
        }

        // Execute the cached methods
        public void ExecuteCachedMethods()
        {
            foreach (var method in _cachedMethods)
            {
                method.Invoke(_instance, null);
            }
        }
    }
}