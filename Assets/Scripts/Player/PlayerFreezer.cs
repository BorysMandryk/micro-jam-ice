using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerFreezer : MonoBehaviour
    {
        [SerializeField] private float _freezeRate = 5f;

        private PlayerTemperature _playerTemperature;

        private Coroutine _freezeCoroutine;

        private void Awake()
        {
            _playerTemperature = GetComponent<PlayerTemperature>();
        }

        private void Start()
        {
            StartFreezing();
        }

        public void StartFreezing()
        {
            _freezeCoroutine = StartCoroutine(Freeze());
        }

        public void StopFreezing()
        {
            if (_freezeCoroutine == null)
            {
                return;
            }

            StopCoroutine(_freezeCoroutine);
        }

        private IEnumerator Freeze()
        {
            while (true)
            {
                _playerTemperature.Temperature -= _freezeRate * Time.deltaTime;
                Debug.Log("Freeze: " + _playerTemperature.Temperature); // TODO: remove
                yield return null;
            }
        }
    }
}