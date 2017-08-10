using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int collectedItems = 0;
    public int hp;    
    public float speed;
    public float jumpForce = 1000;
    public float maxVelocity = 40;

    private Rigidbody2D body;
    private bool jumping;

    void Start () {
        hp = Config.game.playerHp;        
        speed = Config.game.playerSpeed;

        body = GetComponent<Rigidbody2D>();
        jumping = false;        
    }

    void Update()
    {
        if (Input.GetKey("space")) jumping = true;
        else jumping = false;        
    }

    void FixedUpdate()
    {
        if (body.velocity.x < maxVelocity) body.AddForce(Vector2.right * speed * Time.deltaTime);
        if (jumping) body.AddForce(Vector2.up * jumpForce * Time.deltaTime);        
    }
}
