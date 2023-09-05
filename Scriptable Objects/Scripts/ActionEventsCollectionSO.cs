using InputController.Data;
using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(fileName = "FILENAME", 
        menuName = "MENUNAME", order = 0)]
    public class ActionEventsCollectionSo : ScriptableObject
    {
        [SerializeField] private ActionEventsCollection actionCollection;
        public ActionEventsCollection actionsCollection => actionCollection;
    }
}