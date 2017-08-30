using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class GameConfig : MonoBehaviour {       
    public enum FloatSettings { none }
    public enum IntSettings { none }
    public enum StringSettings { none }
    
    protected Dictionary<string, float> floatSettings = new Dictionary<string, float>();
    protected Dictionary<string, string> stringSettings = new Dictionary<string, string>();
    protected Dictionary<string, int> intSettings = new Dictionary<string, int>();

    public static GameConfig instance;

    void Awake()
    {
        instance = this;
    }

    void OnValidate()
    {
        mapSettings();
    }

    public void Reset()
    {
        print("Resetting Config...");
        defaultValues();
        mapSettings();
    }

    protected void printSettings<SettingsType, T>(string title, Dictionary<SettingsType, T> settings) {       
        print("*** " + title + " ***");
        foreach (var v in settings)
        {
            print(v.Key + " " + v.Value);
        }        
    }

    protected void mapSettingsByType<T>(Dictionary<string, T> settings) {        
        if (settings != null)        
            foreach (var f in GetType().GetFields())
                if (f.FieldType == typeof(T))                
                    settings[f.Name] = (T)f.GetValue(this);                    
    }
    
    protected void mapSettings()
    {        
        mapSettingsByType(floatSettings);
        mapSettingsByType(stringSettings);
        mapSettingsByType(intSettings);
        
        printSettings("Config floats' are ", floatSettings);
        printSettings("Config ints' are ", intSettings);
        printSettings("Config strings' are ", stringSettings);
    }

    abstract protected void defaultValues();

    static public float floatSetting (Enum setting) {        
        return instance.floatSettings[setting.ToString()];
    }

    static public int intSetting(Enum setting)
    {
        return instance.intSettings[setting.ToString()];
    }

    static public string stringSetting(Enum setting)
    {
        return instance.stringSettings[setting.ToString()];
    }

    static public bool isNone(Enum setting) {
        return setting.ToString() == "none";
    }
}
