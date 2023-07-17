using UnityEngine;
using UnityEngine.UI;

public class ShootingView : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;

    private ShootingModel shootingModel;


    private void OnEnable()
    {
        shootingModel = new ShootingModel();
        shootingModel.CurrentLaunchForce = shootingModel.MinLaunchForce;
        m_AimSlider.value = shootingModel.MinLaunchForce;
    }

    void Start()
    {
        shootingModel.FireButton = "Fire1";

        shootingModel.ChargeSpeed = (shootingModel.MaxLaunchForce - shootingModel.MinLaunchForce) / shootingModel.MaxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Tank Shooting
        m_AimSlider.value = shootingModel.MinLaunchForce;  // by default aim slider is invisible 

        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (shootingModel.CurrentLaunchForce >= shootingModel.MaxLaunchForce && !shootingModel.Fired)
        {
            // at max charge, not yet fired
            shootingModel.CurrentLaunchForce = shootingModel.MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(shootingModel.FireButton))
        {
            // have we pressed fire for the first time
            shootingModel.Fired = false;  // have not fired yet 
            shootingModel.CurrentLaunchForce = shootingModel.MinLaunchForce;

            AudioService.Instance.PlayShotChargingSound();

        }
        else if (Input.GetButton(shootingModel.FireButton) && !shootingModel.Fired)
        {
            // Holding the fire button, not yet fired 
            shootingModel.CurrentLaunchForce += shootingModel.ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = shootingModel.CurrentLaunchForce;
        }
        else if (Input.GetButtonUp(shootingModel.FireButton) && !shootingModel.Fired)
        {
            // We released the button, having not fired yet
            Fire();
        }
    }

    private void Fire()
    {
        shootingModel.Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = shootingModel.CurrentLaunchForce * m_FireTransform.forward;

        AudioService.Instance.PlayShotFiringSound();

        shootingModel.CurrentLaunchForce = shootingModel.MinLaunchForce;

        shootingModel.NSHotsFired++;
        AchievementService.Instance.ShotFired();
    }
}
