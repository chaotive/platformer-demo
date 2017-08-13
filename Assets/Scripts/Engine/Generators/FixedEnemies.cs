using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemies : Generator
{

    void Start()
    {
        for (int x = Config.game.stageLengthMin; x < Config.game.stageLengthMax; x++)
        {
            var option = Random.Range(0, Config.game.fixedEnemiesChance);
            if (option == 0)
            {
                var y = Random.Range(Config.game.stageHeightMin + 1, Config.game.stageHeightMax);
                Instantiate(generable, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }
    }

}
