using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform target = null;
    public Rigidbody projectile = null;

    public float projectileTime = 2.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            LaunchProjectile();
    }

    public void LaunchProjectile()
    {
        Vector3 displacement = (target.position - transform.position);
        Vector3 acceleration = Physics.gravity;

        Vector3 initialVelocity = FindInitialVelocity(displacement, acceleration, projectileTime);
        Vector3 finalVelocity = FindFinalVelocity(initialVelocity, acceleration, projectileTime);

        Rigidbody projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //Δx = v0*t + ½*a*t²
        Vector3 displacement = initialVelocity * time + (1/2) * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        //Δx = v0*t + ½*a*t²
        //Δx - ½*a*t² = v0*t
        //Δx/t - ½*a*t = v0
        //v0 = Δx/t - ½*a*t
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
