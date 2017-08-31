using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameConfig : MonoBehaviour {
    /// <summary>  
    ///  This component allows for generalization of global game configuration, by extending it on concrete classes. 
    ///  The design goal of these configuration components was to allow for typed definitions of typed settings to be easily shared on Unity editor, while also allowing both runtime and typed checks on configuration values.
    /// </summary> 

    // base values for float, int and string type of settings names definitions, it also makes evident usage of none as default value
    public enum FloatSettings { none }
    public enum IntSettings { none }
    public enum StringSettings { none }

    // internal dictionary variables that actually holds the map of the settings names (as string), further specified on Config class with the corresponding typed values
    protected Dictionary<string, float> floatSettings = new Dictionary<string, float>();
    protected Dictionary<string, string> stringSettings = new Dictionary<string, string>();
    protected Dictionary<string, int> intSettings = new Dictionary<string, int>();
    
    public static GameConfig instance; // pseudo Singleton Configuration instance container

    void Awake()
    {
        instance = this; // pseudo Singleton simple instance initialization
    }

    void OnValidate() // calls the settings mapping on every value change on Config class fields
    {
        mapSettings();
    }

    public void Reset() // when Reset and Initialization of Config class happens, we set fields default values again and then map the values to the exposed config settings
    {
        print("Resetting Config...");
        defaultValues();
        mapSettings();
    }

    // helper method to print the settings values, with SettingsType as key generic type (now always string) and T as generic value type
    // goal is to generalize and reuse printing settings of any type
    protected void printSettings<SettingsType, T>(string title, Dictionary<SettingsType, T> settings) {       
        print("*** " + title + " ***");
        foreach (var v in settings)
        {
            print(v.Key + " " + v.Value);
        }        
    }

    // helper method to map the settings values to internal settings Dictionary, with string as key and T as generic value type
    // it uses Reflection internally to dynamically get fields implemented on Config class and save each by string key and actual value to the settings Dictionary
    // goal is to generalize and reuse mapping settings of any type
    protected void mapSettingsByType<T>(Dictionary<string, T> settings) {
        settings.Clear();
        if (settings != null)        
            foreach (var f in GetType().GetFields())
                if (f.FieldType == typeof(T))                
                    settings[f.Name] = (T)f.GetValue(this);                    
    }
    
    // method that goes mapping the available different typed settings available and then shows a summary of what was actually mapped into internal <string, T> Dictionaries
    protected void mapSettings()
    {        
        mapSettingsByType(floatSettings);
        mapSettingsByType(stringSettings);
        mapSettingsByType(intSettings);
        
        printSettings("Config floats' are ", floatSettings);
        printSettings("Config ints' are ", intSettings);
        printSettings("Config strings' are ", stringSettings);
    }

    // placeholder to request implementor of GameConfig based child to actually provide values for each field. In this case, Config class implements it
    abstract protected void defaultValues(); 

    // public static methods that provide settings value to class clients, from a generic Enum setting to an internal setting Dictionary request as string key to corresponding type
    static public float floatSetting (Enum setting) { return instance.floatSettings[setting.ToString()]; }
    static public int intSetting(Enum setting) { return instance.intSettings[setting.ToString()]; }
    static public string stringSetting(Enum setting) { return instance.stringSettings[setting.ToString()]; }

    static public bool isNone(Enum setting) { return setting.ToString() == "none"; } // helper method to encapsulate checking of "none" setting mapping selection
}
