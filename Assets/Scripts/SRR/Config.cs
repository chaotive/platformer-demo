using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Config : GameConfig {

    public float playerSpeed;
    public float movingEnemiesSpeed;

    public int playerHp;
    public int damageAmount;
    [Tooltip("Chance as 1 / Value, like 1 / 2 = 0.5 percent.")]
    public int collectablesChance;
    [Tooltip("Chance as 1 / Value, like 1 / 2 = 0.5 percent. This doesn't consider the minimum distance required between enemies.")]
    public int fixedEnemiesChance;
    public int fixedEnemiesMinimumDistance;
    [HideInInspector]
    public int stageLengthMin;
    [HideInInspector]
    public int stageLengthMax;
    [HideInInspector]
    public int stageHeightMin;
    [HideInInspector]
    public int stageHeightMax;
    
    new public enum FloatSettings
    {
        none,
        playerSpeed, movingEnemiesSpeed
    }

    new public enum IntSettings
    {
        none,
        playerHp, damageAmount,
        collectablesChance, fixedEnemiesChance, fixedEnemiesMinimumDistance,
        stageLengthMin, stageLengthMax, stageHeightMin, stageHeightMax
    }

    private void defaultValues()
    {        
        playerHp = 3;
        playerSpeed = 6f;

        movingEnemiesSpeed = 3f;
        damageAmount = 1;

        collectablesChance = 4;
        fixedEnemiesChance = 12;
        fixedEnemiesMinimumDistance = 5;

        stageLengthMin = 10;
        stageLengthMax = 240;
        stageHeightMin = 0;
        stageHeightMax = 3;
    }

    private void mapSettings()
    {
        foreach (var sName in Enum.GetValues(typeof(FloatSettings))) {
            print(sName.ToString());

            Type t = typeof(Config);
            PropertyInfo prop = t.GetProperty(sName.ToString());
            if (null != prop)
                print(prop.GetValue(this, null));

            var property = GetType().GetProperty(sName.ToString());
            print(property);
            if (property != null)
                print(sName + " " + property.GetValue(this, null));            
        }

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

}
