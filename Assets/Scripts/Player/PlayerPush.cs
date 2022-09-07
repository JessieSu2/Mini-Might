using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        rock.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pushable Rock") && transform.localScale == new Vector3(0.7f, 0.7f, 0.7f))
        {
            Debug.Log("Pushing");
            rock.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
    }
    private void Update()
    {
        if (transform.localScale != new Vector3(0.7f, 0.7f, 0.7f)) 
        {
            rock.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

}
