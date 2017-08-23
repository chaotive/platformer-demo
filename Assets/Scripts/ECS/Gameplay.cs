using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [HideInInspector]
    public int items = 0;
    [HideInInspector]
    public int hp = 1;
    
    void Start()
    {        
        hp = Game.config.playerHp;                
    }
    
    public void itemsUp()
    {
        items++;
    }

    public void hpDown()
    {
        hp--;
        if (hp <= 0) Game.over();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {            
            case "StageEnd": Game.complete(); break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        /* Player */
        switch (other.tag)
        {
            case "Enemy":
                hpDown();
                Destroy(other.gameObject);
                break;
            case "Collectable":
                itemsUp();
                Destroy(other.gameObject);
                break;
        }

        /* MovingEnemy */
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); break;
        }
    }
}

//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts
//TODO: Abstracts