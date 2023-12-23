using UnityEngine;
using UnityEngine.UI;

public class ShootingView : MonoBehaviour
{
    public Transform fireTransform;
    public Slider aimSlider;

    private ShootingModel model;

    private void OnEnable()
    {
        model = new ShootingModel();
        model.CurrentLaunchForce = model.MinLaunchForce;
        aimSlider.value = model.MinLaunchForce;
    }

    void Start()
    {
        model.FireButton = "Fire1";
        model.ChargeSpeed = (model.MaxLaunchForce - model.MinLaunchForce) / model.MaxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        aimSlider.value = model.MinLaunchForce;  // by default aim slider is invisible 

        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (model.CurrentLaunchForce >= model.MaxLaunchForce && !model.Fired)
        {
            // at max charge, not yet fired
            model.CurrentLaunchForce = model.MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(model.FireButton))
        {
            // have fire pressed for the first time
            model.Fired = false;  // have not fired yet 
            model.CurrentLaunchForce = model.MinLaunchForce;

            AudioService.Instance.PlaySound(SoundType.ShotCharging);

        }
        else if (Input.GetButton(model.FireButton) && !model.Fired)
        {
            // Holding the fire button, not yet fired 
            model.CurrentLaunchForce += model.ChargeSpeed * Time.deltaTime;

            aimSlider.value = model.CurrentLaunchForce;
        }
        else if (Input.GetButtonUp(model.FireButton) && !model.Fired)
        {
            // We released the button, having not fired yet
            Fire();
        }
    }

    private void Fire()
    {
        model.Fired = true;

        ShellView shell = ShellService.Instance.SpawnShell(fireTransform);
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();

       // Rigidbody shellInstance = Instantiate(shellPrefab, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellRigidbody.velocity = model.CurrentLaunchForce * fireTransform.forward;

        AudioService.Instance.StopSound(SoundType.ShotCharging);
        AudioService.Instance.PlaySound(SoundType.ShotFiring);

        model.CurrentLaunchForce = model.MinLaunchForce;

        model.NSHotsFired++;
        AchievementService.Instance.ShotFired();
    }
}
