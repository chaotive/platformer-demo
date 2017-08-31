using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    /// <summary>  
    ///  This component allows for current object to move constantly on a direction, up to a limit, and then coming back from it.    
    /// </summary> 

    [Tooltip("How much to move on every update.")]
    public float amount = 0.1f;
    [Tooltip("How much to move in total before changing direction.")]
    public float max = 3;

    private bool movingRight = true; // indicates if moving to the right or left
    private bool movingUp = true; // indicates if moving up or down

    void Update () {
        var x = transform.position.x; // save current x and y position
        var y = transform.position.y;

        if (x > max) movingRight = false; // check if maximum right or left movement is reached
        else if (x < -max) movingRight = true;

        if (y > max) movingUp = false; // check if maximum up or down movement is reached
        else if (y < -max) movingUp = true;

        if (movingRight) x += amount * Time.deltaTime; // how much to move horizontally based on amount and adjusted to updating capabilities
        else x -= amount * Time.deltaTime;

        if (movingUp) y += amount * Time.deltaTime; // how much to move vertically based on amount and adjusted to updating capabilities
        else y -= amount * Time.deltaTime;

        transform.position = new Vector2(x, y); // actually move based on calculated X and Y
    }
}
 