using System;
using System.IO;
using UnityEngine;

namespace HelperClasses.Json.Implementation
{
    public static class GenericJsonHelper<TKeyType> where TKeyType : Enum
    {
        public static void SerializeToFile(TKeyType item,string filePath)
        {
            string json = JsonUtility.ToJson(item);
            File.WriteAllText(filePath, json);
        }

        public static TKeyType DeserializeFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<TKeyType>(json);
            }
            else
            {
                throw new Exception($"File not found at {filePath}");
            }
        }
    }
}