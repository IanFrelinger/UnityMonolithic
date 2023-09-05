using System.Collections.Generic;
using InputController.Templates.ActionCheck;
using InputController.Templates.InputStrats.Touch;
using InputController.Templates.InputStrats.Update;
using UnityEngine;

namespace InputController.Implementations.Mobile.Strats
{
    /// <summary>
    /// Enhanced input strategy for mobile platforms, supporting more touch gestures.
    /// </summary>
    public class EnhancedMobileInputStrategy : ITouchInputStrategy, IUpdatableInputStrategy, 
        IFixedUpdateInputStrategy, ILateUpdateInputStrategy
    {
        private readonly MobileInputStrategy _mobileInputStrategy = new MobileInputStrategy();
        private Vector2 _startTouchPosition;
        private bool _isSwiping;
        
        public float swipeThreshold = 100f;  // Configurable swipe threshold

        public bool TryGetPickupAction()
        {
            return _mobileInputStrategy.TryGetPickupAction();
        }
        public bool TryGetDropAction()
        {
            return _mobileInputStrategy.TryGetDropAction();
        }
        public List<IActionCheck> GetActionChecks()
        {
            throw new System.NotImplementedException();
        }
        public Touch? GetSingleTouch()
        {
            if (Input.touchCount == 1)
                return Input.GetTouch(0);
            return null;
        }
        public (Touch?, Touch?) GetPinchTouches()
        {
            if (Input.touchCount == 2)
                return (Input.GetTouch(0), Input.GetTouch(1));
            return (null, null);
        }
        public bool TryGetSwipeLeftAction()
        {
            // Checks for swipe action to the left
            return TryGetSwipeAction(-swipeThreshold);
        }
        public bool TryGetSwipeRightAction()
        {
            // Checks for swipe action to the right
            return TryGetSwipeAction(swipeThreshold);
        }
        private bool TryGetSwipeAction(float threshold)
        {
            if (_isSwiping && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if ((Input.GetTouch(0).position.x - _startTouchPosition.x) > threshold)
                {
                    _isSwiping = false;
                    return true;
                }
            }
            return false;
        }
        public void UpdateSwipe()
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _startTouchPosition = Input.GetTouch(0).position;
                    _isSwiping = true;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    _isSwiping = false;
                }
            }
        }
        public void Tick()
        {
            UpdateSwipe();
        }
        private void FixedUpdate()
        {
            FixedTick();
        }
        private void LateUpdate()
        {
            LateTick();
        }
        public void FixedTick()
        {
            throw new System.NotImplementedException();
        }
        public void LateTick()
        {
            throw new System.NotImplementedException();
        }
    }
}
