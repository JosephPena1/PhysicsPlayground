using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeekBehaviour : MonoBehaviour
{
    //Once the enemy dies, destroy fixed hinges, disable enemy collision
    public GameObject target = null;
    public float speed = 1.0f;

    private HealthBehaviour _enemyHealth;
    private FixedJoint _fixedJoint;
    private float _timer = 0.1f; 

    private void Awake()
    {
        _enemyHealth = GetComponent<HealthBehaviour>();
        _fixedJoint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;

        if (_enemyHealth.Health <= 0)
        {
            Destroy(_fixedJoint);
            _timer -= Time.deltaTime;
        }

        if (_enemyHealth.Health <= 0 && _timer <= 0)
            Destroy(gameObject);
    }
}
