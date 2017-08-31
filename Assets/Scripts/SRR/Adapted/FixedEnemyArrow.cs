using UnityEngine;
using System.Collections;

public class FixedEnemyArrow : MonoBehaviour {

	public Vector3 velocity = new Vector3(3, 0.1f, 0);
	public Vector3 acceleration = new Vector3(0.1f, 0.2f, 0);
    
	void Start () {        
		Destroy(gameObject, 10);        
        velocity.x = -velocity.x;        
        acceleration.y -= transform.position.y / 3.5f;        
    }

	void Update () {
        if (Game.isPlaying())
        {
            transform.position += velocity * Time.deltaTime;
            velocity += acceleration * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(velocity, new Vector3(0, 0, -1));
        }
    }

}
