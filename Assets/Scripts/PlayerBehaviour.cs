using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float gravityModifier = 1.0f;

    private CharacterController _controller;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired;
    private Ray _ray;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        RaycastHit hit;
        _ray.origin = transform.position;
        _ray.direction = new Vector3(90, 0, 0);

        if (Physics.Raycast(_ray, out hit))
        {

        }

        //Get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal");
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");

        //Get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;
        
        //Apply jump strength
        if (_isJumpDesired)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }
        
        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        _desiredVelocity += _airVelocity;
        
        //Move
        _controller.Move(_desiredVelocity* Time.deltaTime);
    }
}
