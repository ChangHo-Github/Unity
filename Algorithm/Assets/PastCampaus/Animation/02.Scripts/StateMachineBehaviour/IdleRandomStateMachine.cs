using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRandomStateMachine : StateMachineBehaviour
{
    #region Variables
    public int numberOfStates = 2;
    public float minNormalTime = 0f;
    public float maxNormalTime = 5f;

    public float randomNormalTime;

    readonly int hashRandowIdle = Animator.StringToHash("Randomidle");

    #endregion Variables

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Randomly decide a time at which to transition.
        randomNormalTime = Random.Range(minNormalTime, maxNormalTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If transitioning away from this state reset the random idle parameter to -1.
        if(animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
        {
            animator.SetInteger(hashRandowIdle, -1);
        }

        // If the state is beyond the randowly decide normalised time and not yet transitioning
        if (stateInfo.normalizedTime > randomNormalTime && !animator.IsInTransition(0))
        {
            animator.SetInteger(hashRandowIdle, Random.Range(0, numberOfStates));
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
