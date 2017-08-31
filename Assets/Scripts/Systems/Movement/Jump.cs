using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    /// <summary>  
    ///  This component allows object to jump, based on physics.     
    ///  It achieves movement through applying force on Y axis, as long as you keep pressing the input and not hitting maximum velocity.
    /// </summary> 

    [Tooltip("Maximum horizontal velocity")]
    public float maxVelocity = 8.5f;

    [HideInInspector]
    public bool onAir = false; // are we on air?    
    private float vAccelerationForce = 4000; // vertical acceleration force
    private bool jumped = false; // have jump already?
    private Rigidbody2D body; // physics body reference
    
    void Start()
    {                
        body = GetComponent<Rigidbody2D>();            
    }
        
    void FixedUpdate() // we update velocity on physics update
    {
        if (Game.isPlaying())
        {            
            var goingUp = false; // we should determine if we are going up still or not
            //if we are pressing input and our velocity is lower than maximum allowed velocity, and we have not jumped already, then we are going up for sure!
            if (InputController.inputPressed && body.velocity.y < maxVelocity && !jumped) goingUp = true;
            else if (onAir) jumped = true; //if not, and we are already on air, then we have already definitely jumped!

            if (goingUp)
            {                
                body.AddForce(Vector2.up * vAccelerationForce * Time.deltaTime); // if we are going up, we surely need to add vertical acceleration force :)
                onAir = true; // on air is true while going up
            }            
        }        
    }
    
    public void stopJumping() // we clean up jump state variables
    {
        onAir = false;
        jumped = false;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground": stopJumping(); break; // when we touch the ground again, we trigger the stop jumping function      
        }
    }
    
}
