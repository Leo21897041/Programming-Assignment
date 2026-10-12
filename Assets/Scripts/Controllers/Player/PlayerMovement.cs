using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 velocity;

    [Header("Acceleration")]
    public float acceleration;
    public float accelerationTime;
    public float maxSpeed;

    [Header("Decceleration")]
    public float decceleration;
    public float deccelerationTime;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        decceleration = maxSpeed / deccelerationTime;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        /*        direction = Vector3.zero;

            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
            {
                direction += Vector3.up;
            }
            if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
            {
                direction += Vector3.down;
            }
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            {
                direction += Vector3.left;
            }
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                direction += Vector3.right;
            }
    */

        if (!Keyboard.current.anyKey.isPressed)
        {
            velocity -= velocity.normalized * decceleration * Time.deltaTime;
        }
        else
        {
            velocity += direction * acceleration * Time.deltaTime;
        }

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);

        transform.position += velocity * Time.deltaTime;
    }
    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 lookDirection = (mousePosition - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }
}

