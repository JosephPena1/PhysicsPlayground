using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private float _health = 1.0f;

    public float Health
    {
        get { return _health; }
    }

    public void takeDamage()
    {
        _health -= 1;
    }
}
