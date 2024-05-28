using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;
    public float speed = 5f;
    public Transform target;
    public Rigidbody rb;
    public float stoppingDistence = 1f;
    public bool isStopped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    internal void Move()
    {
        if (enemy.isStunned)
        {
            return;
        }
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        if (Vector3.Distance(targetPos, transform.position) <= stoppingDistence)
        {
            isStopped = true;
        }
        else isStopped = false;
    }

    internal void FixedMove()
    {
        if (enemy.isStunned)
        {
            return;
        }
        if (isStopped) return;

        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }
}
