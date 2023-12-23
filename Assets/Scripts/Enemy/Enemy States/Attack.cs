using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Attack : EnemyState
{
    private const float RotationSpeed = 2.0f;
    private const int CurrentLaunchForce = 15;
    private const int AttackIntervalMilliseconds = 1000;

    private Transform fireTransform;
    private bool continueAttacking = true;
    private bool isRotating = true; // Flag to control rotation

    public Attack(EnemyAIView enemyAIView, NavMeshAgent navMeshAgent, Animator animator, Transform playerTransform)
        : base(enemyAIView, navMeshAgent, animator, playerTransform)
    {
        state = EState.Attack;
        fireTransform = enemyAIView.FireTransform;
    }

    public override void Enter()
    {
        navMeshAgent.isStopped = true;
        isRotating = true; // Start rotating when entering the attack state
        _ = FireAsync();

        CameraService.Instance.AddTarget(enemyAIView.gameObject.transform); // Camera focuses on the enemy tank as well

        base.Enter();
    }

    public override void Update()
    {
        RotateTowardsPlayer();

        if (!CanAttackPlayer())
        {
            TransitionToState<Idle>();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 playerDirection = playerTransform.position - enemyAIView.transform.position;
        float facingAngle = Vector3.Angle(playerDirection, enemyAIView.transform.forward);
        playerDirection.y = 0; // Update this 

        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
        enemyAIView.transform.rotation = Quaternion.Slerp(enemyAIView.transform.rotation, lookRotation, RotationSpeed * Time.deltaTime);

        // Check if the rotation or enemy turning towards the player has completed
        if (Quaternion.Angle(enemyAIView.transform.rotation, lookRotation) < 0.1f)
        {
            isRotating = false; // Stop rotating
        }
    }

    public override void Exit()
    {
        continueAttacking = false; // Stop the attacking loop
        isRotating = true; // Restore rotation behavior when exiting the attack state

        CameraService.Instance.RemoveTarget(enemyAIView.gameObject.transform);

        base.Exit();
    }

    protected override void EnemyDestroyed()
    {
        continueAttacking = false;
    }

    private async Task FireAsync() // Keeps attacking at a 1-second interval
    {
        while (continueAttacking)
        {
            await Task.Delay(AttackIntervalMilliseconds);

            if (!isRotating) // Check if the enemy tank is trying to get into the position for attacking
                Fire();
        }
    }

    private void Fire()
    {
        ShellView shell = ShellService.Instance.SpawnShell(fireTransform);
        Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
        shellRigidbody.velocity = CurrentLaunchForce * fireTransform.forward;

        AudioService.Instance.PlaySound(SoundType.ShotFiring);
    }
}
