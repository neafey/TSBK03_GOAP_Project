using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = pointA;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
