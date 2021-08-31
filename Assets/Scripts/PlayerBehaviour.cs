using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1.0f;
    public float gravityModifier = 1.0f;

    public Camera playerCamera;

    private CharacterController _controller;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired = false;
    private bool _isGrounded = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        //Get movement input
        float inputForward = Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Apply air control


        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Apply jump strength
        if (_isJumpDesired && _controller.isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //Stop on ground
        if (_isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -0.1f;
        }

        //Add air velocity
        _desiredVelocity += _airVelocity;
        
        //Move
        _controller.Move(_desiredVelocity* Time.deltaTime);
    }
}
