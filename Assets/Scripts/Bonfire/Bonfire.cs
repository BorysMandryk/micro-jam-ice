using Player;
using System.Collections;
using UnityEngine;

namespace Bonfire
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private float _capacity = 100f;
        [SerializeField] private float _heatingRate = 10f;

        private bool _isActivated = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isActivated)
            {
                return;
            }

            if (collision.CompareTag("Player"))
            {
                _isActivated = true;
                StartCoroutine(Burn());
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var playerTemperature = collision.GetComponent<PlayerTemperature>();
                playerTemperature.Temperature += _heatingRate * Time.deltaTime;
            }
        }

        private IEnumerator Burn()
        {
            while(_capacity > 0)
            {
                _capacity -= _heatingRate * Time.deltaTime;
                yield return null;
            }

            enabled = false;
        }
    }
}