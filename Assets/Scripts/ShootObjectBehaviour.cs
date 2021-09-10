using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObjectBehaviour : MonoBehaviour
{
    public Camera camera;
    public Transform spawnLocation;
    public Rigidbody rigidBody;

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

        Rigidbody projectileObject = Instantiate(rigidBody, spawnLocation.position, camera.transform.rotation);
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
