using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneBehaviour : MonoBehaviour
{
    public bool trashPlaneMode;

    private void OnTriggerEnter(Collider other)
    {
        if (!trashPlaneMode)
        {
            if (other.gameObject.CompareTag("Player"))
                return;
            else
                Destroy(other.gameObject);
        }

        else
            if (other.gameObject.CompareTag("Trash"))
                Destroy(other.gameObject);
    }
}
