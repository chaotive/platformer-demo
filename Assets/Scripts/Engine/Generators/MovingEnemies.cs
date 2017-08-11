using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : Generator {

    private int period = 5;
    private float currentTime = 0;

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0) {
            Instantiate(generable, transform.position, Quaternion.identity, transform);
            currentTime = period;
        }

    }
    
}
