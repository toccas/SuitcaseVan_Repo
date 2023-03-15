using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500;

    public WheelJoint2D backWheel;

    private float movement = 0f;

    public bool acelleratoreIsPressed;
    public bool frenoIsPressed;

    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;

        if (acelleratoreIsPressed == true)
            movement = -1 * speed;
        else
            movement = 0;

        if (frenoIsPressed == true)
            movement = 1500f;
    }

    void FixedUpdate()
    {
        if (movement == 0)
        {
            backWheel.useMotor = false;
        }else
        {
            backWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
        }
    }

    public void Pressed()
    {
        acelleratoreIsPressed = true;
    }

    public void NotPressed()
    {
        acelleratoreIsPressed = false;
    }

    public void frenoPressed()
    {
        frenoIsPressed = true;
    }

    public void frenoIsNotPressed()
    {
        frenoIsPressed = false;
    }
}
