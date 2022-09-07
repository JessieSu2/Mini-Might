using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [HideInInspector] public float gunAngle;
    //private PlayerShooting playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Player(Clone)");
        //playerShoot = thePlayer.GetComponent<PlayerShooting>(); 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 gunPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - gunPosition.x;
        mousePosition.y = mousePosition.y - gunPosition.y;
        gunAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        // Neutral Aim
        if ((-30 < gunAngle && gunAngle <= 0) || (-180 <= gunAngle && gunAngle <= -150))
            {
                anim.SetInteger("AimState", 0);
            }
        // Down Midpoint Aim
        if ((-60 < gunAngle && gunAngle <=  -30) || (-150 < gunAngle && gunAngle <= -120))
            {
                anim.SetInteger("AimState", 3);
            }
        // Down Aim
        if ((-90 <= gunAngle && gunAngle <= -60) || (-120 < gunAngle && gunAngle < -90))
            {
                anim.SetInteger("AimState", 4);
            }
        // Neutral Aim
        if ((30 > gunAngle && gunAngle >= 0) || (180 >= gunAngle && gunAngle >= 150))
            {
                anim.SetInteger("AimState", 0);
            }
        // Up Midpoint Aim
        if ((60 > gunAngle && gunAngle >= 30) || (150 > gunAngle && gunAngle >= 120))
            {
                anim.SetInteger("AimState", 1);
            }
        // Up Aim
        if ((90 >= gunAngle && gunAngle >= 60) || (120 > gunAngle && gunAngle > 90))
            {
                anim.SetInteger("AimState", 2);
            }

       

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            // Uncomment this to make not fixed
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f ,-gunAngle));

            // Comment this to make not fixed
            /*transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -AngleAdjustment(gunAngle)));*/


        }
        else
        {
            // Uncomment this to make not fixed
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gunAngle));
            
            // Comment this to make not fixed
            /*transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, AngleAdjustment(gunAngle)));*/

        }
            if (Input.GetMouseButtonDown(0))
/*            if (Input.GetMouseButtonDown(0) &&  playerShoot.madeShot == true)*/
            {
                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
                {
                    StartCoroutine(Recoil(-gunAngle, 180f));
                }
                else
                {
                    StartCoroutine(Recoil(gunAngle, 0f));
                }
                //playerShoot.madeShot = false;
            }
    
        //Debug.Log(playerShoot.nextProjectile);
    }

    IEnumerator Recoil(float angle, float direction)
	{
        // Debug.Log(transformObject.rotation);
        yield return new WaitForSeconds(0.01f);
            transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle + 5f));
        yield return new WaitForSeconds(0.03f);
            transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle + 10f));
        yield return new WaitForSeconds(0.02f);
            transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle - 5f));
        yield return new WaitForSeconds(0.02f);
            transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle - 10f));
        yield return new WaitForSeconds(0.03f);
	}

    public float AngleAdjustment(float angle)
    {
        if ((22.5 >= angle && angle >= -22.5))
        {
            return 0;
        }
        if ((67.5 >= angle && angle > 22.5))
        {
            return 45;
        }
        if ((112.5 >= angle && angle > 67.5))
        {
            return 90;
        }
        if ((157.5 >= angle && angle > 112.5))
        {
            return 135;
        }
        if ((-157.5 >= angle || angle > 157.5))
        {
            return 180;
        }
        if ((-90 >= angle && angle > -157.5))
        {
            return -135;
        }
        if ((-22.5 >= angle && angle > -90))
        {
            return -45;
        }
        return angle;

    }
}
