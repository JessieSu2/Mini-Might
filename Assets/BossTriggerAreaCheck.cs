using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerAreaCheck : MonoBehaviour
{
    private Boss_Behavior enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Boss_Behavior>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }

    /*private void Update()
    {
        Debug.Log(enemyParent.target.position);
    }*/
}
