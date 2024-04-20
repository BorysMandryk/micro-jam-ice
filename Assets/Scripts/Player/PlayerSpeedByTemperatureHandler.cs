using UnityEngine;

namespace Player
{
    public class PlayerSpeedByTemperatureHandler : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerTemperature _playerTemperature;

        private float _speedPerTemperature;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerTemperature = GetComponent<PlayerTemperature>();
        }

        private void Start()
        {
            _speedPerTemperature = _playerMovement.MaxSpeed / _playerTemperature.MaxTemperature;
            SetSpeedByTemperature(_playerTemperature.Temperature);
            _playerTemperature.OnChangeTemperature += SetSpeedByTemperature;
        }

        private void SetSpeedByTemperature(float temperature)
        {
            _playerMovement.Speed = temperature * _speedPerTemperature;
        }
    }
}
