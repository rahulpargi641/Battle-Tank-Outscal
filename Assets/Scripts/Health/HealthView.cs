using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IDamageable
{
    public event Action onPlayerDeathAction;

    HealthModel healthModel;
    public Slider HealthSlider;
    public Image HealthFillImage;
    public Color FullHealthColor = Color.blue;
    public Color ZeroHealthColor = Color.red;

    private void Start()
    {
        SetHealthUI();
    }

    private void OnEnable()
    {
        healthModel = new HealthModel(100);
      
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        HealthSlider.value = healthModel.CurrentHealth;
        HealthFillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, healthModel.CurrentHealth / healthModel.MaxHealth);
    }

    private void OnDeath(Vector3 position)
    {
        ParticleSystemService.Instance.SpawnParticles(new ParticleEvent(ParticleEventType.TankExplosion, transform.position));
        AudioService.Instance.PlayTankExplosionSound();
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        healthModel.CurrentHealth -= damage;   // remove damage magic number

        SetHealthUI();

        if (healthModel.CurrentHealth <= 0f && !healthModel.IsDead)
        {
            OnDeath(transform.position);
        }
    }
}