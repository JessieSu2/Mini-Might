using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardZoneCheck : MonoBehaviour
{
    private Enemy_Behavior enemyParent;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_Behavior>();
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Alien_Attack"))
        {
            enemyParent.Flip();
            //Debug.Log(inRange);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}
