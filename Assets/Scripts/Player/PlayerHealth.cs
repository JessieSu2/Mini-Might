using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public Animator anim;

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    public ParticleSystem PowerUp;
    private SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        anim = GetComponent<Animator>();
        sm = GetComponent<SoundManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        /*        anim.SetTrigger("Hurt");
        */
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //game.Setup();
        /*        anim.SetBool("isDead", true);
        */
        /*        Destroy(gameObject, 0.45f);
        */
        Destroy(gameObject, 0.45f);
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPowerUp"))
        {
            if ((currentHealth + 1) < maxHealth)
            {
                currentHealth = currentHealth + 1;
                sm.PlayPowerUp();
            }
            else
            {
                currentHealth = maxHealth;
                sm.PlayPowerUp();
            }
            PowerUp.Play();
            Destroy(collision.gameObject);

        }
    }
}
