using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectBehvaiour : MonoBehaviour
{
    public float despawnTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
            Destroy(gameObject);
    }
}
