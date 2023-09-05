using System;

// Custom attribute to tag methods
namespace FunctionUtils.Attribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class FunctionTagAttribute : System.Attribute
    {
        public string Tag { get; }

        // Constructor
        public FunctionTagAttribute(string tag)
        {
            Tag = tag;
        }
    }
}