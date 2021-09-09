﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObjectBehaviour : MonoBehaviour
{
    public Camera camera;
    public Rigidbody rigidBody;
    public float force = 1.0f;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LaunchProjectile();
    }

    public void LaunchProjectile()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        Vector3 displacement = hit.point - camera.transform.position;
        Vector3 acceleration = Physics.gravity;

        Vector3 initialVelocity = FindInitialVelocity(displacement, acceleration);

        Vector3 multForce = new Vector3(initialVelocity.x * force, 0, initialVelocity.z * force);

        Rigidbody projectileObject = Instantiate(rigidBody, camera.transform.position, camera.transform.rotation);
        projectileObject.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration)
    {
        //Δx = v0*t + ½*a*t²
        //Δx - ½*a*t² = v0*t
        //Δx/t - ½*a*t = v0
        //v0 = Δx/t - ½*a*t
        Vector3 initialVelocity = displacement - 0.5f * acceleration;

        return initialVelocity;
    }
}
