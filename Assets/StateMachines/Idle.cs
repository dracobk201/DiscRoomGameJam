using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace States
{
    public class Idle : StateMachineBehaviour
    {
        [SerializeField] private StringVariable ExitStringConstant;
        [SerializeField] private FloatVariable MinIdleTime;
        [SerializeField] private FloatVariable MaxIdleTime;
        [SerializeField] private float TimeLeft;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            TimeLeft = Random.Range(MinIdleTime.value, MaxIdleTime.value);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft < 0)
            {
                animator.SetBool(ExitStringConstant.value, true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

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