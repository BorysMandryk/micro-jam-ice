using UnityEngine;

namespace Player
{
    public class PlayerSpeedCalculator : MonoBehaviour
    {
        [SerializeField] private float _minSpeedByMass = 0.3f;

        private PlayerMovement _playerMovement;
        private PlayerTemperature _playerTemperature;
        private PlayerInventory _playerInventory;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerTemperature = GetComponent<PlayerTemperature>();
            _playerInventory = GetComponent<PlayerInventory>();
        }

        private void Start()
        {
            ChangeSpeed();
            _playerTemperature.OnChangeTemperature += ChangeSpeed;
            _playerInventory.OnChangeMass += ChangeSpeed;
        }

        private void ChangeSpeed()
        {   
            var massProportion = (float)(_playerInventory.MaxMass - _playerInventory.Mass)
                                 / _playerInventory.MaxMass;
            var speed = Mathf.Max(massProportion * _playerMovement.MaxSpeed, _minSpeedByMass);

            var temperatureProportion = _playerTemperature.Temperature / _playerTemperature.MaxTemperature;
            speed *= temperatureProportion;

            _playerMovement.Speed = speed;
        }
    }
}
