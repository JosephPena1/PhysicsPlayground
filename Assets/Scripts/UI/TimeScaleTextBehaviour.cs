using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _displayText = null;

    // Start is called before the first frame update
    void Start()
    {
        _displayText.text = "" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        _displayText.text = "TimeScale: " + Time.timeScale;
    }
}
