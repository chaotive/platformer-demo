using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    /// <summary>  
    ///  This component allows for generalization of Input control, althought is has not render too important for this particular example and was not further developed.         
    /// </summary> 

    public static bool inputPressed = false;
    
    void Update()
    {
        /* General Input */
        if (Game.isPlaying())
        {
            if (Input.GetKey("space") || checkTouch()) inputPressed = true; //we check space key pressed or input touched, and provide that as a static state to be used by clients
            else inputPressed = false;
        }
    }

    /* Mobile Input */
    bool checkTouch() {
        var touched = false;
        for (int i = 0; i < Input.touchCount; ++i) // for each finger detected on touch surface
        {
            // if any of the touch states is true, is good enough for us to say that touch is being pressed
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                touched = true;                
                break;
            }
        }
        return touched;
    }
    
}
