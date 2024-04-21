using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _toMainMenuButton;

        private void Start()
        {
            _tryAgainButton.onClick.AddListener(GameManager.Instance.LoadFirstLevel);
            _toMainMenuButton.onClick.AddListener(GameManager.Instance.LoadMenuScene);
        }
    }
}