using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Templates;
using UnityEngine;

namespace DataStructures.Implementations
{
    [Serializable]
    public class SerializableKeyValuePairWrapper<TKeyType, TValueType> : IConvertValuePairsToDictionary<TKeyType, TValueType>
    {
        [SerializeField] 
        private List<SerializableKeyValuePair<TKeyType, TValueType>> items;
        public List<SerializableKeyValuePair<TKeyType, TValueType>> Items => items;
        public SerializableKeyValuePairWrapper(List<SerializableKeyValuePair<TKeyType, TValueType>> serializableKeyValuePairWrapper)
        {
            items = serializableKeyValuePairWrapper;
        }

        public Dictionary<TKeyType, TValueType> convertedItems => ToDictionary();
        public Dictionary<TKeyType, TValueType> ToDictionary()
        {
            //This Needs to updated potentially to account for different platforms where LINQ is not a good choice
            return items.ToDictionary(item => item.key, item => item.value);
        }
    }
}