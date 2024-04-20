using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody2D _rigidbody;
        private PlayerInputActions _playerInputActions;

        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerInputActions = new PlayerInputActions();

            _playerInputActions.Player.Move.performed += Move_performed;
            _playerInputActions.Player.Move.canceled += Move_canceled;
        }

        private void OnEnable()
        {
            _playerInputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Player.Disable();
        }

        public void ChangeSpeed(float multiplier)
        {
            _speed += multiplier;
            Move(_direction);
        }

        private void Move_performed(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<Vector2>();
            Move(_direction);
        }

        private void Move_canceled(InputAction.CallbackContext ctx)
        {
            _direction = Vector2.zero;
            Move(_direction);
        }

        private void Move(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}