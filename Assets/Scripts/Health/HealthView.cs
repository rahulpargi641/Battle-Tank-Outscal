using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IDamageable
{
    public event Action onPlayerDeathAction;

    HealthModel healthModel;
    public Slider HealthSlider;
    public Image HealthFillImage;
    public Color FullHealthColor;
    public Color ZeroHealthColor;

    public int health;

    private void OnEnable()
    {
        healthModel = new HealthModel(health);
      
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        HealthSlider.value = healthModel.CurrentHealth;
        HealthFillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, healthModel.CurrentHealth / healthModel.MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        healthModel.CurrentHealth -= damage;   // remove damage magic number

        SetHealthUI();

        if (healthModel.CurrentHealth <= 0f && !healthModel.IsDead)
        { OnDeath(); }
    }

    private void OnDeath()
    {
        ParticleSystemService.Instance.SpawnParticles(new ParticleEvent(ParticleEventType.TankExplosion, transform.position));
        AudioService.Instance.PlayTankExplosionSound();

        PlayerTankView player = gameObject.GetComponent<PlayerTankView>();
        EnemyAIView enemy = gameObject.GetComponent<EnemyAIView>();

        if (player)
            EventService.Instance.InvokePlayerDeathAction();

        else if (enemy) 
            EventService.Instance.InvokeEnemyDeathAction();

        gameObject.SetActive(false);
    }
}