using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    public int playerHp;
    public float playerSpeed;

    public float movingEnemiesSpeed;
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

    private void defaultValues() {
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

    public void Reset()
    {
        print("Resetting Config...");
        defaultValues();
    }
}
