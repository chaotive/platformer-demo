using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    public int playerHp;
    public float playerSpeed;

    public float enemySpeed;
    public int damageAmount;

    public int stageLengthMin;
    public int stageLengthMax;
    public int stageHeightMin;
    public int stageHeightMax;

    public int collectablesChance;
    public int fixedEnemiesChance;
    
    private void defaultValues() {
        playerHp = 3;
        playerSpeed = 6f;

        enemySpeed = 3f;
        damageAmount = 1;

        stageLengthMin = 10;
        stageLengthMax = 890;
        stageHeightMin = 0;
        stageHeightMax = 3;

        collectablesChance = 4;
        fixedEnemiesChance = 12;
    }

    public void Reset()
    {
        print("Resetting Config...");
        defaultValues();
    }
}
