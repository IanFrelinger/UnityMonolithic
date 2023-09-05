using Interactions.Raycasting.Templates;
using UnityEngine;

namespace Interactions.Raycasting.Implementation
{
    [CreateAssetMenu(menuName = "Raycast Strategies/From Mouse")]
    public class MouseRaycastStrategy : RaycastStrategy
    {
        public override Ray GetRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}