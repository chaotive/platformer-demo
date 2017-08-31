using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    /// <summary>  
    ///  This class spawns objects on a dynamic fashion. 
    ///  It will spawn objects relative to the actual position of a defined followed object, relative to the original spawner and followed positions.
    ///  This class does many spawn cycles, based on the period .
    /// </summary> 

    [Tooltip("Optional object to do relative following when further spawning objects.")]
    public Transform referencePositioner;
    [Tooltip("Period to perform a new spawn, based on seconds.")]
    public int period = 5;
    [Tooltip("Object to spawn.")]
    public Transform spawnable;

    private float currentTime = 0; // time to trigger period from
    private Vector3 basePosition; // used to make spawn position relative to either yourself or a followed object, if defined

    void Update()
    {
        if (Game.isPlaying())
        {
            currentTime -= Time.deltaTime; // we decrement frame time to current time in order to calculate spawning period
            if (currentTime <= 0) // if we have decremented enough, we begin new spawning process
            {
                if (referencePositioner == null) basePosition = Vector3.zero; // we check if we have a reference followed object to position new spawn or else we just use 0 on X and Y
                else basePosition = referencePositioner.position;
                Instantiate(spawnable, basePosition + transform.position, Quaternion.identity, transform); // we actually instantiate a new object from spawnable, on calculated X and Y position, on default rotation and with current object as parent
                currentTime = period; // we set current time variable to period in order to begin decrementing it until we are ready to spawn again
            }
        }

    }
    
}
