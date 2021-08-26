using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WakeupMaterialBehaviour : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rigidBody = null;
    private MeshRenderer _renderer = null;

    private bool _materialIsAwake = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        //Set material to asleep if rigidbody is asleep
        if (_materialIsAwake && _rigidBody.IsSleeping() && asleepMaterial)
        {
            _renderer.material = asleepMaterial;
            _materialIsAwake = false;
        }

        //Set material to awake if the rigidbody is awake
        else if (!_materialIsAwake && !_rigidBody.IsSleeping() && awakeMaterial)
        {
            _renderer.material = awakeMaterial;
            _materialIsAwake = true;
        }

    }
}
