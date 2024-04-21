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
                if (value < MinMass || value > MaxMass)
                {
                    return;
                }

                _mass = value;
                OnChangeMass?.Invoke();
            }
        }

        public event Action OnChangeMass;

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