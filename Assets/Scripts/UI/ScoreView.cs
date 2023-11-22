using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private int enemyDestroyed;

    private void Start()
    {
        EventService.Instance.OnEnemyDeathAction += UpdateScore;
    }

    private void OnDestroy()
    {
        EventService.Instance.OnEnemyDeathAction -= UpdateScore;
    }

    private void UpdateScore()
    {
        enemyDestroyed++;
        score.text = "Enemies Destroyed: " + enemyDestroyed.ToString();
    }
}
