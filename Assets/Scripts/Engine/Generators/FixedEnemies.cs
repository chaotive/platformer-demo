using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemies : Generator
{

    void Start()
    {
        for (int x = Config.settings.stageLengthMin; x < Config.settings.stageLengthMax; x++)
        {
            var option = Random.Range(0, Config.settings.fixedEnemiesChance);
            if (option == 0)
            {
                var y = Random.Range(Config.settings.stageHeightMin + 1, Config.settings.stageHeightMax);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }
    }

}
