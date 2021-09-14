using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    public Camera camera = null;
    public float _maxDistance = 20.0f;

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

        float rayDistance = (hit.point - transform.position).magnitude;

        //If the object does'nt have an environment tag
        if (!hit.collider.gameObject.CompareTag("Environment") && rayDistance < _maxDistance && rayDistance > 5)
        {
            //set the object hit to be objectGrabbed
            _objectGrabbed = hit.collider.gameObject;

            float distance = (_objectGrabbed.transform.position - transform.position).magnitude;

            if (distance >= 10)
            {
                _objectGrabbed.transform.position = hit.point;
                _minDistance = _objectGrabbed.transform.position;
            }

            else
                _objectGrabbed.transform.position = _minDistance;
        }
    }
}
