using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Animator anim;
    
    public GameObject enemyself;
    public GameObject ai;

    public int maxHealth = 10;
    public int currentHealth;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private PolygonCollider2D poly;

    private bool isAlive = true;

    public GameObject HealthDrop;

    [Header("DEATH SOUND")]
    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        box = gameObject.GetComponent<BoxCollider2D>();
        circle = gameObject.GetComponent<CircleCollider2D>();
        //poly = gameObject.GetComponent<PolygonCollider2D>();

    }

    public void TakeDamage(int damage)
    {
        if ((currentHealth - damage) >= 0)
        {
            currentHealth -= damage;
            anim.SetBool("isDead", false);
            if (currentHealth <= 0)
            {
                ai.GetComponent<Enemy_Behavior>().enabled = false;
                Die();
            }
        }
    }

    void Die()
    {

        DeathSound.Play();
        anim.SetBool("isDead", true);
        RandomDrop();
        box.enabled = false;
        circle.enabled = false;
        //poly.enabled = false;

        Destroy(enemyself, 3f);

            
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void RandomDrop()
    {
        int ran = Random.Range(1, 3);
        Debug.Log(ran);
        switch (ran)
        {
            default:
                break;

            case 1:
                GameObject spawnHealthOrb = Instantiate(HealthDrop);
                spawnHealthOrb.transform.position = transform.position;
                break;

            case 2:
                break;

        }
    }
}
