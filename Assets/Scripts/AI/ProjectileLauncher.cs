using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform target = null;
    public Rigidbody projectile = null;
    public Transform spawnLocation = null;

    public float projectileDelay = 1.0f;
    public float projectileTime = 2.0f;

    private void Update()
    {
        projectileDelay -= Time.deltaTime;
        float distance = (target.transform.position - transform.position).magnitude;

        //If the distance is less than 10 and projectile delay is less than 0
        if (distance <= 10 && projectileDelay <= 0)
        {
            //Launch projectile and sets projectile delay to 1 second
            LaunchProjectile();
            projectileDelay = 1.0f;
        }
    }

    public void LaunchProjectile()
    {
        Vector3 distance = (target.position - transform.position);
        Vector3 acceleration = Physics.gravity;

        Vector3 initialVelocity = FindInitialVelocity(distance, acceleration, projectileTime);
        Vector3 finalVelocity = FindFinalVelocity(initialVelocity, acceleration, projectileTime);

        Rigidbody projectileInstance = Instantiate(projectile, spawnLocation.position, transform.rotation);
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
