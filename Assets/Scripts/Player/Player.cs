using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int collectedItems = 0;
    public int hp;    
    public float speed;
    public float jumpForce = 4000;

    private Vector2 maxVelocity = new Vector2(10f, 8.5f);

    private bool keyPressed;
    private bool jumped;    
    private bool onAir;

    private Rigidbody2D body;

    void Start () {
        hp = Config.game.playerHp;        
        speed = Config.game.playerSpeed;

        body = GetComponent<Rigidbody2D>();
        keyPressed = false;

        jumped = false;        
        onAir = false;        
    }

    void Update()
    {
        if (Input.GetKey("space")) keyPressed = true;        
        else keyPressed = false;        
    }

    void FixedUpdate()
    {
        if (body.velocity.x < maxVelocity.x) body.AddForce(Vector2.right * speed * Time.deltaTime);
        
        bool goingUp = false;
        if (keyPressed && body.velocity.y < maxVelocity.y && !jumped) goingUp = true;
        else if (onAir) jumped = true;
        
        if (goingUp)
        {
            body.AddForce(Vector2.right * speed * Time.deltaTime);
            body.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            onAir = true;            
        }
        
        print(body.velocity + " goingUp:" + goingUp + " onAir:" + onAir + " jumped:" + jumped);
    }

    public void stopJumping() {        
        onAir = false;
        jumped = false;
    }
}
