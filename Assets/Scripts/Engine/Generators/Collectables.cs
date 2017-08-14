using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : Generator {

    void Start()
    {        
        for (int x = Config.settings.stageLengthMin; x < Config.settings.stageLengthMax; x++)
        {            
            var option = Random.Range(0, Config.settings.collectablesChance);            
            if (option == 0)
            {
                var y = Random.Range(Config.settings.stageHeightMin, Config.settings.stageHeightMax + 1);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }        
    }
}
