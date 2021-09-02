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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _frontLeftMotor.targetVelocity += 100;
            _frontLeftMotor.force += 100;
            _frontRightMotor.targetVelocity += -100;
            _frontRightMotor.force += 100;
            _rearLeftMotor.targetVelocity += 100;
            _rearLeftMotor.force += 100;
            _rearRightMotor.targetVelocity += -100;
            _rearRightMotor.force += 100;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _frontLeftMotor.targetVelocity += -100;
            _frontLeftMotor.force += 100;
            _frontRightMotor.targetVelocity += 100;
            _frontRightMotor.force += 100;
            _rearLeftMotor.targetVelocity += -100;
            _rearLeftMotor.force += 100;
            _rearRightMotor.targetVelocity += 100;
            _rearRightMotor.force += 100;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;
        }
    }
}
