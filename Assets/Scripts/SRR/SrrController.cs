using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SrrController : GameController
{
    public Text hpUi;
    public Text itemsUi;
    
    public static Config config;
    new public static SrrController instance;
    
    private int items = 0;    
    private int hp = 1;

    void Awake()
    {
        instance = this;
    }
 
    new void Start()
    {
        base.Start();
        config = GameObject.FindGameObjectWithTag("GameController").GetComponent<Config>();
        hp = config.playerHp;
    }
    
    public void itemsUp()
    {
        items++;
    }

    public void hpDown()
    {
        hp--;
        if (hp <= 0) over();
    }
    
    void Update()
    {
        hpUi.text = "HP: " + hp.ToString();
        itemsUi.text = "Items: " + items.ToString();
    }
    
}

//Tutorials:
// Game Manager
// https://unity3d.com/es/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
// Singleton
// http://clearcutgames.net/home/?p=437
// Settings on Menu
// https://gamedev.stackexchange.com/questions/74393/how-to-edit-key-value-pairs-like-a-dictionary-in-unitys-inspector
// Reflection