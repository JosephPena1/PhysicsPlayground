using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _slowAmount = 0.25f;
    private bool _timeSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SlowTime") && _timeSlowed)
        {
            Time.timeScale = 1;
            _timeSlowed = false;
        }
            
        if (Input.GetButtonDown("SlowTime") && Time.timeScale != 0)
        {
            Time.timeScale -= _slowAmount;
            _timeSlowed = true;
        }
    }
}
