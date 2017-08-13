using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    protected Rigidbody2D body;

    protected void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

}
