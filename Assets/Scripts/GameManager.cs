using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _menuSceneIndex = 0;
    private int _firstLevelSceneIndex = 1;
    private int _winSceneIndex = 3;
    private int _gameOverSceneIndex = 4;
    private int _currentSceneIndex = 0;

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
        _currentSceneIndex = _firstLevelSceneIndex;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadNextScene()
    {
        //if (_currentSceneIndex < 0 || _currentSceneIndex >= SceneManager.sceneCount)
        //{
        //    Debug.LogError($"_currentSceneIndex {_currentSceneIndex} is out of bounds");
        //}
        _currentSceneIndex++;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadMenuScene()
    {
        _currentSceneIndex = _menuSceneIndex;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadGameOverScene()
    {
        _currentSceneIndex = _gameOverSceneIndex;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void LoadWinScene()
    {
        _currentSceneIndex = _winSceneIndex;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
