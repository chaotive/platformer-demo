using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public Text hp;
    public Text items;

    public GameObject completedUi;
    public GameObject overUi;

    private GameState state;

    public enum GameState
    {
        Playing, GameOver, Completed
    }

    void Start()
    {
        state = GameState.Playing;
    }

    void Update () {        
        hp.text = "HP: " + Config.player.hp.ToString();        
        items.text = "Items: " + Config.player.items.ToString();        
    }

    public void over() {
        state = GameState.GameOver;
        //print("Game Over!");
        overUi.SetActive(true);
    }

    public void complete() {
        state = GameState.Completed;
        //print("Game completed!");
        completedUi.SetActive(true);
    }

    public bool isPlaying() {
        return state == GameState.Playing;
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}

//TODO Remeasure game duration
//TODO Stabilize game