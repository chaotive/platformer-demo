using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{    
    public static bool inputPressed = false;
    
    void Update()
    {
        /* General Input */
        if (Game.isPlaying())
        {
            if (Input.GetKey("space") || checkTouch()) inputPressed = true;
            else inputPressed = false;
        }
    }

    /* Mobile Input */
    bool checkTouch() {
        var touched = false;
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                touched = true;                
                break;
            }
        }
        return touched;
    }
    
}
