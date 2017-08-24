using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{        
    private float jumpForce = 4000;

    private Vector2 maxVelocity;
    
    private bool jumped = false;
    private bool onAir = false;

    private Rigidbody2D body;

    void Start()
    {        
        maxVelocity = new Vector2(Game.config.playerSpeed, 8.5f);
        body = GetComponent<Rigidbody2D>();
    }
        
    void FixedUpdate()
    {
        if (Game.isPlaying())
        {            
            bool goingUp = false;
            if (body.velocity.y < maxVelocity.y && !jumped) goingUp = true;
            else if (onAir) jumped = true;

            if (goingUp)
            {                
                body.AddForce(Vector2.up * jumpForce * Time.deltaTime);
                onAir = true;
            }

            //print(body.velocity + " goingUp:" + goingUp + " onAir:" + onAir + " jumped:" + jumped);
        }
        else body.velocity = new Vector2(0, body.velocity.y); //TODO: Syncrhonize with Walk component
    }
    
    public void stopJumping()
    {
        onAir = false;
        jumped = false;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground": stopJumping(); break;            
        }
    }
    
}
