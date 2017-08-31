using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D other) // collision callback mapping
    {
        switch (other.gameObject.tag)
        {
            case "StageEnd": Game.complete(); break; // if collisioned object gameObject is tagged "StageEnd", we complete (win) game
        }
    }

    public void OnTriggerEnter2D(Collider2D other) // trigger callback mapping
    {        
        switch (other.tag)
        {
            case "Enemy": // if collisioned object is tagged "Enemy", we lower health points state and destroy the collisioned gameObject
                Game.instance.hpDown();
                Destroy(other.gameObject);
                break;
            case "Collectable": // if collisioned object is tagged "Collectable", we raise items score state and destroy the collisioned gameObject
                Game.instance.itemsUp();
                Destroy(other.gameObject);
                break;
        }
    }
}
