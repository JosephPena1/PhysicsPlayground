using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementBehaviour : MonoBehaviour
{
    public HingeJoint frontLeft = null;
    public HingeJoint frontRight = null;
    public HingeJoint rearLeft = null;
    public HingeJoint rearRight = null;
    private JointMotor _frontLeftMotor;
    private JointMotor _frontRightMotor;
    private JointMotor _rearLeftMotor;
    private JointMotor _rearRightMotor;

    private void Start()
    {
        _frontLeftMotor = frontLeft.motor;
        _frontRightMotor = frontRight.motor;
        _rearLeftMotor = rearLeft.motor;
        _rearRightMotor = rearRight.motor;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _frontLeftMotor.targetVelocity = 600;
            _frontLeftMotor.force = 600;
            _frontRightMotor.targetVelocity = -600;
            _frontRightMotor.force = 600;
            _rearLeftMotor.targetVelocity = 600;
            _rearLeftMotor.force = 600;
            _rearRightMotor.targetVelocity = -600;
            _rearRightMotor.force = 600;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _frontLeftMotor.targetVelocity = -600;
            _frontLeftMotor.force = 600;
            _frontRightMotor.targetVelocity = 600;
            _frontRightMotor.force = 600;
            _rearLeftMotor.targetVelocity = -600;
            _rearLeftMotor.force = 600;
            _rearRightMotor.targetVelocity = 600;
            _rearRightMotor.force = 600;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;
        }
    }
}
