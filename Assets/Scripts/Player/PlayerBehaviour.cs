using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Tooltip("[0.0 - 1.0]")]
    public float drag = 1.0f;
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1.0f;
    public float gravityModifier = 1.0f;
    public bool faceWithCamera = true;

    public Camera playerCamera = null;

    private CharacterController _controller = null;
    [SerializeField] private Animator _animator = null;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired = false;
    private bool _isGrounded = false;

    //add acceleration & decceleration

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_animator.enabled)
        {
            //Get movement input
            float inputForward = Input.GetAxis("Vertical");
            float inputRight = Input.GetAxis("Horizontal");

            Vector3 input = new Vector3(inputRight, 0, inputForward);

            //Get camera forward
            Vector3 cameraForward = playerCamera.transform.forward;
            cameraForward.y = 0.0f;
            cameraForward.Normalize();

            //Get camera right
            Vector3 cameraRight = playerCamera.transform.right;

            //Find desired velocity
            _desiredVelocity = (cameraForward * inputForward) + (cameraRight * inputRight);

            //Get jump input
            _isJumpDesired = Input.GetButtonDown("Jump");

            //Set movement magnitude
            _desiredVelocity.Normalize();
            _desiredVelocity *= speed;

            //Check for ground
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
            //_isGrounded = _controller.isGrounded;

            //Change player facing
            if (faceWithCamera)
            {
                transform.forward = cameraForward;
                _animator.SetFloat("Speed", inputForward);
                _animator.SetFloat("Direction", inputRight);
            }
            else
            {
                if (_desiredVelocity != Vector3.zero)
                    transform.forward = _desiredVelocity.normalized;
                _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
            }

            _animator.SetBool("Jump", !_isGrounded);
            _animator.SetFloat("VerticalSpeed", _desiredVelocity.y / jumpStrength);

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
                _airVelocity.y = -0.1f;

            //Add air velocity
            _desiredVelocity += _airVelocity;

            //calculate acceleration [Find a way to decelerate]
            Vector3 velocity = _desiredVelocity;

            velocity += input * speed * Time.deltaTime;

            velocity *= drag;

            velocity.y -= gravityModifier * Time.deltaTime;

            //Debug.Log(velocity);

            //Move
            _controller.Move(velocity * Time.deltaTime);
        }
    }
}
