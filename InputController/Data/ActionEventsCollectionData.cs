using System;
using CRUD.Implementation;
using DataStructures.Enums;
using DataStructures.Implementations;
using HelperClasses.Json.Implementation;
using InputController.Enums;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace InputController.Data
{
    [Serializable]
    public class ActionEventsCollectionData
    {
        private string _path;
        private JsonIO _jsonIO;
        public ActionEventsCollectionData(string pathPrefix,string path)
        {
            _path = path;
            _jsonIO = new JsonIO(pathPrefix);
        }
        
        [SerializeField]
        private SerializableKeyValuePairWrapper<UpdateDispatch, SerializableKeyValuePairWrapper<ActionType, UnityEvent>> actionTypeDB;
        public bool TryToSave()
        {
            return _jsonIO.TryToSerializeFile(actionTypeDB, _path);
        }
        [CanBeNull]
        public SerializableKeyValuePairWrapper<ActionType, UnityEvent> TryToPullSavedData()
        {
           return KeyValuePairJsonHelper.DeserializeFromFile<ActionType, UnityEvent>(_path);
        }
    }
}