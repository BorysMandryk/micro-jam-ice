using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [field: SerializeField] public float MinSpeed { get; private set; } = 0f;
        [field: SerializeField] public float MaxSpeed { get; private set; } = 5f;

        [SerializeField] private float _speed = 5f;
        public float Speed
        {
            get => _speed;
            set {
                _speed = Mathf.Clamp(value, 0f, 5f);
                Move();
            }
        }

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

        private void Move_performed(InputAction.CallbackContext ctx)
        {
            _direction = ctx.ReadValue<Vector2>();
            Move();
        }

        private void Move_canceled(InputAction.CallbackContext ctx)
        {
            _direction = Vector2.zero;
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = _direction * _speed;
        }
    }
}