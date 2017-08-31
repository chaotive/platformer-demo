using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public bool facingRight = true; //is our character looking right?             
    public float maxVelocity = 6f; //the maximum velocity we can achieve
    public Config.FloatSettings maxVelocityMap; //to which setting should we map maxVelocity to global configuration?
    
    private float hAccelerationForce = 800; //how much acceleration to apply for each
    private float airVelocityFactor = 1.5f; //times normal maxVelocity
    private Rigidbody2D body; //Physics Rigidbody2D reference
    private Jump jump; //Movement Jump component reference

    void Start()
    {        
        body = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        if (!Config.isNone(maxVelocityMap)) maxVelocity = Config.floatSetting(maxVelocityMap); //apply config mapping
        if (!facingRight) maxVelocity *= -1;
    }
    
    void FixedUpdate()
    {
        if (Game.isPlaying())
        {
            var appliedMaxVelocity = maxVelocity;
            if (jump != null && jump.onAir) appliedMaxVelocity *= airVelocityFactor;
            
            if (facingRight && body.velocity.x < appliedMaxVelocity) body.AddForce(Vector2.right * hAccelerationForce * Time.deltaTime);
            else if (body.velocity.x > appliedMaxVelocity) body.AddForce(Vector2.left * hAccelerationForce * Time.deltaTime);        
        }
        else body.velocity = new Vector2(0, body.velocity.y);
    }

}
