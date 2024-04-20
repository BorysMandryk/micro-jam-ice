using Player;
using System.Collections;
using UnityEngine;

namespace Bonfire
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private float _capacity = 100f;
        [SerializeField] private float _heatingRate = 10f;

        private PlayerTemperature _playerTemperature;
        private PlayerFreezer _playerFreezer;

        private bool _isActivated = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isActivated)
            {
                _isActivated = true;
                StartCoroutine(Burn());
            }

            if (collision.CompareTag("Player"))
            {
                _playerTemperature = collision.GetComponent<PlayerTemperature>();
                _playerFreezer = collision.GetComponent<PlayerFreezer>();
                _playerFreezer?.StopFreezing();
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _playerTemperature.Temperature += _heatingRate * Time.deltaTime;    
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _playerFreezer?.StartFreezing();
                _playerTemperature = null;
                _playerFreezer = null;
            }
        }

        private IEnumerator Burn()
        {
            while(_capacity > 0)
            {
                _capacity -= _heatingRate * Time.deltaTime;
                yield return null;
            }

            _playerFreezer?.StartFreezing();
            //enabled = false;
            gameObject.SetActive(false);
        }
    }
}