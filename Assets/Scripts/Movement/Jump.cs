using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool goingRight = true;
    public float hAccelerationForce = 800;
    public float vAccelerationForce = 4000;

    public float maxVelocity = 8.5f;
    public Config.FloatSettings maxVelocityMap;    

    private bool jumped = false;
    private bool onAir = false;
    private Rigidbody2D body;
    
    void Start()
    {                
        body = GetComponent<Rigidbody2D>();
        //maxVelocity = Config.instance.floatSettings[maxVelocityMap.ToString()];
        maxVelocity = Config.floatSetting(maxVelocityMap);        
        print("JUMP " + maxVelocity);
    }
        
    void FixedUpdate()
    {
        if (GameController.isPlaying())
        {            
            bool goingUp = false;
            if (GameInput.inputPressed && body.velocity.y < maxVelocity && !jumped) goingUp = true;
            else if (onAir) jumped = true;

            if (goingUp)
            {
                if (goingRight) body.AddForce(Vector2.right * hAccelerationForce * Time.deltaTime);
                else body.AddForce(Vector2.left * hAccelerationForce * Time.deltaTime);
                body.AddForce(Vector2.up * vAccelerationForce * Time.deltaTime);
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
