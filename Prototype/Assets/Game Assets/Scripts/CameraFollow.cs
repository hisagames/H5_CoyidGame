using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 tempPos;
    public Vector3 offset;
    [SerializeField]
    private float minX, maxX;
    [SerializeField]
    private float minY, maxY;
    [Range(1, 10)]
    public float smoothFactor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        if (tempPos.y < minY)
            tempPos.y = minY;
        if (tempPos.y > maxY)
            tempPos.y = maxY;
        transform.position = tempPos;
    }
    private void FixedUpdate()
    {
        follow();
    }
    void follow()
    {
        Vector3 targetposition = player.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothposition;
    }
}
