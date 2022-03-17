using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTest : MonoBehaviour
{
    // Player speed
    [SerializeField]
    private float speed = 3f;
    // Player jumpHeight
    [SerializeField]
    private float jumpHeight = 2f;
    // Player dash disatance
    [SerializeField]
    private float dashDistance = 5f;
    // Player air resistance
    [SerializeField]
    public Vector3 drags;

    // player bool isground false or true
    private bool isGround;
    // gravity
    private float gravity = -9.81f;


    private CharacterController characterController;
    private Vector3 playerVelocity;

    [SerializeField]
    private LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGround = characterController.isGrounded;        
        if (isGround && playerVelocity.y < 0)
        {
            // isGround 처리
            // [1] 중력을 바닥의 y값 크기 만큼 설정한다.
            playerVelocity.y = 0f;
            // [2] 중력을 계속 y값 크기에 증력 크기만큼 곱한다.
            //playerVelocity.y = gravity * 0.1f;           
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log("Dash");
            playerVelocity += Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * drags.x + 1)) / -Time.deltaTime),
                0,
                (Mathf.Log(1f / (Time.deltaTime * drags.z + 1)) / -Time.deltaTime))
                );
        }

        playerVelocity.x /= 1 + drags.x * Time.deltaTime;
        playerVelocity.y /= 1 + drags.y * Time.deltaTime;
        playerVelocity.z /= 1 + drags.z * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, 0.5f, groundLayerMask))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
