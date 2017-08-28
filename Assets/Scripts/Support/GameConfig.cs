using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class GameConfig : MonoBehaviour {

    /* public string[] options = new string[]
    {
         "Option1", "Option2", "Option3",
    }; */

    /*[Serializable]
    public class FloatSetting
    {
        public Enum key;
        public float value;

        public FloatSetting(Enum key, float value)
        {
            this.key = key;
            this.value = value;
        }
    }*/

    public enum FloatSettings { none }
    public enum IntSettings { none }
    public enum StringSettings { none }

    public Dictionary<Enum, float> floatSettings = new Dictionary<Enum, float>();
    public Dictionary<Enum, string> stringSettings = new Dictionary<Enum, string>();
    public Dictionary<Enum, int> intSettings = new Dictionary<Enum, int>();

    public static GameConfig instance;

    void Awake()
    {
        instance = this;
    }

    protected void printSettings<T>(string title, Dictionary<Enum, T> settings) {
        print("*** " + title + " ***");
        foreach (var v in settings) {
            print(v.Key + " " + v.Value);
        }
    }

}
