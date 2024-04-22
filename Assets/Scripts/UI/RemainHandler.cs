using Bonfire;
using Player;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RemainHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _remainNumberText;

        private PlayerInventory _playerInventory;

        private int _totalBonfires;

        private void Awake()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
            _totalBonfires = FindObjectsOfType<BonfireHandler>().Length;
        }

        private void Start()
        {
            ChangeRemain();
            _playerInventory.OnChangeMass += ChangeRemain;
        }

        private void ChangeRemain()
        {
            var remain = _totalBonfires - _playerInventory.Mass;
            _remainNumberText.text = remain.ToString();
            if (remain == 0)
            {
                StartCoroutine(LoadNextLevel());
            }
        }

        private IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(2);
            GameManager.Instance.LoadNextScene();
        } 
    }
}