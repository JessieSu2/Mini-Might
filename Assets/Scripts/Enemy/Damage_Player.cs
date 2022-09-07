using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Player : MonoBehaviour
{

    float timer = 2f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && timer == 2f)
        {
            timer -= .1f;
            if (collider.gameObject.GetComponent<BoxCollider2D>())
            {
                collider.GetComponent<PlayerHealth>().TakeDamage(1);
            }
            
        }
    }


    private void Update()
    {
        if (timer < 2f)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 2f;
        }
    }
    /*public void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.tag == "Player")

        {

            Debug.Log("Struck");

        }

    }*/
}
