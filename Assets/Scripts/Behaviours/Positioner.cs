using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioner : MonoBehaviour {

    public Transform followed;
    public float yIntensity = 1f;
    public float xIntensity = 1f;

    private Vector3 basePosition;

    void Start()
    {
        basePosition = transform.position;
    }

    void Update() {        
        if (followed != null) transform.position = new Vector3( 
            followed.position.x * xIntensity + basePosition.x, 
            followed.position.y * yIntensity + basePosition.y);        
    }
    
}
