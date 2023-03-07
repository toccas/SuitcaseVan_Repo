using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController3D : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;


    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLefttCollider;
    [SerializeField] private WheelCollider backRighttCollider;

    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLefttTransform;
    [SerializeField] private Transform backRighttTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleStreering();
        UpdateWheels();
    }

    private void GetInput()
    {
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontRightCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApllyBreaking();
        }

    }

    private void ApllyBreaking()
    {
        frontLeftCollider.brakeTorque = currentBreakForce;
        frontRightCollider.brakeTorque = currentBreakForce;
        backLefttCollider.brakeTorque = currentBreakForce;
        backRighttCollider.brakeTorque = currentBreakForce;
    }

    private void HandleStreering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftCollider.steerAngle = steerAngle;
        frontRightCollider.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        updateSingleWheel(frontLeftCollider, frontLeftTransform);
        updateSingleWheel(frontRightCollider, frontRightTransform);
        updateSingleWheel(backLefttCollider, backLefttTransform);
        updateSingleWheel(backRighttCollider, backRighttTransform);
    }

    private void updateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
