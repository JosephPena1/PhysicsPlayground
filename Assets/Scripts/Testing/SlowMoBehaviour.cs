using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _slowAmount;
    private bool _timeSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _timeSlowed)
        {
            Time.timeScale = 1;
            _timeSlowed = false;
        }
            
        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.timeScale != 0)
        {
            Time.timeScale -= _slowAmount;
            _timeSlowed = true;
        }
    }
}
