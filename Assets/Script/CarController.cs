using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500;

    public WheelJoint2D backWheel;

    private float movement = 0f;

    public bool isPressed;

    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;
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
        isPressed = true;
    }

    public void NotPressed()
    {
        isPressed = false;
    }
}
