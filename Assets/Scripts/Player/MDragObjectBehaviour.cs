using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDragObjectBehaviour : MonoBehaviour
{
    public Camera camera = null;
    public float speed = 0.1f;

    private GameObject _object = null;
    private bool _objectGrabbed = false;

    private Vector3 m_offset;
    private float m_zCoord;

    void Update()
    {
        //If object is not null, update position with offset
        if (_object)
        {
            _object.transform.position = GetMouseWorldPos() + m_offset;
            m_zCoord = camera.WorldToScreenPoint(_object.transform.position).z;
            m_offset = _object.transform.position - GetMouseWorldPos();
        }

        if (Input.GetAxis("MouseScrollWheel") > 0)
            UpdateObjectDistance(true);

        if (Input.GetAxis("MouseScrollWheel") < 0)
            UpdateObjectDistance(false);

        if (Input.GetMouseButtonDown(0))
        {
            //Toggles object grab
            if (!_objectGrabbed)
            {
                DragObject();
                return;
            }
            _object = null;
            _objectGrabbed = false;
        }
    }
    private void DragObject()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        //If the object doesn't have an "Environment" or "Hazard" tag and there isn't an object already grabbed
        if (!hit.collider.gameObject.CompareTag("Environment") && !hit.collider.gameObject.CompareTag("Hazard") && !_objectGrabbed)
        {
            //set the object hit to be objectGrabbed
            _object = hit.collider.gameObject;

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

    private void UpdateObjectDistance(bool IsPositive)
    {
        //Create an offset with the object position and the camera position
        Vector3 offset = _object.transform.position - transform.position;

        if (IsPositive)
        {
            m_offset += (offset * speed);
            _object.transform.position += m_offset * Time.deltaTime;
            return;
        }
        if ((_object.transform.position - transform.transform.position).magnitude >= 30)
        {
            m_offset -= (offset * speed);
            _object.transform.position -= m_offset * Time.deltaTime;
        }
    }
}