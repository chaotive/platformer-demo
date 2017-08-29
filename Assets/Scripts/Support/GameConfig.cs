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
    
    public Dictionary<Enum, float> floatSettings;
    /*public Dictionary<Enum, string> stringSettings;
    public Dictionary<Enum, int> intSettings;*/

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
        if (settings != null)
        {
            print("*** " + title + " ***");
            foreach (var v in settings)
            {
                print(v.Key + " " + v.Value);
            }
        }
    }

    protected void mapSettingsByType<SettingsType, T>(Dictionary<SettingsType,T> settings) {
        print("base: " + GetType());
        if (settings != null)
        {
            print("settings: " + settings);
            print("settings: " + settings.GetType());

            print(typeof(SettingsType));
            print(Enum.GetValues(typeof(SettingsType)));
            /*foreach (var pName in Enum.GetValues(typeof(SettingsType)))
            {            
                var property = GetType().GetField(pName.ToString());
                if (property != null)
                {
                    var value = property.GetValue(this);                
                    //print(pName + " " + value);
                    settings[(SettingsType)Enum.Parse(typeof(SettingsType), property.Name)] = (T)value;
                }
                else if (property.Name != "none") Debug.LogWarning(property.Name + " property value not set!");
            }*/
        }
    }
    
    protected void mapSettings()
    {
        print("base: " + GetType());
        mapSettingsByType(floatSettings);

        /*foreach (var sName in Enum.GetValues(typeof(FloatSettings)))
        {
            var property = GetType().GetField(sName.ToString());
            if (property != null)
            {
                var value = property.GetValue(this);
                print(sName + " " + value);
                floatSettings[(FloatSettings)Enum.Parse(typeof(FloatSettings), sName.ToString())] = (float)value;
            }
            else if (sName.ToString() != "none") Debug.LogWarning(sName + " property value not set!");
        }*/

        /*
        intSettings[IntSettings.PlayerHp] = playerHp;
        floatSettings[FloatSettings.PlayerSpeed] = playerSpeed;

        floatSettings[FloatSettings.MovingEnemiesSpeed] = movingEnemiesSpeed;
        intSettings[IntSettings.DamageAmount] = damageAmount;

        intSettings[IntSettings.CollectablesChance] = collectablesChance;
        intSettings[IntSettings.FixedEnemiesChance] = fixedEnemiesChance;
        intSettings[IntSettings.FixedEnemiesMinimumDistance] = fixedEnemiesMinimumDistance;

        intSettings[IntSettings.StageLengthMin] = stageLengthMin;
        intSettings[IntSettings.StageLengthMax] = stageLengthMax;
        intSettings[IntSettings.StageHeightMin] = stageHeightMin;
        intSettings[IntSettings.StageHeightMax] = stageHeightMax;
        */

        printSettings("Config floats' are ", floatSettings);
        //printSettings("Config ints' are ", intSettings);
        //printSettings("Config strings' are ", stringSettings);
    }

    abstract protected void defaultValues();

}
