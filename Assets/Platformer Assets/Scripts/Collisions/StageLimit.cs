using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLimit : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colission! " + collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger! " + collision);
    }

}
