using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button howToPlay;
    [SerializeField] GameObject instructionsScreen;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        howToPlay.onClick.AddListener(ShowInstructionScreen);

        AudioService.Instance.PlaySound(SoundType.BackgroundMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideInstructionsScreen();
        }
    }

    private void PlayGame()
    {
        PlayButtonClickSound();

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
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
}
