using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForceBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField]
    private float _force;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _rigidBody.AddForce(new Vector3(0,0, _force), ForceMode.Impulse);
    }
}
