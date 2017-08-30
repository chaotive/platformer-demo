using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Movement
{
    public bool facingRight = true;    
    public float maxVelocity = 8.5f;

    private float hAccelerationForce = 800;
    private float vAccelerationForce = 4000;
    private bool jumped = false;    
    private Rigidbody2D body;
    
    void Start()
    {                
        body = GetComponent<Rigidbody2D>();            
    }
        
    void FixedUpdate()
    {
        if (Game.isPlaying())
        {            
            var goingUp = false;
            if (GameInput.inputPressed && body.velocity.y < maxVelocity && !jumped) goingUp = true;
            else if (onAir) jumped = true;

            if (goingUp)
            {                
                if (facingRight) body.AddForce(Vector2.right * hAccelerationForce * Time.deltaTime);
                else body.AddForce(Vector2.left * hAccelerationForce * Time.deltaTime);
                body.AddForce(Vector2.up * vAccelerationForce * Time.deltaTime);
                onAir = true;
            }
            //print(body.velocity + " goingUp:" + goingUp + " onAir:" + onAir + " jumped:" + jumped);
        }        
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
