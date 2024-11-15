using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform[] movementPoints;
    public float speedTime;
    private int nextPlatform = 1;
    private bool orderPlatforms = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (orderPlatforms && nextPlatform + 1 >= movementPoints.Length)
        {
            orderPlatforms = false;
        }

        if (!orderPlatforms && nextPlatform <= 0)
        {
            orderPlatforms = true;
        }

        if (Vector2.Distance(transform.position, movementPoints[nextPlatform].position) < 0.1f)
        {
            if (orderPlatforms)
            {
                nextPlatform += 1;
                spriteRenderer.flipX = false;
            }
            else
            {
                nextPlatform -= 1;
                spriteRenderer.flipX = true;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, movementPoints[nextPlatform].position, speedTime * Time.deltaTime);
    }
}
