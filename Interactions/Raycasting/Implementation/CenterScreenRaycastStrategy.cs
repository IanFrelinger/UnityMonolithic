using Interactions.Raycasting.Templates;
using UnityEngine;

namespace Interactions.Raycasting.Implementation
{
    [CreateAssetMenu(menuName = "Raycast Strategies/From Center of Screen")]
    public class CenterScreenRaycastStrategy : RaycastStrategy
    {
        public override Ray GetRay()
        {
            return Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        }
    }
}