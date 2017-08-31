using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    /// <summary>  
    ///  This component allows object to walk on an horizontal fashion, based on physics.     
    ///  It achieves movement through applying force on X axis and sometimes it allows jump to also provide a bit more force.
    /// </summary> 

    [Tooltip("Is our character looking right?")]
    public bool facingRight = true; 
    [Tooltip("The maximum horizontal velocity we can achieve")]
    public float maxVelocity = 6f; 
    [Tooltip("Should we map to a Config setting?")]
    public Config.FloatSettings maxVelocityMap;
    
    private float hAccelerationForce = 800; //how much acceleration to apply for each update    
    private Rigidbody2D body; //Physics Rigidbody2D reference
    private Jump jump; //Movement Jump component reference

    void Start()
    {        
        body = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        if (!Config.isNone(maxVelocityMap)) maxVelocity = Config.floatSetting(maxVelocityMap); //apply config mapping
        if (!facingRight) maxVelocity *= -1; // we update maximum velocity depending on facing direction
    }
    
    void FixedUpdate() // we update velocity on physics update
    {
        if (Game.isPlaying())
        {
            var appliedMaxVelocity = maxVelocity;            
            if (jump != null && jump.onAir) appliedMaxVelocity *= 1.5f; // we allow a bit more of velocity if object is jumping, through locally applied variables            

            //we add horizontal force depending on maximum velocity and direction we are facing, adjusted to current frame capability
            if (facingRight && body.velocity.x < appliedMaxVelocity) body.AddForce(Vector2.right * hAccelerationForce * Time.deltaTime);
            else if (body.velocity.x > appliedMaxVelocity) body.AddForce(Vector2.left * hAccelerationForce * Time.deltaTime);            
        }
        else body.velocity = new Vector2(0, body.velocity.y); // when game is not playing anymore, we stop velocity and let object fall down vertically based on gravity
    }

}
