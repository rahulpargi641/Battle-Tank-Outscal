using UnityEngine;

public class ShellView : MonoBehaviour
{
    [SerializeField] LayerMask tankMask;

    private ShellModel model;

    private void Awake()
    {
        model = new ShellModel();
    }
    private void Start()
    {
        //Destroy(gameObject, model.MaxLifeTime);
    }

    private void OnTriggerEnter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, model.ExplosionRadius, tankMask);

        DoExplosionAndDamageToSurroundings(colliders);

        ParticleSystemService.Instance.SpawnParticles(new ParticleEvent(ParticleEventType.ShellExplosion, transform.position));
        AudioService.Instance.PlayShellExplosionSound();
        ShellService.Instance.ReturnShellToPool(this);
    }

    private void DoExplosionAndDamageToSurroundings(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (! targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(model.ExplosionForce, transform.position, model.ExplosionRadius);
            HealthView targetHealth = targetRigidbody.GetComponent<HealthView>();
            if (! targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);
            targetHealth.TakeDamage(damage);
        }
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (model.ExplosionRadius - explosionDistance) / model.ExplosionRadius;

        float damage = relativeDistance * model.MaxDamage;

        damage = Mathf.Max(0, damage);
        return damage;
    }
}
