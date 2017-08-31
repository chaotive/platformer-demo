using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class GameController<T> : MonoBehaviour 
    where T : GameController<T>, new()
{    
    public GameObject completedUi;
    public GameObject overUi;
    
    private GameState state;

    static public T instance;
    
    public enum GameState
    {
        Playing, GameOver, Completed
    }

    void Awake()
    {
        instance = (T)this;
        state = GameState.Playing;        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    static public void over()
    {
        instance.state = GameState.GameOver;        
        instance.overUi.SetActive(true);
    }

    static public void complete()
    {
        instance.state = GameState.Completed;        
        instance.completedUi.SetActive(true);
    }

    static public bool isPlaying()
    {
        return instance.state == GameState.Playing;
    }
    
}
