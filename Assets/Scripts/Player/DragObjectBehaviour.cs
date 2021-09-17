using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectBehaviour : MonoBehaviour
{
    public Camera camera = null;
    public float speed = 0.1f;

    private GameObject _object = null;
    private bool _objectGrabbed = false;

    private Vector3 m_offset;
    private float m_zCoord;

    // Update is called once per frame
    void Update()
    {
        if (_objectGrabbed && _object != null)
            _object.transform.position = GetMouseWorldPos() + m_offset;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 offset = _object.transform.position - transform.position;
            m_offset += offset * speed;
            _object.transform.position += m_offset * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 offset = _object.transform.position - transform.position;
            m_offset -= offset * speed;
            _object.transform.position -= m_offset * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (!_objectGrabbed)
                DragObject();
            else
            {
                _object = null;
                _objectGrabbed = false;
            }
        }
    }

    private void DragObject()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        //Gets the length between the ray point and current position
        float rayDistance = (hit.point - transform.position).magnitude;

        //If the object doesn't have an "Environment" or "Hazard" tag and there isn't an object already grabbed
        if (!hit.collider.gameObject.CompareTag("Environment") && !hit.collider.gameObject.CompareTag("Hazard") && !_objectGrabbed)
        {
            //set the object hit to be objectGrabbed
            _object = hit.collider.gameObject;

            //set object grabbed true
            _objectGrabbed = true;

            m_zCoord = camera.WorldToScreenPoint(_object.transform.position).z;

            //Store offset = gameobject world pos - mouse world pos 
            m_offset = _object.transform.position - GetMouseWorldPos();
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinates of game object on screen
        mousePoint.z = m_zCoord;

        return camera.ScreenToWorldPoint(mousePoint);
    }
}
