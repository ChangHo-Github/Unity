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
        // 없음
        if (controller.collisionFlags == CollisionFlags.None)
            print("Free floating!");

        // 측면(충돌 본체 측면)
        if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
            print("Touching sides!");

        if (controller.collisionFlags == CollisionFlags.Sides)
            print("Only touching sides, nothing else!");

        // 위(천장에 해당)
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
            print("Touching sides!");

        if (controller.collisionFlags == CollisionFlags.Above)
            print("Only touching Ceiling, nothing else!");

        // 지면에 해당
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
            print("Touching ground!");

        if (controller.collisionFlags == CollisionFlags.Below)
            print("Only touching ground, nothing else!");
    }
}
