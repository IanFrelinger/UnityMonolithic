using UnityEngine;

namespace Interactions.Raycasting.Templates
{
    public abstract class RaycastStrategy : ScriptableObject
    {
        public abstract Ray GetRay();
    }
}