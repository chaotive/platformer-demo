using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public Text hp;
    public Text items;
    
	void Update () {        
        hp.text = Config.player.hp.ToString();        
        items.text = Config.player.collectedItems.ToString();        
    }
}
