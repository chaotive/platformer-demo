using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : GameController<Game>
{
    public Text hpUi;
    public Text itemsUi;
    
    private int items = 0;    
    private int hp = 1;
    private int damageAmount = 1;

    void Start()
    {
        print(instance);
        hp = Config.intSetting(Config.IntSettings.playerHp);
        damageAmount = Config.intSetting(Config.IntSettings.damageAmount);
    }
    
    public void itemsUp()
    {
        items++;
    }

    public void hpDown()
    {
        hp -= damageAmount;
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