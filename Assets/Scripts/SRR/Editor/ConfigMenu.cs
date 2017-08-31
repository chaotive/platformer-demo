using UnityEditor;
using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    static GameObject go;
    static string goTag = "GameController";

    [MenuItem("Savage Robot Run/Edit Config")]
    static void editConfig()
    {        
        Selection.activeGameObject = go;
    }

    [MenuItem("Savage Robot Run/Edit Config", true)]
    static bool validateEditConfig()
    {
        go = GameObject.FindGameObjectWithTag(goTag);
        return go != null;
    }

    [MenuItem("Savage Robot Run/Reset Config")]
    static void loadConfig()
    {
        go.GetComponent<Config>().Reset();
    }

    [MenuItem("Savage Robot Run/Reset Config", true)]
    static bool validateLoadConfig()
    {
        go = GameObject.FindGameObjectWithTag(goTag);
        return go != null && go.GetComponent<Config>() != null;
    }
    
}