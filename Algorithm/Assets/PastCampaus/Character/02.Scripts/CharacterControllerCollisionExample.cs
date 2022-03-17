using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerCollisionExample : MonoBehaviour
{
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ����
        if (controller.collisionFlags == CollisionFlags.None)
            print("Free floating!");

        // ����(�浹 ��ü ����)
        if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
            print("Touching sides!");

        if (controller.collisionFlags == CollisionFlags.Sides)
            print("Only touching sides, nothing else!");

        // ��(õ�忡 �ش�)
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
            print("Touching sides!");

        if (controller.collisionFlags == CollisionFlags.Above)
            print("Only touching Ceiling, nothing else!");

        // ���鿡 �ش�
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
            print("Touching ground!");

        if (controller.collisionFlags == CollisionFlags.Below)
            print("Only touching ground, nothing else!");
    }
}
