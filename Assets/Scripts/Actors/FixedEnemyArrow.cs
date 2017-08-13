using UnityEngine;
using System.Collections;

public class FixedEnemyArrow : MonoBehaviour {

	public Vector3 velocity = new Vector3(3, 0.1f, 0);
	public Vector3 acceleration = new Vector3(0.1f, -0.2f, 0);
    
	void Start () {
		Destroy(this.gameObject, 10);        
        velocity.x = -velocity.x;
	}

	void Update () {
	
		transform.position += velocity * Time.deltaTime;
		velocity += acceleration * Time.deltaTime;
        
       transform.rotation = Quaternion.LookRotation(velocity, new Vector3(0,0,-1));
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Boundary": Destroy(gameObject); print("Destroying arrow"); break;
        }
    }


}
