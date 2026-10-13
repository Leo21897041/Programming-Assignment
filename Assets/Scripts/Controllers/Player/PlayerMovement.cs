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
        LookAtMouse();
        StayWithinScreenBounds();
    }

    private void Movement()
    {
        direction = Vector3.zero;

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
    private void StayWithinScreenBounds()
    {
        float screenLeft = 0;
        float screenRight = Screen.width;
        float screenBottom = 0;
        float screenTop = Screen.height;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPosition.x < screenLeft)
        {
            screenPosition.x = screenLeft;

            velocity.x = 0;
        }
        else if (screenPosition.x > screenRight)
        {
            screenPosition.x = screenRight;
            
            velocity.x = 0;
        }

        if(screenPosition.y < screenBottom)
        {
            screenPosition.y = screenBottom;
            
            velocity.y = 0;
        }
        else if (screenPosition.y > screenTop)
        {
            screenPosition.y = screenTop;
            
            velocity.y = 0;
        }

        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
    }
}

