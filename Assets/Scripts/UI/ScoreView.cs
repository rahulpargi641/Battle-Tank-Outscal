using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private int nEnemyDestroyed;

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
        nEnemyDestroyed++;
        score.text = "Enemies Destroyed: " + nEnemyDestroyed.ToString();
    }
}
