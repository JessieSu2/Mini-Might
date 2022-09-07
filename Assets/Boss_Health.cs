using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public Animator anim;

    public GameObject enemyself;
    public GameObject ai;


    public int maxHealth = 10;
    public int currentHealth;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private PolygonCollider2D poly;

    [Header("DEATH SOUND")]
    [SerializeField] private GameObject rayGun;
    //[SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        box = gameObject.GetComponent<BoxCollider2D>();
        circle = gameObject.GetComponent<CircleCollider2D>();
        poly = gameObject.GetComponent<PolygonCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetBool("isDead", false);

        if (currentHealth <= 0)
        {

            box.enabled = false;
            circle.enabled = false;
            poly.enabled = false;
            ai.GetComponent<Boss_Behavior>().enabled = false;
            DeathSound.Play();
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);


        Destroy(enemyself, 3f);
        if (anim == true)
        {
            rayGun.SetActive(true);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }


}
