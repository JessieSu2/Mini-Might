using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    public ParticleSystem anim;
    float timer = 5f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 2.5f)
        {
            enemy.SetActive(true);
        }
        if (timer <  0)
        {
            anim.Stop();
        }
    }
}
