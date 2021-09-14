using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollectorBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        //increases y position until it reaches 0.1
        if (transform.position.y <= 0.1)
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        else
            transform.position = _startPos;
    }
}
