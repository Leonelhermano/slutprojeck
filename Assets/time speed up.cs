using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class timespeedup : MonoBehaviour
{
    private float fixeddeltatime;
    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixeddeltatime = Time.fixedDeltaTime;
    }
    void Start()
    {

       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.1f;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 real-time seconds per frame
            Time.fixedDeltaTime = this.fixeddeltatime * Time.timeScale;
        }
    }
}
