using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesHelper : MonoBehaviour {
    /// <summary>  
    ///  This component allows for provides basic scenes helper functions to be available.    
    /// </summary>     

    [Tooltip("Name of the scene to load.")]
    public string sceneToLoadName;
    
    public void loadScene() {
        SceneManager.LoadScene(sceneToLoadName); // actual load of scene
    }
}
