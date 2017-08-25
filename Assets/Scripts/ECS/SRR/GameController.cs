using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text hpUi;
    public Text itemsUi;
    public GameObject completedUi;
    public GameObject overUi;

    public static Config config;    
    public static GameController instance;

    private GameState state;    
    private int items = 0;    
    private int hp = 1;
    
    public enum GameState
    {
        Playing, GameOver, Completed
    }

    void Awake() {
        instance = this;
    }

    void Start()
    {
        state = GameState.Playing;        
        config = GameObject.FindGameObjectWithTag("GameConfig").GetComponent<Config>();

        hp = Game.config.playerHp;
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
    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        hpUi.text = "HP: " + hp.ToString();
        itemsUi.text = "Items: " + items.ToString();
    }

    static public void over()
    {
        instance.state = GameState.GameOver;
        //print("Game Over!");
        instance.overUi.SetActive(true);
    }

    static public void complete()
    {
        instance.state = GameState.Completed;
        //print("Game completed!");
        instance.completedUi.SetActive(true);
    }

    static public bool isPlaying()
    {
        return instance.state == GameState.Playing;
    }
    
}

//Tutorials:
// Game Manager
// https://unity3d.com/es/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
// Singleton
// http://clearcutgames.net/home/?p=437
