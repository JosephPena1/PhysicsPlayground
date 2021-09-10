using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 10.0f;
    public float sensitivity = 5.0f;
    public bool invertY = false;
    public float returnSpeed;

    private float _currentDistance;

    private void Start()
    {
        _currentDistance = maxDistance;
    }

    private void Update()
    {
        //Rotate the camera
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //Look up & down by rotating around the X-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity, 0.0f, 90.0f);
            //Look left & right by rotating around the Y-axis
            angles.y += rotation.y * sensitivity;
            //Set the angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        RaycastHit hitInfo;
        if (Physics.Raycast(target.position, -transform.forward, out hitInfo, maxDistance))
            //Zoom the camera in if there'ss a collision
            _currentDistance = hitInfo.distance;

        else
            //Ease the camera out to the max distance if there's no camera
            _currentDistance = Mathf.MoveTowards(_currentDistance, maxDistance, returnSpeed * Time.deltaTime);

        transform.position = target.position + (-transform.forward * _currentDistance);
    }
}
