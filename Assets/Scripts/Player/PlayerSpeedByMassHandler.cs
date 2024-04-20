using UnityEngine;

namespace Player
{
    public class PlayerSpeedByMassHandler : MonoBehaviour
    {
        [SerializeField] private float _minSpeed = 0.3f;

        private PlayerMovement _playerMovement;
        private PlayerInventory _playerInventory;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerInventory = GetComponent<PlayerInventory>();
        }

        private void Start()
        {
            SetSpeedByMass(_playerInventory.Mass);
            _playerInventory.OnChangeMass += SetSpeedByMass;
        }

        private void SetSpeedByMass(int mass)
        {
            var proportion = (float)(_playerInventory.MaxMass - mass) / _playerInventory.MaxMass;
            var speed = proportion * _playerMovement.Speed;
            _playerMovement.Speed = Mathf.Clamp(speed, _minSpeed, _playerMovement.MaxSpeed);
        }
    }
}
