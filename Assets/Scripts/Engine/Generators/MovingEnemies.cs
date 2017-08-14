using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : Generator {

    public Transform referencePositioner;
    public int period = 5;    
    private float currentTime = 0;
    private Vector3 basePosition;

    void Update()
    {
        if (Config.game.isPlaying())
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (referencePositioner == null) basePosition = Vector3.zero;
                else basePosition = referencePositioner.position;
                Instantiate(generable, basePosition + transform.position, Quaternion.identity, transform);
                currentTime = period;
            }
        }

    }
    
}
