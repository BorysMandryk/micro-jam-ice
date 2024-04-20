using System;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [field: SerializeField] public int MinMass { get; private set; } = 0;
        [field: SerializeField] public int MaxMass { get; private set; } = 10;

        [SerializeField] private int _mass = 0;
        public int Mass
        {
            get => _mass; set
            {
                _mass = Mathf.Clamp(value, MinMass, MaxMass);
                OnChangeMass?.Invoke(_mass);
            }
        }

        public event Action<int> OnChangeMass;

        // TODO: remove
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Mass += 1;
            }   
        }
    }
}