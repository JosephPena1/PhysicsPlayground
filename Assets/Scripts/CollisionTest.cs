using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("Hit");
        /*else if (collision.gameObject.CompareTag("Hazard"))
            collision.rigidbody.AddForce((_rigidBody.velocity) * 2, ForceMode.Impulse);*/
    }
}
