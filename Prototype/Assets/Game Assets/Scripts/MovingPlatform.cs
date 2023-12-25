using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPointPosition;
    public Transform endPointPosition;

    public float speed;
    Vector2 targetPos;

    private void Start()
    {
        targetPos = endPointPosition.position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, startPointPosition.position) < .1f) targetPos = endPointPosition.position;
        if (Vector2.Distance(transform.position, endPointPosition.position) < .1f) targetPos = startPointPosition.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }


}
