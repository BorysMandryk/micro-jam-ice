using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private GameObject _map;
        [SerializeField] private List<GameObject> _itemsToToggle;

        private PlayerInputActions _playerInputActions;

        private bool _isOpen;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.OpenMap.performed += ToggleOpenMap;
        }

        private void Start()
        {
            _isOpen = _map.activeSelf;
        }

        private void OnEnable()
        {
            _playerInputActions.Player.OpenMap.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Player.OpenMap.Disable();
        }

        private void ToggleOpenMap(InputAction.CallbackContext ctx)
        {
            _isOpen = !_isOpen;
            foreach (var item in _itemsToToggle)
            {
                item.SetActive(!_isOpen);
            }
            _map.SetActive(_isOpen);
        }
    }
}
