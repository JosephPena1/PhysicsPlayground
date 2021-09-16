using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    public Camera camera = null;
    [Tooltip("Max distance you can pick up objects")]
    public float maxPickupDistance = 20.0f;
    [Tooltip("How close an onject can get to the camera")]
    public float maxRadius = 5.0f;

    private GameObject _objectGrabbed = null;
    private Vector3 _minDistance;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
            DragObject();
    }

    private void DragObject()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        //Gets the length between the ray point and current position
        float rayDistance = (hit.point - transform.position).magnitude;

        //If the object doesn't have an "Environment" or "Hazard" tag
        if (!hit.collider.gameObject.CompareTag("Environment") && !hit.collider.gameObject.CompareTag("Hazard"))
            //set the object hit to be objectGrabbed
            _objectGrabbed = hit.collider.gameObject;

        Vector3 centerPos = transform.position;
        Vector3 objectPosition = _objectGrabbed.transform.position;

        //Gets the distance from "Object grabbed" to "Camera"
        float distance = Vector3.Distance(objectPosition, centerPos);

        //If (rayDistance is less than the pickup range) and (distance is less than max radius)
        if ((rayDistance < maxPickupDistance) && (distance > maxRadius))
        {
            Vector3 fromOriginToObject = objectPosition - centerPos;

            fromOriginToObject *= maxRadius / distance;

            _objectGrabbed.transform.position = centerPos + fromOriginToObject;
        }

        //Maybe make an else to tell it to stay unless no input.
    }
}
