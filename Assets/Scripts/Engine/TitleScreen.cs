using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public string stageSceneName;
    
    public void start() {
        SceneManager.LoadScene(stageSceneName);        
    }
}
