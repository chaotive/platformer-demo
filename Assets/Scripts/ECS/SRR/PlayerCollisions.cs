using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "StageEnd": Game.complete(); break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {        
        switch (other.tag)
        {
            case "Enemy":
                GameController.instance.hpDown();
                Destroy(other.gameObject);
                break;
            case "Collectable":
                GameController.instance.itemsUp();
                Destroy(other.gameObject);
                break;
        }
    }
}
