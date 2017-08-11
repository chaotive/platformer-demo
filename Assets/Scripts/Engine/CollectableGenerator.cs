using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGenerator : MonoBehaviour {

    public Transform collectable;
    public Transform parent;

    void Start()
    {        
        for (int x = Config.game.collectablesLengthMin; x < Config.game.collectablesLengthMax; x++)
        {            
            var option = Random.Range(0, Config.game.collectablesChance);            
            if (option == 0)
            {
                var y = Random.Range(Config.game.collectablesHeightMin, Config.game.collectablesHeightMax);
                Instantiate(collectable, new Vector3(x, y, 0), Quaternion.identity, parent);
            }
        }        
    }
}
