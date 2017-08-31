using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class GameController<T> : MonoBehaviour 
    where T : GameController<T>, new() // we extend GameController class with a Generic GameController children type, to allow for correct types propagation when using statics and singleton on the rest of the game
{
    /// <summary>  
    ///  This component allows for generalization of game state control, by extending it on concrete classes. 
    ///  The design goal of these components was to allow for reusability of common high level game states, such as playing, game over, completed.
    /// </summary> 

    [Tooltip("Ui object to use when game is completed.")]
    public GameObject completedUi;
    [Tooltip("Ui object to use when game is over.")]
    public GameObject overUi;
    
    private GameState state; // current high level game state

    static public T instance; // pseudo-singleton instance, of generic type T, that extends GameController and propagates game specifics properly

    public enum GameState // game state possible states
    {
        Playing, GameOver, Completed
    }

    void Awake() // initialization garanteed before other game objects
    {
        instance = (T)this;
        state = GameState.Playing;        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    static public void over() // single instance state change and proper Ui activation
    {
        instance.state = GameState.GameOver;        
        instance.overUi.SetActive(true);
    }

    static public void complete() // single instance state change and proper Ui activation
    {
        instance.state = GameState.Completed;        
        instance.completedUi.SetActive(true);
    }

    static public bool isPlaying() // single instance playing state check
    {
        return instance.state == GameState.Playing;
    }
    
}
