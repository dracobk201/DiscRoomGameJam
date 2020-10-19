using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace States
{

    public class WalkStraight : StateMachineBehaviour
    {
        [SerializeField] private EnemyMovementOnNavMesh enemyMovementOnNavMesh;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private StringVariable ExitStringConstant;
        [SerializeField] private FloatVariable MinIdleTime;
        [SerializeField] private FloatVariable MaxIdleTime;
        [SerializeField] private FloatVariable speed;
        [SerializeField] private float TimeLeft;
        [SerializeField] private Rigidbody stateRigidbody;
        [SerializeField] private Vector3 Direction;
        private float Speed;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Direction.Randomnize();
            TimeLeft = Random.Range(MinIdleTime.value, MaxIdleTime.value);
            Direction.y = 0;
            stateRigidbody = animator.GetComponent<Rigidbody>();
            enemyMovementOnNavMesh = animator.GetComponent<EnemyMovementOnNavMesh>();
            navMeshAgent = animator.GetComponent<NavMeshAgent>();
            navMeshAgent.SetDestination(enemyMovementOnNavMesh.RandomNavmeshLocation(15f));
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //stateRigidbody.MovePosition(stateRigidbody.position + (Direction * speed.value) * Time.deltaTime);
            TimeLeft -= Time.deltaTime;
            if (TimeLeft < 0)
            {
                animator.SetBool(ExitStringConstant.value, false);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
