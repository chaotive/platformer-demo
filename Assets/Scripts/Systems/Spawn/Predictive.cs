using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictive : MonoBehaviour
{
    /// <summary>  
    ///  This class spawns objects on a predictive fashion. 
    ///  You define the spawn area and other parameters, and the objects to be spawned. 
    ///  This class does a single spawn cycle, on the beginning of the game.
    /// </summary> 
    
    [Tooltip("Object to spawn.")]
    public Transform spawnable;
    [Tooltip("Minimum X distance required to pass before attempting to spawn Object.")]
    public int minDistance = 0;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings minDistanceMap;
    [Tooltip("Chance to spawn Object on every X positon integer of map. Chance as 1 / Value, like 1 / 2 = 0.5 percent. This doesn't consider the minimum distance required between enemies.")]
    public int spawnChance = 4;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings spawnChanceMap;

    [Tooltip("Spawn area beginning X coordinate.")]
    public int spawnAreaLengthMin = 10;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings spawnAreaLengthMinMap;
    [Tooltip("Spawn area ending X coordinate.")]
    public int spawnAreaLengthMax = 240;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings spawnAreaLengthMaxMap;
    [Tooltip("Spawn area beginning Y coordinate.")]
    public int spawnAreaHeightMin = 0;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings spawnAreaHeightMinMap;
    [Tooltip("Spawn area ending Y coordinate.")]
    public int spawnAreaHeightMax = 3;
    [Tooltip("Get value from global Config?")]
    public Config.IntSettings spawnAreaHeightMaxMap;
    
    private int lastX;

    private void configMappings() { // allows that each class field is mapped to a global configuration option, without depending on specific Config fields
        if (!Config.isNone(minDistanceMap)) minDistance = Config.intSetting(minDistanceMap);
        if (!Config.isNone(spawnChanceMap)) spawnChance = Config.intSetting(spawnChanceMap);
        if (!Config.isNone(spawnAreaLengthMinMap)) spawnAreaLengthMin = Config.intSetting(spawnAreaLengthMinMap);
        if (!Config.isNone(spawnAreaLengthMaxMap)) spawnAreaLengthMax = Config.intSetting(spawnAreaLengthMaxMap);
        if (!Config.isNone(spawnAreaHeightMinMap)) spawnAreaHeightMin = Config.intSetting(spawnAreaHeightMinMap);
        if (!Config.isNone(spawnAreaHeightMaxMap)) spawnAreaHeightMax = Config.intSetting(spawnAreaHeightMaxMap);        
    }

    void Start()
    {
        configMappings(); // first, we map actual values to config 
        lastX = -minDistance; // then, we initialize the last known X position with a value that ensures we have minimum spawn distance fullfilled
        for (int x = spawnAreaLengthMin; x < spawnAreaLengthMax; x++) // it goes for each integer X position of the spawn area length
            if (x - lastX > minDistance) // if minimum spawn distance is met, we try to spawn on this X position
            {
                var option = Random.Range(0, spawnChance); // if spawn chance is met, we begin the spawn process
                if (option == 0)
                {                
                    var y = Random.Range(spawnAreaHeightMin + 1, spawnAreaHeightMax + 1); // we will spawn at a random int Y position, from the defined spawn area height
                    lastX = x; // we update last spawned X to measure minimum distance eventually
                    Instantiate(spawnable, new Vector3(x, y, 0), Quaternion.identity, transform); // we actually instantiate a new object from spawnable, on calculated X and Y position, on default rotation and with current object as parent
                }
            }        
    }
}
