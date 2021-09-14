using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubeBehaviour : MonoBehaviour
{
    private bool _cubeCreated = false;

    [SerializeField] private HealthBehaviour _parentHealth;

    private void Awake()
    {
        _parentHealth = GetComponentInParent<HealthBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        //If parents health is less than 0
        if (_parentHealth.Health <= 0 && !_cubeCreated)
        {
            //create a cube with the same position and scale as the original
            GameObject cube = Instantiate(gameObject, transform.position, transform.rotation);
            Destroy(cube.GetComponent<EnemyCubeBehaviour>());
            BoxCollider collider = cube.gameObject.GetComponent<BoxCollider>();
            cube.tag = "Trash";
            collider.enabled = true;
            _cubeCreated = true;
            Destroy(gameObject);
        }
    }
}
