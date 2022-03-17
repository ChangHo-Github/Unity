using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerManager : MonoBehaviour
{
    #region Variables

    public float speed = 5f;
    public float jumpHeight = 2f;
    public float dashDistance = 5f;

    public float gravity = -9.81f;
    public Vector3 drags;

    private CharacterController characterController;

    private bool isGraunded = false;
    public float groundCheckDistance = 0.2f;

    private Vector3 calcVelocity = Vector3.zero;

    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGraunded = characterController.isGrounded;
        if(isGraunded && calcVelocity.y < 0.1)
        {
            calcVelocity.y = 0;
        }

        // Process move inputs
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);
        if ( move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Process jump input
        if (Input.GetButtonDown("Jump") && isGraunded)
        {
            calcVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Dash"))
        {
            calcVelocity = Vector3.Scale(transform.forward, 
                dashDistance * new Vector3(Mathf.Log(1f / (Time.deltaTime * drags.x + 1)) / -Time.deltaTime, 
                0, 
                (Mathf.Log(1f / (Time.deltaTime * drags.z + 1)) / -Time.deltaTime)));

        }

        // Progress gravity
        calcVelocity.y += gravity * Time.deltaTime;

        // Process dash ground drags
        calcVelocity.x /= 1 + drags.x * Time.deltaTime;
        calcVelocity.y /= 1 + drags.y * Time.deltaTime;
        calcVelocity.z /= 1 + drags.z * Time.deltaTime;

        characterController.Move(calcVelocity * Time.deltaTime);
    }
}
