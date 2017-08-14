using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    public int playerHp = 3;
    public float playerSpeed = 8.5f;

    public float enemySpeed = 3f;
    public int damageAmount = 1;

    public int stageLengthMin = 10;
    public int stageLengthMax = 890;
    public int stageHeightMin = 0;
    public int stageHeightMax = 4;

    public int collectablesChance = 4;
    public int fixedEnemiesChance = 12;

    public static Config settings;
    public static Player player;
    public static Game game;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        settings = this;        
	}
	
}
