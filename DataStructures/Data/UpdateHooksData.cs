using System;
using System.Collections.Generic;
using CRUD.Implementation;
using DataStructures.Enums;
using UnityEngine;
using System.Linq;

namespace DataStructures.Data
{
    [Serializable]
    public class UpdateHooksData
    {
        [SerializeField] 
        private List<UpdateDispatch> selectedHooks;
        public List<UpdateDispatch> SelectedHooks => selectedHooks;
        private JsonIO _jsonIO;
        private string _pathPrefix;

        public UpdateHooksData(JsonIO jsonIO, string pathPrefix)
        {
            _jsonIO = jsonIO;
            _pathPrefix = pathPrefix;
        }

        public bool SerializeData(string pathExtension)
        {
            var completePath = _pathPrefix + pathExtension;
            //Do Potential Check To See If This is a Valid Path
            
            foreach (var dispatch in selectedHooks)
            {
                var item =  TryToSerializeItem(dispatch,completePath);
                if (item == false)
                {
                    return false;
                }
            }
            return true;
        }
        private bool TryToSerializeItem(UpdateDispatch item, string completePath)
        {
            var outcome = _jsonIO.TryToSerializeFile(item, completePath);
            return outcome;
        }

        private List<UpdateDispatch> FilterList(List<UpdateDispatch> items)
        {
            return items.Distinct().ToList();
        }
    }
}