using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _menuSceneIndex = 0;
    [SerializeField] private int _firstLevelSceneIndex = 1;
    [SerializeField] private int _gameOverSceneIndex = 4;
    [SerializeField] private int _endSceneIndex = 5;
    [SerializeField] private int _currentSceneIndex = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(_firstLevelSceneIndex);
    }

    public void LoadNextScene()
    {
        if (_currentSceneIndex < 0 || _currentSceneIndex >= SceneManager.sceneCount)
        {
            Debug.LogError($"_currentSceneIndex {_currentSceneIndex} is out of bounds");
        }

        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(_currentSceneIndex++).buildIndex);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(_gameOverSceneIndex);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(_endSceneIndex);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
