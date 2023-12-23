using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletePresenter : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void Start()
    {
        StopBackgroundMusic();
    }

    private void PlayAgain()
    {
        int previousSceneIndex = CalculatePreviousSceneIndex();
        SceneManager.LoadScene(previousSceneIndex);
    }

    private int CalculatePreviousSceneIndex()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex < 1)
        {
            previousSceneIndex = 1;
        }
        return previousSceneIndex;
    }

    private void QuitGame()
    {
        Application.Quit();
        PlayButtonClickSound();
    }

    private void StopBackgroundMusic()
    {
        AudioService.Instance.StopSound(SoundType.BackgroundMusic);
    }

    private void PlayButtonClickSound()
    {
        AudioService.Instance.PlaySound(SoundType.ButtonClick);
    }
}
