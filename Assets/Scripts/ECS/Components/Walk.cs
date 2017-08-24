using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{    
    private float accelerationForce = 800;    
    private Vector2 maxVelocity;
    
    private Rigidbody2D body;

    void Start()
    {        
        maxVelocity = new Vector2(Game.config.playerSpeed, 8.5f);
        body = GetComponent<Rigidbody2D>();
        
        // Moving Enemy
        //maxVelocity = new Vector2(Game.config.movingEnemiesSpeed * -1, 8.5f);
    }
    
    void FixedUpdate()
    {
        if (Game.isPlaying())
        {
            if (body.velocity.x < maxVelocity.x) body.AddForce(Vector2.right * accelerationForce * Time.deltaTime);

            var goingUp = false; //TODO: Reference jump var somehow
            if (goingUp) body.AddForce(Vector2.right * accelerationForce * Time.deltaTime);                
            //print(body.velocity + " goingUp:" + goingUp + " onAir:" + onAir + " jumped:" + jumped);
        }
        else body.velocity = new Vector2(0, body.velocity.y); //TODO: Synchronize with jump velocity somehow

        /*
        // Moving Enemy
        if (Game.isPlaying())
        {
            if (body.velocity.x > maxVelocity.x) body.AddForce(Vector2.left * accelerationForce * Time.deltaTime);
            //print("Moving enemy: " + body.velocity);
        }
        else body.velocity = new Vector2(0, body.velocity.y);
        */
    }

}
