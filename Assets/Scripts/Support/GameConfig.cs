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

    private void mapSettingsByType<SettingsType, T>(Dictionary<SettingsType,T> settings) {
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

    protected void mapSettings()
    {
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
        printSettings("Config ints' are ", intSettings);
        printSettings("Config strings' are ", stringSettings);
    }

    public void OnValidate()
    {
        mapSettings();
    }

    public void Reset()
    {
        print("Resetting Config...");
        defaultValues();
        mapSettings();
    }

    abstract protected void defaultValues();

}
