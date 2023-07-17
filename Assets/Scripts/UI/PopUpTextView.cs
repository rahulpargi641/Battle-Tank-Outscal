using TMPro;
using UnityEngine;

public class PopUpTextView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI achievementText;
    [SerializeField] TextMeshProUGUI shotsFiredText;
    [SerializeField] TextMeshProUGUI enemiesDestroyedText;

    private void OnEnable()
    {
        EventService.Instance.onShotsFiredAction += ShowShotsFiredText;
        EventService.Instance.onEnemyDeathAction += ShowEnemiesDestroyedText;
    }

    private void ShowShotsFiredText(int nShotsFired)
    {
        string nShotsFiredText = nShotsFired + " Shots Fired";
        shotsFiredText.text = nShotsFiredText;
        achievementText.gameObject.SetActive(true);
        shotsFiredText.gameObject.SetActive(true);
    }
    private void ShowEnemiesDestroyedText(int nEnemiesKilled)
    {
        string nEnemiesDestroyedText = nEnemiesKilled + " Enemies Destroyed";
        enemiesDestroyedText.text = nEnemiesDestroyedText;
        achievementText.gameObject.SetActive(true);
        enemiesDestroyedText.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        EventService.Instance.onShotsFiredAction -= ShowShotsFiredText;
        EventService.Instance.onEnemyDeathAction -= ShowEnemiesDestroyedText;
    }
}
