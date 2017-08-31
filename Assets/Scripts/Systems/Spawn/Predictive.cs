using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictive : MonoBehaviour
{
    public Transform spawnable;

    public int minDistance = 0;
    public Config.IntSettings minDistanceMap;
    [Tooltip("Chance as 1 / Value, like 1 / 2 = 0.5 percent. This doesn't consider the minimum distance required between enemies.")]
    public int spawnChance = 4;
    public Config.IntSettings spawnChanceMap;

    public int stageLengthMin = 10;
    public Config.IntSettings stageLengthMinMap;
    public int stageLengthMax = 240;
    public Config.IntSettings stageLengthMaxMap;
    public int stageHeightMin = 0;
    public Config.IntSettings stageHeightMinMap;
    public int stageHeightMax = 3;
    public Config.IntSettings stageHeightMaxMap;
    
    private int lastX;

    private void configMappings() {
        if (!Config.isNone(minDistanceMap)) minDistance = Config.intSetting(minDistanceMap);
        if (!Config.isNone(stageLengthMinMap)) stageLengthMin = Config.intSetting(stageLengthMinMap);
        if (!Config.isNone(stageLengthMaxMap)) stageLengthMax = Config.intSetting(stageLengthMaxMap);
        if (!Config.isNone(stageHeightMinMap)) stageHeightMin = Config.intSetting(stageHeightMinMap);
        if (!Config.isNone(stageHeightMaxMap)) stageHeightMax = Config.intSetting(stageHeightMaxMap);
        if (!Config.isNone(spawnChanceMap)) spawnChance = Config.intSetting(spawnChanceMap);
    }

    void Start()
    {
        configMappings();
        lastX = -minDistance;
        for (int x = stageLengthMin; x < stageLengthMax; x++)                    
            if (x - lastX > minDistance)
            { 
                var option = Random.Range(0, spawnChance);
                if (option == 0)
                {                
                    var y = Random.Range(stageHeightMin + 1, stageHeightMax + 1);
                    lastX = x;
                    Instantiate(spawnable, new Vector3(x, y, 0), Quaternion.identity, transform);
                }
            }        
    }
}
