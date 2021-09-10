using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBehaviour : MonoBehaviour
{
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float direction = 1.0f;
    public bool swingAlongX = false;
    private Quaternion startPos;
    
    void Start()
    {
        startPos = transform.rotation;
    }

    void Update()
    {
        Quaternion a = startPos;
        if (!swingAlongX)
            a.z += direction * (delta * Mathf.Sin(Time.time * speed));
        else
            a.x += direction * (delta * Mathf.Sin(Time.time * speed));

        transform.rotation = a;
    }
}
