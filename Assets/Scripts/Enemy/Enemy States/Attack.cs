using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    float rotationSpeed = 2.0f;
    Transform fireTransform;
    int CurrentLaunchForce = 15;
  public Attack(GameObject npcGO, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(npcGO, navMeshAgent, animator, playerTransform)
    {
        state = EState.Attack;
        EnemyAIView enemyAIView = npcGO.GetComponent<EnemyAIView>();
        fireTransform = enemyAIView.FireTransform;
    }

    public override void Enter()
    {
        //animator.SetTrigger("IsShooting");
        navMeshAgent.isStopped = true;
        Fire();
        //AudioService.Instance.PlayShotFiringSound();
        base.Enter();
    }

    public override void Update()
    {
        Vector3 playerDirection = playerTransform.position - npcGO.transform.position;
        float facingtAngle = Vector3.Angle(playerDirection, npcGO.transform.forward);
        playerDirection.y = 0; // Update this 

        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
        npcGO.transform.rotation = Quaternion.Slerp(npcGO.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        if (!CanAttackPlayer())
        {
            nextState = new Idle(npcGO, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }

    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsShooting");
        //shoot.Stop();  audioplayer shoot stop 
        base.Exit();
    }

    private void Fire()
    {
       // model.Fired = true;

        ShellView shell = ShellService.Instance.SpawnShell(fireTransform);
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();

        // Rigidbody shellInstance = Instantiate(shellPrefab, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellRigidbody.velocity = CurrentLaunchForce * fireTransform.forward;

        AudioService.Instance.PlayShotFiringSound();

       // model.CurrentLaunchForce = model.MinLaunchForce;

        //model.NSHotsFired++;
        //AchievementService.Instance.ShotFired();
    }

    //public override void Update()
    //{
    //    Vector3 playerDirection = playerTransform.position - npcGO.transform.position;
    //    float facingAngle = Vector3.Angle(playerDirection, npcGO.transform.forward);
    //    playerDirection.y = 0;

    //    Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
    //    npcGO.transform.rotation = Quaternion.Slerp(npcGO.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

    //    if (!CanAttackPlayer())
    //    {
    //        nextState = new Pursue(npcGO, navMeshAgent, animator, playerTransform);
    //        stage = EStage.Exit;
    //    }
    //}
}
