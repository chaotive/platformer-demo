using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class GameController : MonoBehaviour
{    
    public GameObject completedUi;
    public GameObject overUi;    
    public static GameController instance;

    private GameState state;    
    
    public enum GameState
    {
        Playing, GameOver, Completed
    }

    void Awake() {
        instance = this;
        state = GameState.Playing;
        print("this is Awake");
    }
    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
