using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    [SerializeField] private Transform boss;
    [SerializeField] private Transform rock;
    [SerializeField] private Transform Turtle;
    [SerializeField] private GameObject puzzleText;

    public Vector3 DefaultScale { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DefaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Become Large
        if (boss != null)
        {
            if ((Vector3.Distance(rock.position, transform.position) <= 8 || Vector3.Distance(Turtle.position, transform.position) <= 15 || Vector3.Distance(boss.position, transform.position) <= 8))
            {
                // Become Large
                puzzleText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                {
                    transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                // Shrink  
                else if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
                {
                    transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (Input.GetKeyDown(KeyCode.CapsLock))
                {
                    transform.localScale = DefaultScale;
                }
            }

            else
            {
                puzzleText.SetActive(false);
                transform.localScale = DefaultScale;
            }
        }
        
    }
}
