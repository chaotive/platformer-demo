using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictive : Spawner
{
    public int minDistance = 0;
    public int stageLengthMin;
    public int stageLengthMax;
    public int stageHeightMin;
    public int stageHeightMax;
    [Tooltip("Chance as 1 / Value, like 1 / 2 = 0.5 percent. This doesn't consider the minimum distance required between enemies.")]
    public int spawnChance;
    
    private int lastX;

    void Start()
    {        
        lastX = -minDistance;
        for (int x = stageLengthMin; x < stageLengthMax; x++)
        {            
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

        
        // Collectables
        /*for (int x = Game.config.stageLengthMin; x < Game.config.stageLengthMax; x++)
        {
            var option = Random.Range(0, Game.config.collectablesChance);
            if (option == 0)
            {
                var y = Random.Range(Game.config.stageHeightMin, Game.config.stageHeightMax + 1);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }
        */
    }
}
