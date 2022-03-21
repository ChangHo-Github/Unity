using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRaidus = 5f;
    [Range(0, 360)]
    public float viewAngle = 90f;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private List<Transform> visibleTargets = new List<Transform>();
    private Transform nearestTarget;
    private float distanceToTarget = 0.0f;

    public float delay = 0.2f;

    public List<Transform> VisibleTargets => visibleTargets;
    public Transform NearestTarget => nearestTarget;

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", delay);    
    }

    void Update()
    {
        FindVisiableTargets();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisiableTargets();
        }
    }

    void FindVisiableTargets()
    {
        distanceToTarget = 0.0f;
        nearestTarget = null;
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRaidus, targetMask);
        for(int i = 0; i < targetsInViewRadius.Length; ++i)
        {
            Transform target = targetsInViewRadius[i].transform;

            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    if (nearestTarget == null || (distanceToTarget > dstToTarget))
                    {
                        nearestTarget = target;
                        distanceToTarget = dstToTarget;
                    }
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegress, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegress += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegress * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegress * Mathf.Deg2Rad));
    }
}
