using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public float accelerationForce = 800;
    protected Vector2 maxVelocity = new Vector2(-8.5f, 8.5f);

    protected Rigidbody2D body;

    void Start()
    {
        accelerationForce = Config.game.playerSpeed;

        body = GetComponent<Rigidbody2D>();
    }

}
