using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    public Camera camera = null;
    [Tooltip("Max distance you can pick up objects")]
    public float maxPickupDistance = 20.0f;
    [Tooltip("How close an onject can get to the camera")]
    public float maxCameraDistance = 0.25f;

    private GameObject _objectGrabbed = null;
    private bool _isGrabbed = false;
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

        //multiplies the position by the maxCameraDistance and adds it to maxDistance
        Vector3 keepDistance = new Vector3(transform.position.x * maxCameraDistance, transform.position.y, transform.position.z * maxCameraDistance);
        Vector3 maxDistance = transform.position + keepDistance;

        //If the object doesn't have an "Environment" tag
        if (!hit.collider.gameObject.CompareTag("Environment") && !hit.collider.gameObject.CompareTag("Hazard"))
            //set the object hit to be objectGrabbed
            _objectGrabbed = hit.collider.gameObject;

        //If rayDistance is less than the pickup range and greater than 5
        if (rayDistance < maxPickupDistance && rayDistance > 5)
        {
            //The length between the object's position and current position
            float distance = (_objectGrabbed.transform.position - maxDistance).magnitude;

            //If distance is greater than or equal to 10
            if (distance > 0)
            {
                //set objects position to the ray point
                _objectGrabbed.transform.position = hit.point;
                //set minDistance to objects position
                _minDistance = _objectGrabbed.transform.position;
            }

            //Else set objects position to minDistance
            else
                _objectGrabbed.transform.position = maxDistance;



            //While isGrabbed is true do something?
        }

        else
            _objectGrabbed.transform.position = keepDistance;
    }
}
