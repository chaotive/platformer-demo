using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    public int playerHp = 1;
    public float playerSpeed = 8.5f;

    public float enemySpeed = 8.5f;
    public int damageAmount = 1;

    public int collectablesLengthMin = 10;
    public int collectablesLengthMax = 890;
    public int collectablesHeightMin = 0;
    public int collectablesHeightMax = 4;
    public int collectablesChance = 6;
    
    public static Config game;
    public static Player player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        game = this;
	}
	
}
