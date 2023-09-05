using Interactions.Pickup.Templates;
using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions.Pickup.Components
{
    [RequireComponent(typeof(Renderer))]
    public class PickupTarget : MonoBehaviour, IPickupable
    {
        private Renderer _rend;
        private Rigidbody _rigidBody;

        [FormerlySerializedAs("colorSettings")] public ColorSettingsSo colorSettingsSo;
        private static Transform _playerTransform; // Caching player's transform

        private void Start()
        {
            _rend = GetComponent<Renderer>();
            _rigidBody = GetComponent<Rigidbody>();

            SetColors();

            if (_playerTransform == null)
            {
                _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        private void SetColors()
        {
            if (_rend != null && colorSettingsSo != null)
            {
                colorSettingsSo.originalColor = _rend.material.color;
            }
        }

        public void Pickup()
        {
            transform.SetParent(_playerTransform);
            if (_rigidBody) _rigidBody.isKinematic = true;
        }

        public void Drop()
        {
            transform.SetParent(null);
            if (_rigidBody) _rigidBody.isKinematic = false;
        }

        private void OnMouseOver()
        {
            Highlight(true);
        }

        private void OnMouseExit()
        {
            Highlight(false);
        }

        private void Highlight(bool isHighlighted)
        {
            if (_rend != null && colorSettingsSo != null)
            {
                _rend.material.color = isHighlighted ? colorSettingsSo.highlightColor : colorSettingsSo.originalColor;
            }
        }
    }
}