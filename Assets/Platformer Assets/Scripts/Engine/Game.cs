using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public Text hp;
    public Text items;

    private Player player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();        
    }
		
	void Update () {        
        hp.text = player.hp.ToString();        
        items.text = player.collectedItems.ToString();        
    }
}
