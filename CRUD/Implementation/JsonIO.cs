using System;
using DataStructures.Implementations;
using HelperClasses.IO;
using HelperClasses.Json.Implementation;

namespace CRUD.Implementation
{
    public class JsonIO
    {
        private string _pathPrefix;
        public JsonIO(string pathPrefix)
        {
            _pathPrefix = pathPrefix;
        }
        public bool TryToSerializeFile<TKeyType>(TKeyType item, string filePath) where TKeyType : Enum
        {
            if (ValidateItem(item) && ValidateFilePath(filePath))
            {
                GenericJsonHelper<TKeyType>.SerializeToFile(item, filePath);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateItem<TKeyType>(TKeyType item) where TKeyType : Enum
        {
            if (item != null)
            {
                //To Do: Integrate this into the validator system
                throw new Exception("");
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool TryToSerializeFile<TKeyType, TValueType>(SerializableKeyValuePairWrapper<TKeyType, TValueType> wrapper, string filePath)
        {
            if (ValidateValuePairs(wrapper) && ValidateFilePath(filePath))
            {
                KeyValuePairJsonHelper.SerializeToFile(wrapper, filePath);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private bool ValidateValuePairs<TKeyType, TValueType>(SerializableKeyValuePairWrapper<TKeyType, TValueType> wrapper)
        {
            if (wrapper != null)
            {
                //To Do: Integrate this into the validator system
                throw new Exception("");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ValidateFilePath(string filePath)
        {
            var outcome = ValidatePath(filePath);
            if (outcome)
            {
                return true;
            }
            else
            {
                if (!outcome)
                {
                    //To Do: Integrate this into the validator system
                    throw new Exception("Path is not available.");
                }
                return false;
            }
        }
        private bool ValidatePath(string path)
        {
            return FileHelper.IsPathAvailable(path);
        }
    }
}