using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {    
    private Vector2 maxVelocity;
    private float accelerationForce = 800;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        maxVelocity = new Vector2(Game.config.enemySpeed * -1, 8.5f);        
    }

    void FixedUpdate()
    {
        if (Game.isPlaying())
        {
            if (body.velocity.x > maxVelocity.x) body.AddForce(Vector2.left * accelerationForce * Time.deltaTime);
            //print("Moving enemy: " + body.velocity);
        } else body.velocity = new Vector2(0, body.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); break;            
        }
    }
}
