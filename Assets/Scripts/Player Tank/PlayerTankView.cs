using UnityEngine;
using UnityEngine.UI;

public class PlayerTankView: MonoBehaviour
{   
    public PlayerTankController playerMainTankController { private get; set; }

    public GameAudioController soundController { private get; set; }

    public Rigidbody Rigidbody { get; private set; }
    // Get these variables from scriptable objects 
    //public float m_Speed = 12f; //
    //public float m_TurnSpeed = 180f; // How many degrees it's gonna turn over time
    [Header("Tank Movement")]
    public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdling; 
    public AudioClip m_EngineDriving; 
    public float m_PitchRange = 0.2f; // Done

    private string m_MovementAxisName;
    private string m_TurnAxisName;

    private float m_TurnSpeed = 60;
    //private Rigidbody m_Rigidbody;
    private float m_Speed = 8f;

    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;  // Done

    [Header("Tank Health")]
    public Slider m_HealthSlider;
    public Image m_HealthFillImage;
    public Color m_FullHealthColor = Color.blue;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_ExplosionPrefab;

    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticlesPrefab;
    private float m_CurrentHealth;
    private bool m_Dead;
    private float m_MaxHealth = 100;

    [Header("Tank Shooting")]
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;


    private string m_FireButton;
    public float m_CurrentLaunchForce { get; private set; }
    public float m_ChargeSpeed { get; private set; }
    private bool m_Fired;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        //m_Rigidbody = Rigidbody;

        // Tank Health Controller
        m_ExplosionParticlesPrefab = GameObject.Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticlesPrefab.GetComponent<AudioSource>();

        m_ExplosionParticlesPrefab.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

        m_CurrentHealth = m_MaxHealth;
        m_Dead = false;

        SetHealthUI();



        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }

    //private void SetHealthUI()
    //{
    //    playerTankController.SetHealthUI();
    //}

    //internal void TakeDamage(float damage)
    //{
    //    playerTankController.ProcessHit();
    //}

    private void OnDisable()
    {
        Rigidbody.isKinematic = true;
    }

    private void Start()
    {
        //GameObject camera = GameObject.Find("CameraRig");
        //camera.transform.SetParent(gameObject.transform);

        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

        m_OriginalPitch = m_MovementAudio.pitch; // Done

        m_FireButton = "Fire1";

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }

    private void Update()
    {
        ReadMovementInput();
        EngineAudio();



        // Tank Shooting
        m_AimSlider.value = m_MinLaunchForce;  // by default aim slider is invisible 

        ProcessShellFiring();
    }

    private void ProcessShellFiring()
    {
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // at max charge, not yet fired
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(m_FireButton))
        {
            // have we pressed fire for the first time
            m_Fired = false;  // have not fired yet 
            m_CurrentLaunchForce = m_MinLaunchForce;

            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();

        }
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
            // Holding the fire button, not yet fired 
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
        }
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            // We released the button, having not fired yet
            Fire();
        }
    }

    private void EngineAudio()
    {
        if(Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        ProcessTankMovement();
        //playerTankController.MoveTank(m_MovementInputValue);
        ////Move();
        //playerTankController.Turn(m_TurnInputValue);
        ////Turn();
    }

    private void ReadMovementInput()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
    }

    private void ProcessTankMovement()
    {
        if (m_MovementInputValue != 0)
            playerMainTankController.MoveTank(m_MovementInputValue);

        if (m_TurnInputValue != 0)
            playerMainTankController.TurnTank(m_TurnInputValue);

        //Turn();
        //Move();

    }

   
    public void TakeDamage(float damage)
    {
        m_CurrentHealth -= damage;   // remove damage magic number

        SetHealthUI();

        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }

    public void SetHealthUI()
    {
        m_HealthSlider.value = m_CurrentHealth;
        m_HealthFillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_MaxHealth);
    }

    private void OnDeath()
    {
        m_Dead = true;
        m_ExplosionParticlesPrefab.transform.position = transform.position;
        m_ExplosionParticlesPrefab.gameObject.SetActive(true);
        m_ExplosionParticlesPrefab.Play();

        m_ExplosionAudio.Play();
        gameObject.SetActive(false);  // uncomment it
    }

    private void Fire()
    {
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }


    //Done refactoring
    //private void Turn()
    //{
    //    float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
    //    Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
    //    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    //}

    ////Done Refactoring
    //private void Move()
    //{
    //    Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
    //    m_Rigidbody.MovePosition(m_Rigidbody.position + movement); // moves to the absolute position you give it
    //}
}
