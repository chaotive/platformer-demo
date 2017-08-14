using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : Generator {

    void Start()
    {        
        for (int x = Game.config.stageLengthMin; x < Game.config.stageLengthMax; x++)
        {            
            var option = Random.Range(0, Game.config.collectablesChance);            
            if (option == 0)
            {
                var y = Random.Range(Game.config.stageHeightMin, Game.config.stageHeightMax + 1);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }        
    }
}
