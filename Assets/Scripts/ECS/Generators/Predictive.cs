using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictive : Generator
{
    private int minDistance = 5;
    private int lastX;

    void Start()
    {
        minDistance = Game.config.fixedEnemiesMinimumDistance;
        lastX = -minDistance;
        for (int x = Game.config.stageLengthMin; x < Game.config.stageLengthMax; x++)
        {            
            if (x - lastX > minDistance)
            { 
                var option = Random.Range(0, Game.config.fixedEnemiesChance);
                if (option == 0)
                {                
                    var y = Random.Range(Game.config.stageHeightMin + 1, Game.config.stageHeightMax + 1);
                    lastX = x;
                    Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
                }
            }
        }

        /*
        // Collectables
        for (int x = Game.config.stageLengthMin; x < Game.config.stageLengthMax; x++)
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
