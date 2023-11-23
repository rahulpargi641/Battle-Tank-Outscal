using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IDamageable
{
    public Slider HealthSlider;
    public Image HealthFillImage;
    public Color FullHealthColor;
    public Color ZeroHealthColor;

    public int health;

    private HealthModel healthModel;


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
        AudioService.Instance.PlaySound(SoundType.TankExplosion);

        PlayerTankView player = gameObject.GetComponent<PlayerTankView>();
        EnemyAIView enemy = gameObject.GetComponent<EnemyAIView>();

        if (player)
            EventService.Instance.InvokePlayerDeathEvent();

        else if (enemy) 
            EventService.Instance.InvokeEnemyDeathEvent();

        gameObject.SetActive(false);
    }
}