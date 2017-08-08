using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {
    public float speed;
    public GameObject player;

	void Start () {
		
	}
	
	void Update () {
        player.transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
}
