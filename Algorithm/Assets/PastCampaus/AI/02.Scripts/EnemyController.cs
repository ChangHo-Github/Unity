using Phantom.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom.Characters
{
    public class EnemyController : MonoBehaviour
    {
        #region Variables

        protected StateMachine<EnemyController> stateMachine;
        public StateMachine<EnemyController> StateMachine => stateMachine;

        private FieldOfView fov;

        //public LayerMask targetMask;
        //public Transform target;
        //public float viewRaius;
        public float attackRange;
        public Transform Target => fov?.NearestTarget;

        public Transform[] waypoints;
        [HideInInspector]
        public Transform targetWaypoint = null;
        private int waypointIndex = 0;

        #endregion Variables

        #region Unity Methods

        private void Start()
        {
            stateMachine = new StateMachine<EnemyController>(this, new MoveToWaypoints());
            IdleState idleState = new IdleState();
            idleState.isPatrol = true;
            stateMachine.AddState(new IdleState());
            stateMachine.AddState(new MoveState());
            stateMachine.AddState(new AttackState());

            fov = GetComponent<FieldOfView>();

        }

        private void Update()
        {
            stateMachine.Update(Time.deltaTime);
        }
        #endregion Unity Methods

        #region Other Methods
        public bool IsAvailableAttack
        {
            get
            {
                if(!Target)
                {
                    return false;
                }

                float distance = Vector3.Distance(transform.position, Target.position);
                return (distance <= attackRange);
            }
        }

        public Transform SearchEnemy()
        {
            return Target;
             
            //target = null;

            //Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRaius, targetMask);
            //if(targetInViewRadius.Length > 0)
            //{
            //    target = targetInViewRadius[0].transform;
            //}

            //return target;
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(transform.position, viewRaius);

        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireSphere(transform.position, attackRange);
        //}

        public Transform FindNextWayPoint()
        {
            targetWaypoint = null;
            if(waypoints.Length > 0)
            {
                targetWaypoint = waypoints[waypointIndex];
            }

            waypointIndex = (waypointIndex + 1) % waypoints.Length;

            return targetWaypoint;
        }

        #endregion Other Methods
    }
}


