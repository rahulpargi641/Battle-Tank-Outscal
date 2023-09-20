using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    float rotationSpeed = 2.0f;
    Transform fireTransform;
    int CurrentLaunchForce = 15;

    bool continueAttacking = true;

    bool isRotating = true; // Flag to control rotation

    public Attack(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Attack;
        fireTransform = enemyAIView.FireTransform;
    }

    public override void Enter()
    {
        //animator.SetTrigger("IsShooting");
        navMeshAgent.isStopped = true;
        isRotating = true; // Start rotating when entering attack state
        _ = FireAsync();
        CameraService.Instance.AddTarget(enemyAIView.gameObject.transform);
        base.Enter();
    }

    public override void Update()
    {
        Vector3 playerDirection = playerTransform.position - enemyAIView.transform.position;
        float facingtAngle = Vector3.Angle(playerDirection, enemyAIView.transform.forward);
        playerDirection.y = 0; // Update this 

        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
        enemyAIView.transform.rotation = Quaternion.Slerp(enemyAIView.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Check if the rotation has completed
        if (Quaternion.Angle(enemyAIView.transform.rotation, lookRotation) < 0.1f)
        {
            isRotating = false; // Stop rotating
        }

        if (!CanAttackPlayer())
        {
            nextState = new Idle(enemyAIView, navMeshAgent, animator, playerTransform);
            stage = EStage.Exit;
        }
    }

    public override void Exit()
    {
        //animator.ResetTrigger("IsShooting");
        continueAttacking = false; // Stop the attacking loop
        isRotating = true; // Restore rotation behavior when exiting attack state
        CameraService.Instance.RemoveTarget(enemyAIView.gameObject.transform);
        base.Exit();
    }

    protected override void EnemyDestroyed()
    {
        continueAttacking = false;
    }
    private async Task FireAsync()
    {
        while (continueAttacking)
        {
            await Task.Delay(1000);
            if(! isRotating)
            Fire();
        }
    }
    private void Fire()
    {
        ShellView shell = ShellService.Instance.SpawnShell(fireTransform);
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
        shellRigidbody.velocity = CurrentLaunchForce * fireTransform.forward;

        AudioService.Instance.PlayShotFiringSound();
    }
}
