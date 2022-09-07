using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GunRotation gunRotation;
    public float RangeOfMotion = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float gunAngle = gunRotation.gunAngle;
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            {
                StartCoroutine(Recoil(-gunAngle, 180f));
            }
            else
            {
                StartCoroutine(Recoil(gunAngle, 0f));
            }
        }
    }

    IEnumerator Recoil(float angle, float direction)
    {
        // Debug.Log(transformObject.rotation);
        yield return new WaitForSeconds(0.01f);
        transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle + (RangeOfMotion/2)));
        yield return new WaitForSeconds(0.03f);
        transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle + (RangeOfMotion)));
        yield return new WaitForSeconds(0.02f);
        transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle - (RangeOfMotion / 2)));
        yield return new WaitForSeconds(0.02f);
        transform.rotation = Quaternion.Euler(new Vector3(direction, 0f, angle - (RangeOfMotion)));
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
