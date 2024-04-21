using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThermometerHandler : MonoBehaviour
    {
        private Slider _thermometer;
        private PlayerTemperature _playerTemperature;

        private void Awake()
        {
            _thermometer = GetComponent<Slider>();
            _playerTemperature = FindObjectOfType<PlayerTemperature>();
        }

        private void Start()
        {
            _thermometer.minValue = _playerTemperature.MinTemperature;
            _thermometer.maxValue = _playerTemperature.MaxTemperature;
            _thermometer.value = _playerTemperature.Temperature;

            _playerTemperature.OnChangeTemperature += () => _thermometer.value = _playerTemperature.Temperature;
        }
    }
}