using System;
using UnityEngine;

namespace Player
{
    public class PlayerTemperature : MonoBehaviour
    {
        [field: SerializeField] public float MinTemperature { get; private set; } = 0f;
        [field: SerializeField] public float MaxTemperature { get; private set; } = 100f;
        
        [SerializeField] private float _temperature = 100f;
        public float Temperature
        {
            get => _temperature;
            set
            {
                _temperature = Mathf.Clamp(value, MinTemperature, MaxTemperature);
                OnChangeTemperature?.Invoke(_temperature);
            }
        }

        public event Action<float> OnChangeTemperature;
    }
}
