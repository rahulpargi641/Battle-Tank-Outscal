using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IDamageable
{
    public Slider HealthSlider;
    public Image HealthFillImage;
    public Color FullHealthColor;
    public Color ZeroHealthColor;
    public int health; // Max health

    private HealthModel healthModel;

    private void OnEnable()
    {
        InitializeHealthModel();
        SetHealthUI();
    }

    private void InitializeHealthModel()
    {
        healthModel = new HealthModel(health);
    }

    private void SetHealthUI()
    {
        HealthSlider.value = healthModel.CurrentHealth;
        HealthFillImage.color = CalculateHealthColor();
    }

    private Color CalculateHealthColor()
    {
        return Color.Lerp(ZeroHealthColor, FullHealthColor, healthModel.CurrentHealth / healthModel.MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        healthModel.CurrentHealth -= damage;

        SetHealthUI();

        if (healthModel.CurrentHealth <= 0f && !healthModel.IsDead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        SpawnDeathParticles();
        PlayDeathSound();

        HandleDeathEvent();

        gameObject.SetActive(false);
    }

    private void SpawnDeathParticles()
    {
        ParticleSystemService.Instance.SpawnParticles(new ParticleEvent(ParticleEventType.TankExplosion, transform.position));
    }

    private void PlayDeathSound()
    {
        AudioService.Instance.PlaySound(SoundType.TankExplosion);
    }

    private void HandleDeathEvent()
    {
        PlayerTankView player = gameObject.GetComponent<PlayerTankView>();
        EnemyAIView enemy = gameObject.GetComponent<EnemyAIView>();

        if (player)
        {
            EventService.Instance.InvokePlayerDeathEvent();
        }
        else if (enemy)
        {
            EventService.Instance.InvokeEnemyDeathEvent();
        }
    }
}
