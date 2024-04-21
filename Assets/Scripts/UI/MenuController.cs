using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _startButton.onClick.AddListener(GameManager.Instance.LoadFirstLevel);
            _exitButton.onClick.AddListener(GameManager.Instance.QuitApplication);
        }
    }
}