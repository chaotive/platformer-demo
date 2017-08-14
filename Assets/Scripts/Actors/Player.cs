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

    private bool inputPressed = false;
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
        if (Input.GetKey("space") || checkTouch()) inputPressed = true;
        else inputPressed = false;
    }

    bool checkTouch() {
        var touched = false;
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary)
            {
                touched = true;
                print("Touched! :)");
                break;
            }
        }
        return touched;
    }
    
    void FixedUpdate()
    {
        if (body.velocity.x < maxVelocity.x) body.AddForce(Vector2.right * accelerationForce * Time.deltaTime);

        bool goingUp = false;
        if (inputPressed && body.velocity.y < maxVelocity.y && !jumped) goingUp = true;
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
