using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    //Spawn in the enemy and give them your target via 
    public GameObject target = null;
    public GameObject spawnedObject = null;
    public float timeBetweenSpawn = 3.0f;

    private float _spawnDelay = 3.0f;

    // Update is called once per frame
    void Update()
    {
        _spawnDelay -= Time.deltaTime;
        if (_spawnDelay <= 0)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            GameObject enemy = Instantiate(spawnedObject, spawnPos, transform.rotation);
            EnemySeekBehaviour enemyTarget = enemy.GetComponent<EnemySeekBehaviour>();
            ProjectileLauncher enemyProjTarget = enemy.GetComponent<ProjectileLauncher>();
            enemyTarget.target = target;
            enemyProjTarget.target = target.transform;
            _spawnDelay = timeBetweenSpawn;
        }
    }
}
