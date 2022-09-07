using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform ShootPoint;
    public GameObject Torso;
    public GameObject Arms;
    public float projectilerate = 5f;
    public float projectileFireRate = 1.2f;
    public float nextProjectile = 0f;
    public bool madeShot = false;

    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Transform transformer = ShootPoint.transform;
        Vector3 GunPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Time.time >= nextProjectile)
        {
            if (Input.GetMouseButtonDown(0))
            {

                madeShot = true;
                shoot();
                // anim = Arms.GetComponent<Animation>();
                // anim.Play("ShootRecoil");
                nextProjectile = Time.time + projectileFireRate / projectilerate;
            }
        }
        Debug.Log(nextProjectile);
        if(GunPoint.x < transform.position.x)
        {
        
            Torso.transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            Arms.transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transformer.rotation.z);
            
        }
        else{
            Torso.transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            Arms.transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transformer.rotation.z);
        }
        
        
    }

    void shoot()
    {
        Instantiate(bullet, ShootPoint.transform.position , ShootPoint.transform.rotation);
        
        
    }

    
}
