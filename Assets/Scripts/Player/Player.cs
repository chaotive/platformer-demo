using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int collectedItems = 0;
    public int hp;    
    public float speed;

    private Rigidbody2D body;
    
    void Start () {
        hp = Config.game.playerHp;        
        speed = Config.game.playerSpeed;

        body = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (Input.GetKey("space"))
            print("space key was pressed");
    }

    void FixedUpdate()
    {
        body.AddForce(Vector2.right * speed * Time.deltaTime);
    }
}
