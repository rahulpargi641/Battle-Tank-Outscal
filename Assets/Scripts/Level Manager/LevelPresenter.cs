using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private bool isPaused = false;
    private LevelModel model;

    private void Awake()
    {
        model = new LevelModel();
        InitializeUI();
    }

    private void InitializeUI()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);

        SetPauseScreenActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        SubscribeToEvents();
        PlayBackgroundMusic();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        EventService.Instance.onLevelCompleteAction += LevelComplete;
        EventService.Instance.OnPlayerDeathAction += GameOver;
    }

    private void UnsubscribeFromEvents()
    {
        EventService.Instance.onLevelCompleteAction -= LevelComplete;
        EventService.Instance.OnPlayerDeathAction -= GameOver;
    }

    private void PlayBackgroundMusic()
    {
        AudioService.Instance.PlaySound(SoundType.BackgroundMusic);
    }

    private void Update()
    {
        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        SetPauseScreenActive(true);
        Time.timeScale = 0; // Pause time
        SetCursorVisibleAndLocked(false);
    }

    private void ResumeGame()
    {
        isPaused = false;
        SetPauseScreenActive(false);
        Time.timeScale = 1; // Resume time
        SetCursorVisibleAndLocked(true);
    }

    private void SetPauseScreenActive(bool isActive)
    {
        pauseScreen.SetActive(isActive);
    }

    private void SetCursorVisibleAndLocked(bool isVisibleAndLocked)
    {
        Cursor.visible = isVisibleAndLocked;
        Cursor.lockState = isVisibleAndLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitGame()
    {
        Application.Quit();
        AudioService.Instance.PlaySound(SoundType.ButtonClick);
    }

    private void LevelComplete()
    {
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(model.LevelLoadDelay);
        StopEngineSound();
        int levelCompleteIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(levelCompleteIndex);
    }

    private void GameOver()
    {
        StartCoroutine(LoadGameOverScene());
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(model.LevelLoadDelay);
        StopEngineSound();
        int gameOverSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(gameOverSceneIndex);
    }

    private void StopEngineSound()
    {
        AudioService.Instance.StopEngineSound();
    }
}
