using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedEnemy : MonoBehaviour {
    public Transform arrowPrefab;
    public Transform hand;
    
    private Animator animator;
    private float arrowDelay = 0.4f;

    public int shootPeriod = 5;
    private float currentTime = 0;

    private void Start()
    {        
        animator = GetComponent<Animator>();            
        flip();        
    }

    public void flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;        
    }

    IEnumerator makeArrow(float delay, bool right = false)
    {
        yield return new WaitForSeconds(delay);
        var go = Instantiate(arrowPrefab, hand.position, Quaternion.identity) as Transform;        
    }

    public void shoot() {        
        if (Random.Range(0f, 1.0f) > 0.5f) animator.SetTrigger("attack");
        else animator.SetTrigger("special");
        StartCoroutine(makeArrow(arrowDelay));        
    }

    void Update()
    {
        if (Config.game.isPlaying())
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                shoot();
                currentTime = shootPeriod;
            }
        }
    }

}
