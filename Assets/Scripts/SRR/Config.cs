using UnityEngine;

public class Config : GameConfig //extends and actually implements GameConfig abstract base class
{
    /// <summary>  
    ///  This component allows configuration to be specifically tailored for each game, by extending generalizations on GameConfig class.     
    ///  Configuration definitions on this component will be easily shared on Unity editor and game code.
    /// </summary> 

    [Tooltip("The player maximimum velocity.")]
    public float playerSpeed;
    [Tooltip("The moving enemy maximimum velocity.")]
    public float movingEnemiesSpeed;

    [Tooltip("The player maximimum health points.")]
    public int playerHp;
    [Tooltip("How much health points the player loses when hit.")]
    public int damageAmount;

    [Tooltip("Chance that collectables spawn. Chance is 1 / Value, like 1 / 2 = 0.5 percent.")]
    public int collectablesChance;
    [Tooltip("Chance that fixed enemies spawn. Chance is 1 / Value, like 1 / 2 = 0.5 percent. Please also consider the minimum distance required between enemies setting.")]
    public int fixedEnemiesChance;
    [Tooltip("The minimum distance between fixed enemies spawning.")]
    public int fixedEnemiesMinimumDistance;

    [Tooltip("The minimum stage length where collectables and fixed enemies will spawn. Player starts at 0.")]
    public int stageLengthMin;
    [Tooltip("The maximum stage length where collectables and fixed enemies will spawn. Player starts at 0.")]
    public int stageLengthMax;
    [Tooltip("The minimum stage height where collectables and fixed enemies will spawn. Player runs at 0.")]
    public int stageHeightMin;
    [Tooltip("The maximum stage height where collectables and fixed enemies will spawn. Player runs at 0.")]
    public int stageHeightMax;

    //Set of float type settings that are shared to be elected among Components using Config
    new public enum FloatSettings
    {
        none,
        playerSpeed, movingEnemiesSpeed
    }

    //Set of int type settings that are shared to be elected among Components using Config
    new public enum IntSettings
    {
        none,
        playerHp, damageAmount,
        collectablesChance, fixedEnemiesChance, fixedEnemiesMinimumDistance,
        stageLengthMin, stageLengthMax, stageHeightMin, stageHeightMax
    }

    //Sets default values for configuration on Reset and Initialization of component through GameConfig base class
    protected override void defaultValues()
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

}
