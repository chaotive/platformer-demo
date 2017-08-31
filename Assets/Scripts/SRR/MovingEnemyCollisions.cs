using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyCollisions : MonoBehaviour {
    /// <summary>  
    ///  This component allows to detect specific moving enemies collisions.         
    /// </summary> 

    public void OnTriggerEnter2D(Collider2D other) // trigger callback mapping
    {
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); break; // if collisioned object is tagged "Boundary" (of the stage), we destroy ourselves
        }
    }
}
