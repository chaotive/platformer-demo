using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text hp;
    public Text items;

    public GameObject completedUi;
    public GameObject overUi;

    public static Config config;
    public static Player player;
    public static Game instance;

    private GameState state;

    public enum GameState
    {
        Playing, GameOver, Completed
    }

    void Start()
    {
        state = GameState.Playing;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        config = GameObject.FindGameObjectWithTag("GameConfig").GetComponent<Config>();
        instance = this;
    }

    void Update()
    {
        hp.text = "HP: " + Game.player.hp.ToString();
        items.text = "Items: " + Game.player.items.ToString();
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

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
//TODO Remeasure game duration
//TODO Stabilize game