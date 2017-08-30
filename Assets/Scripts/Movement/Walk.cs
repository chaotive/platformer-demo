using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Movement
{
    public bool facingRight = true;                 
    public float maxVelocity = 6f;
    public Config.FloatSettings maxVelocityMap;

    private float hAccelerationForce = 800;    
    private float airVelocityFactor = 1.5f; //times normal maxVelocity
    private Rigidbody2D body;
    
    void Start()
    {
        var direction = 1;
        if (!facingRight) direction = -1;
        body = GetComponent<Rigidbody2D>();
        if (!Config.isNone(maxVelocityMap)) maxVelocity = Config.floatSetting(maxVelocityMap);
        maxVelocity *= direction;
    }
    
    void FixedUpdate()
    {
        if (Game.isPlaying())
        {
            var appliedMaxVelocity = maxVelocity;
            if (onAir) appliedMaxVelocity *= airVelocityFactor;
            
            if (facingRight && body.velocity.x < appliedMaxVelocity) body.AddForce(Vector2.right * hAccelerationForce * Time.deltaTime);
            else if (body.velocity.x > appliedMaxVelocity) body.AddForce(Vector2.left * hAccelerationForce * Time.deltaTime);
            
            print(name + " " + body.velocity);
        }
        else body.velocity = new Vector2(0, body.velocity.y);
    }

}
