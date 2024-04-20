using UnityEngine;

namespace Player
{
    public class PlayerSpeedByTemperatureHandler : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerTemperature _playerTemperature;
        
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            
            _playerTemperature = GetComponent<PlayerTemperature>();
            _playerTemperature.OnChangeTemperature += SetSpeedByTemperature;
        }

        private void SetSpeedByTemperature(float temperature)
        {
            var speedPerTemperature = _playerMovement.MaxSpeed / _playerTemperature.MaxTemperature;
            _playerMovement.Speed = temperature * speedPerTemperature;
            Debug.Log(_playerMovement.Speed);
        }
    }
}
