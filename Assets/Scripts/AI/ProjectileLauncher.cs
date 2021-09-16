using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform target = null;
    public Rigidbody projectile = null;

    [Tooltip("Time Between firing")]
    public float projectileDelay = 2.0f;
    public float projectileTime = 2.0f;
    [Tooltip("How far it can shoot")]
    public float maxRange = 10.0f;

    private float _projectileDelay = 0.0f;
    private float _burstShotDelay = 0.0f;
    private int _shotCount = 0;

    private void Awake()
    {
        _projectileDelay = projectileDelay;
    }

    private void Update()
    {
        projectileDelay -= Time.deltaTime;
        float distance = (target.transform.position - transform.position).magnitude;

        //If the distance is less than 10 and projectile delay is less than 0
        if (distance <= maxRange && projectileDelay <= 0)
        {
            _burstShotDelay -= Time.deltaTime;
            if (_burstShotDelay <= 0 && _shotCount < 3)
            {
                LaunchProjectile();
                _shotCount += 1;
                _burstShotDelay += 0.3f;
            }
            if (_shotCount >= 3)
            {
                projectileDelay = _projectileDelay;
                _shotCount = 0;
                _burstShotDelay = 0.0f;
            }
        }
    }

    public void LaunchProjectile()
    {
        Vector3 distance = (target.position - transform.position);
        Vector3 acceleration = Physics.gravity;

        Vector3 initialVelocity = distance / projectileTime - 0.5f * acceleration * projectileTime;
        Vector3 finalVelocity = initialVelocity + acceleration * projectileTime;

        Vector3 SpawnLocation = new Vector3(transform.position.x, 2.75f, transform.position.z);

        Rigidbody projectileInstance = Instantiate(projectile, SpawnLocation, transform.rotation);
        projectileInstance.AddForce(initialVelocity, ForceMode.VelocityChange);
    }
}
