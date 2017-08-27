using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyCollisions : MonoBehaviour {
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); break;
        }
    }
}
