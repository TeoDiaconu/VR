using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    Vector3 velocity;
    float gravity = -9.81f;
    float smoothTime = 0.2f;
    Vector2 currentDirection = Vector2.zero;
    Vector2 currentDirectionVelocity = Vector2.zero;

    void Update()
    {
        Vector2 targetDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        targetDirection.Normalize();

        currentDirection = Vector2.SmoothDamp(currentDirection, targetDirection, ref currentDirectionVelocity, smoothTime);

        Vector3 move = transform.right * currentDirection.x + transform.forward * currentDirection.y;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y = gravity * 10;
        controller.Move(velocity);
    }
}
