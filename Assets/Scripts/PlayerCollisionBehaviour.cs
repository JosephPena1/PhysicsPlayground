using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;
    private bool _canMove = true;

    private void Update()
    {
        EnableAnimator();
    }

    private void EnableAnimator()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && !_canMove)
        {
            _canMove = true;
            _characterController.enabled = true;
            _animator.enabled = true;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidBody;
        rigidBody = gameObject.GetComponent<Rigidbody>();

        if (hit.gameObject.CompareTag("Hazard"))
        {

            _animator.enabled = false;
            _characterController.enabled = false;
            _canMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            _animator.enabled = false;
            _characterController.enabled = false;
            _canMove = false;
        }
    }
}
