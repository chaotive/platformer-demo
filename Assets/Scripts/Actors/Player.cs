using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int items = 0;
    public int hp;
    public float accelerationForce = 800;
    public float jumpForce = 4000;

    private Vector2 maxVelocity;

    private bool keyPressed = false;
    private bool jumped = false;
    private bool onAir = false;

    private Rigidbody2D body;

    void Start()
    {
        hp = Config.game.playerHp;
        maxVelocity = new Vector2(Config.game.playerSpeed, 8.5f);
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("space")) keyPressed = true;
        else keyPressed = false;
    }

    void FixedUpdate()
    {
        if (body.velocity.x < maxVelocity.x) body.AddForce(Vector2.right * accelerationForce * Time.deltaTime);

        bool goingUp = false;
        if (keyPressed && body.velocity.y < maxVelocity.y && !jumped) goingUp = true;
        else if (onAir) jumped = true;

        if (goingUp)
        {
            body.AddForce(Vector2.right * accelerationForce * Time.deltaTime);
            body.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            onAir = true;
        }

        //print(body.velocity + " goingUp:" + goingUp + " onAir:" + onAir + " jumped:" + jumped);
    }

    public void stopJumping()
    {
        onAir = false;
        jumped = false;
    }

    public void itemsUp()
    {
        items++;
    }

    public void hpDown()
    {
        hp--;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground": stopJumping(); break;
            case "StageEnd": print("This is the end of the stage"); break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                hpDown();
                Destroy(other.gameObject);
                break;
            case "Collectable":
                itemsUp();
                Destroy(other.gameObject);
                break;
        }
    }
}
