using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button howToPlay;
    [SerializeField] private GameObject instructionsScreen;

    // Start is called before the first frame update
    void Start()
    {
        InitializeButtons();
        PlayBackgroundMusic();
    }

    private void InitializeButtons()
    {
        startButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        howToPlay.onClick.AddListener(ShowInstructionScreen);
    }

    private void PlayGame()
    {
        PlayButtonClickSound();

        int nextSceneIndex = CalculateNextSceneIndex();
        SceneManager.LoadScene(nextSceneIndex);
    }

    private int CalculateNextSceneIndex()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        return nextSceneIndex;
    }

    private void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    private void ShowInstructionScreen()
    {
        PlayButtonClickSound();
        instructionsScreen.SetActive(true);
    }

    private void HideInstructionsScreen()
    {
        if (instructionsScreen.activeSelf)
        {
            instructionsScreen.SetActive(false);
        }
    }

    private void PlayButtonClickSound()
    {
        AudioService.Instance.PlaySound(SoundType.ButtonClick);
    }

    private void Update()
    {
        HandleEscapeKey();
    }

    private void HandleEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideInstructionsScreen();
        }
    }

    private void PlayBackgroundMusic()
    {
        AudioService.Instance.PlaySound(SoundType.BackgroundMusic);
    }
}
