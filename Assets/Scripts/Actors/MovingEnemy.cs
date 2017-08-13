using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy {    
    private Vector2 maxVelocity;
    private float accelerationForce = 800;
    
    new void Start()
    {
        base.Start();
        maxVelocity = new Vector2(Config.game.enemySpeed * -1, 8.5f);        
    }

    void FixedUpdate()
    {
        if (body.velocity.x > maxVelocity.x) body.AddForce(Vector2.left * accelerationForce * Time.deltaTime);        
        //print("Moving enemy: " + body.velocity);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); break;            
        }
    }
}
