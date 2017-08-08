using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int collectedItems = 0;
    public int hp;    
    public float speed;
    
    void Start () {
        hp = Config.game.playerHp;        
        speed = Config.game.playerSpeed;        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
