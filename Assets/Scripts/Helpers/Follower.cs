using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    /// <summary>  
    ///  This component allows for the current object to follow another.     
    /// </summary> 

    [Tooltip("The object to follow.")]
    public Transform followed;
    [Tooltip("How closely to follow the Y position of the followed.")]    
    public float yIntensity = 1f;
    [Tooltip("How closely to follow the X position of the followed.")]
    public float xIntensity = 1f;

    private Vector3 basePosition; // base position, stored to make movement relative

    void Start()
    {
        basePosition = transform.position;
    }

    void Update() {        
        // updating position to follow followed object, applying corresponde axis intensity (how closely following on that axis)
        if (followed != null) transform.position = new Vector3( 
            followed.position.x * xIntensity + basePosition.x, 
            followed.position.y * yIntensity + basePosition.y);        
    }
    
}
