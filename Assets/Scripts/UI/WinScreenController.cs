using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinScreenController : MonoBehaviour
    {
        [SerializeField] private Button _toMainMenuButton;

        private void Start()
        {
            _toMainMenuButton.onClick.AddListener(GameManager.Instance.LoadMenuScene);
        }
    }
}