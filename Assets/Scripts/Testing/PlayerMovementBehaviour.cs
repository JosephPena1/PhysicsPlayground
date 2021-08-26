using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed * Time.deltaTime;

        //float directionMag = (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed).magnitude;

        if (Input.GetButtonDown("Jump"))
            _rigidbody.AddForce(new Vector3(0, 5, 0),ForceMode.Impulse);

        //transform.position = transform.position + Camera.main.transform.forward * directionMag * Time.deltaTime;
    }
}
