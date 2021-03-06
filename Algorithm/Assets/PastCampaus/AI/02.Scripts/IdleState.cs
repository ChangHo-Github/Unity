using Phantom.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom.Characters
{
    public class IdleState : State<EnemyController>
    {
        public bool isPatrol = true;
        private float minIdleTime = 0.0f;
        private float maxIdleTime = 3.0f;
        private float idleTime = 0.0f;

        private Animator animator;
        private CharacterController controller;

        protected int hashMove = Animator.StringToHash("Move");
        protected int hashMoveSpeed = Animator.StringToHash("MoveSpeed");

        public override void OnInitialized()
        {
            animator = context.GetComponent<Animator>();
            controller = context.GetComponent<CharacterController>();

            if (isPatrol)
            {
                idleTime = Random.Range(minIdleTime, maxIdleTime);
            }
        }

        public override void OnEnter()
        {
            animator?.SetBool(hashMove, false);
            animator?.SetFloat(hashMoveSpeed, 0);
            controller?.Move(Vector3.zero);
        }

        public override void Update(float deltaTime)
        {
            Transform enemy = context.SearchEnemy();
            if (enemy)
            {
                if (context.IsAvailableAttack)
                {
                    stateMachine.ChangeState<AttackState>();
                }
                else
                {
                    stateMachine.ChangeState<MoveState>();
                }
            }
            else if (isPatrol && stateMachine.ElapsedTimeInState > idleTime)
            {
                stateMachine.ChangeState<MoveToWaypoints>();
            }
        }

        public override void OnExit()
        {

        }
    }
}


