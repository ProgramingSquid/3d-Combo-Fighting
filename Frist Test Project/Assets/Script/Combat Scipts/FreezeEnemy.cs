using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemy : MonoBehaviour
{
    public float duration = 0.2f;
    public float timer;
    private Rigidbody Enemyrb;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if(Enemyrb)
                {
                Enemyrb.useGravity = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.attachedRigidbody.velocity = Vector3.zero;
            Enemyrb = other.attachedRigidbody;
            Enemyrb.useGravity = false;
            timer = duration;

        }
    }
}
