using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer: MonoBehaviour
{
    Rigidbody rb;
    public float duration = .2f;
    public float timer = 0f;
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                rb.useGravity = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            timer = duration;


        }
    }
}
