using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Vector2 leftPoint;
    public Vector2 rightPoint;

    bool left;
    bool right;

    [SerializeField] private float movementSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        leftPoint = new Vector2(transform.position.x - 15f, transform.position.y);
        rightPoint = new Vector2(transform.position.x + 15f, transform.position.y);
        left = true;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(leftPoint, transform.position) < .1f)
        {
            sprite.flipX = !sprite.flipX;
            right = true;
            left = false;
        }

        if (right)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                    rightPoint,
                                    Time.deltaTime * movementSpeed);
        }

        if (Vector2.Distance(rightPoint, transform.position) < .1f)
        {
            sprite.flipX = !sprite.flipX;
            right = false;
            left = true;
        }

        if (left)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                leftPoint,
                                                Time.deltaTime * movementSpeed);
        }

    }


}