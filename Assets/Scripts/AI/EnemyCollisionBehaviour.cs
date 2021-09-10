using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
    private HealthBehaviour _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<HealthBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hammer"))
        {
            _enemyHealth.takeDamage();
            //Destroy(collision.collider.gameObject);
        }
    }
}
