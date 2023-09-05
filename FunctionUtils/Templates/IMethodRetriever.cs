using System;
using System.Collections.Generic;
using System.Reflection;

// Interface for retrieving methods based on tag
namespace FunctionUtils.Templates
{
    public interface IMethodRetriever
    {
        IEnumerable<MethodInfo> GetMethodsWithTag(Type type, string tag);
    }
}