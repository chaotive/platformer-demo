using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesHelper : MonoBehaviour {
    public string sceneToLoadName;
    
    public void loadScene() {
        SceneManager.LoadScene(sceneToLoadName);        
    }
}
