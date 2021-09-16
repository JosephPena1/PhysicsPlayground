using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementBehaviour : MonoBehaviour
{
    public float addedForce = 1.0f;

    public HingeJoint frontLeft = null;
    public HingeJoint frontRight = null;
    public HingeJoint rearLeft = null;
    public HingeJoint rearRight = null;
    private JointMotor _frontLeftMotor;
    private JointMotor _frontRightMotor;
    private JointMotor _rearLeftMotor;
    private JointMotor _rearRightMotor;

    private float _maxForce = 0.0f;
    private float _maxVelocity = 0.0f;

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
        if (_maxForce > 300)
            _maxForce = 300;

        if (Input.GetKey(KeyCode.DownArrow) && _maxForce <= 300)
        {
            //Add "addForce" the target velocity and force by
            _frontLeftMotor.targetVelocity += addedForce;
            _frontLeftMotor.force += addedForce;
            _frontRightMotor.targetVelocity += -addedForce;
            _frontRightMotor.force += addedForce;
            _rearLeftMotor.targetVelocity += addedForce;
            _rearLeftMotor.force += addedForce;
            _rearRightMotor.targetVelocity += -addedForce;
            _rearRightMotor.force += addedForce;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;

            _maxVelocity = _frontLeftMotor.targetVelocity;
            _maxForce += addedForce;
        }

        if (Input.GetKey(KeyCode.UpArrow) && _maxForce <= 300)
        {
            _frontLeftMotor.targetVelocity += -addedForce;
            _frontLeftMotor.force += addedForce;
            _frontRightMotor.targetVelocity += addedForce;
            _frontRightMotor.force += addedForce;
            _rearLeftMotor.targetVelocity += -addedForce;
            _rearLeftMotor.force += addedForce;
            _rearRightMotor.targetVelocity += addedForce;
            _rearRightMotor.force += addedForce;

            frontLeft.motor = _frontLeftMotor;
            frontRight.motor = _frontRightMotor;
            rearLeft.motor = _rearLeftMotor;
            rearRight.motor = _rearRightMotor;

            _maxForce += addedForce;
        }
    }
}
