using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxBehaviour : MonoBehaviour
{
    public GameObject spawner1 = null;
    public GameObject spawner2 = null;

    [Tooltip("Keep false to enable spawners, true to disable")]
    public bool flipActiveState = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!flipActiveState)
            {
                spawner1.SetActive(true);
                spawner2.SetActive(true);
            }
            else
            {
                spawner1.SetActive(false);
                spawner2.SetActive(false);
            }
        }
    }
}
