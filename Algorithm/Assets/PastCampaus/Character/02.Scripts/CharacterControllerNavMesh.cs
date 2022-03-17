using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerNavMesh : MonoBehaviour
{
    #region Variables
    private CharacterController characterController;
    private NavMeshAgent agent;

    [SerializeField]
    private LayerMask groundLayerMask;

    [SerializeField]
    private Animator animator;
    readonly int moveHash = Animator.StringToHash("Move");
    readonly int fallingHash = Animator.StringToHash("Falling");

    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = true;
    }

    // Update is called once per frame
    void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Make ray from sceen to world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check hit from ray
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, groundLayerMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                // Move out character to what we hit
                agent.SetDestination(hit.point);
            }

            if(agent.remainingDistance > agent.stoppingDistance)
            {
                characterController.Move(agent.velocity * Time.deltaTime);
                animator.SetBool(moveHash, true);
            }
            else
            {
                characterController.Move(Vector3.zero);
                animator.SetBool(moveHash, false);
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = agent.nextPosition;
    }
}
