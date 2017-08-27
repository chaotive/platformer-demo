using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "StageEnd": SrrController.complete(); break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {        
        switch (other.tag)
        {
            case "Enemy":                
                SrrController.instance.hpDown();
                Destroy(other.gameObject);
                break;
            case "Collectable":
                SrrController.instance.itemsUp();
                Destroy(other.gameObject);
                break;
        }
    }
}
