using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : Generator {

    void Start()
    {        
        for (int x = Config.game.stageLengthMin; x < Config.game.stageLengthMax; x++)
        {            
            var option = Random.Range(0, Config.game.collectablesChance);            
            if (option == 0)
            {
                var y = Random.Range(Config.game.stageHeightMin, Config.game.stageHeightMax);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }        
    }
}
