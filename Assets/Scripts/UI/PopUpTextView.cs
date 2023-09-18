using System.Collections;
using TMPro;
using UnityEngine;

public class PopUpTextView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI achievementText;
    [SerializeField] TextMeshProUGUI shotsFiredText;
    [SerializeField] TextMeshProUGUI enemiesDestroyedText;

    private void OnEnable()
    {
        EventService.Instance.OnShotsFiredAction += ShowShotsFiredText;
        EventService.Instance.OnEnemiesDestroyedAction += ShowEnemiesDestroyedText;
    }
    private void OnDisable()
    {
        EventService.Instance.OnShotsFiredAction -= ShowShotsFiredText;
        EventService.Instance.OnEnemiesDestroyedAction -= ShowEnemiesDestroyedText;
    }

    private void ShowShotsFiredText(int nShotsFired)
    {
        string nShotsFiredText = nShotsFired + " Shots Fired";
        shotsFiredText.text = nShotsFiredText;
        ShowText(shotsFiredText, nShotsFiredText);
    }

    private void ShowEnemiesDestroyedText(int nEnemiesKilled)
    {
        string nEnemiesDestroyedText = nEnemiesKilled + " Enemies Destroyed";
        enemiesDestroyedText.text = nEnemiesDestroyedText;
        ShowText(enemiesDestroyedText, nEnemiesDestroyedText);
    }

    private void ShowText(TextMeshProUGUI text, string message)
    {
        text.text = message;
        text.gameObject.SetActive(true);
        achievementText.gameObject.SetActive(true);

        StartCoroutine(HideTextAfterDelay(text.gameObject));
    }

    private IEnumerator HideTextAfterDelay(GameObject textObject)
    {
        yield return new WaitForSeconds(3f);

        achievementText.gameObject.SetActive(false);
        textObject.SetActive(false);
    }
}
