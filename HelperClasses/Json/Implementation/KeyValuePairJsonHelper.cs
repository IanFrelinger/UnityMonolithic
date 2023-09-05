using System.IO;
using DataStructures.Implementations;
using UnityEngine;

namespace HelperClasses.Json.Implementation
{
    public static class KeyValuePairJsonHelper
    {
        public static void SerializeToFile<TKeyType, TValueType>(SerializableKeyValuePairWrapper<TKeyType, TValueType> wrapper, string filePath)
        {
            string json = JsonUtility.ToJson(wrapper);
            File.WriteAllText(filePath, json);
        }
        public static SerializableKeyValuePairWrapper<TKeyType, TValueType> DeserializeFromFile<TKeyType, TValueType>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<SerializableKeyValuePairWrapper<TKeyType, TValueType>>(json);
            }
            else
            {
                Debug.LogError($"File not found at {filePath}");
                return null;
            }
        }
    }
}