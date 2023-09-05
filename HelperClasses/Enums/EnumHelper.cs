using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace HelperClasses.Enums
{
    /// <summary>
    /// Provides helper methods for working with enums.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Retrieves descriptions for the given enum type.
        /// </summary>
        /// <typeparam name="TDispatchEnum">The type of the enum.</typeparam>
        /// <returns>A dictionary mapping enum values to their descriptions.</returns>
        public static Dictionary<TDispatchEnum, string> GetEnumDescriptions<TDispatchEnum>() where TDispatchEnum : Enum
        {
            var descriptions = new Dictionary<TDispatchEnum, string>();

            foreach (var field in typeof(TDispatchEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    descriptions[(TDispatchEnum)field.GetValue(null)] = attribute.Description;
                else
                    descriptions[(TDispatchEnum)field.GetValue(null)] = field.Name;
            }
            return descriptions;
        }
    }
}