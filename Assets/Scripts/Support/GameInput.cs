using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{    
    public static bool inputPressed = false;
    
    void Update()
    {
        /* Input */
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
                print("Touched! :)");
                break;
            }
        }
        return touched;
    }
    
}
