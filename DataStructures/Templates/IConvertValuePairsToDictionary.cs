using System.Collections.Generic;

namespace DataStructures.Templates
{
    public interface IConvertValuePairsToDictionary<TKeyType, TValueType>
    {
        public Dictionary<TKeyType, TValueType> ToDictionary();
    }
}