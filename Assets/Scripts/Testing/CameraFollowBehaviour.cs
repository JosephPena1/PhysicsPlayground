using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    private Vector3 _offset;

    [SerializeReference]
    private Transform _player = null;

    public float camPosX;
    public float camPosY;
    public float camPosZ;

    public float camRotationX;
    public float camRotationY;
    public float camRotationZ;

    public float SensitivityX;
    public float SensitivityY;
    public float turnSpeed = 3f;

    private void Start()
    {
        _offset = new Vector3(_player.position.x + camPosX, _player.position.y + camPosY, _player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);

    }

    private void Update()
    {
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * _offset;
        transform.position = _player.position + _offset;
        transform.LookAt(_player.position);
    }
}
