using Interactions.Pickup.Templates;
using Interactions.Raycasting.Behaviors;
using UnityEngine;

namespace Interactions.Pickup.Behaviors
{
    [RequireComponent(typeof(Raycaster))]
    public class PickupSystem : MonoBehaviour
    {
        private Raycaster _raycaster;
        private IPickupable _heldObject;
        public float pickupRange = 2f;

        private void Awake()
        {
            _raycaster = GetComponent<Raycaster>();
        }

        private void Update()
        {
            // Separate the logic for picking up and dropping for clarity.
            if (Input.GetMouseButtonDown(0)) // For picking up
            {
                TryPickup();
            }
            else if (Input.GetMouseButtonDown(1)) // Right mouse button for dropping
            {
                DropHeldObject();
            }
        }

        private void TryPickup()
        {
            if (_raycaster.CastRay(out RaycastHit hitInfo) && hitInfo.distance <= pickupRange)
            {
                var target = hitInfo.collider.GetComponent<IPickupable>();
                if (target != null && _heldObject == null)
                {
                    target.Pickup();
                    _heldObject = target;
                }
            }
        }

        private void DropHeldObject()
        {
            if (_heldObject != null)
            {
                _heldObject.Drop();
                _heldObject = null;
            }
        }
    }
}