using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator anim;

    public float nextAttack;
    // public float attackTime;
    public float attackrate;

    public Transform player;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    [Header("Attack Sound")]
    [SerializeField] public Transform playerTransform;
    [SerializeField] private AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("IsAttacking", true);
                Debug.Log("test");
                attackSound.Play();
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);
                foreach (Collider2D enemy in damage)
                {
                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.GetComponent<Enemy_Health>().TakeDamage(1);
                    }
                    else if (enemy.CompareTag("BossEnemy"))
                    {
                        if(playerTransform.localScale != new Vector3(0.7f, 0.7f, 0.7f))
                        {
                            enemy.GetComponent<Boss_Health>().TakeDamage(0);
                        }
                        else
                        {
                            enemy.GetComponent<Boss_Health>().TakeDamage(1);
                        }
                    }
                }
                nextAttack = Time.time + 1f / attackrate;
            }

        }
        else
        {
            // attackTime = Time.deltaTime;
            anim.SetBool("IsAttacking", false);
        }
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }*/
}
