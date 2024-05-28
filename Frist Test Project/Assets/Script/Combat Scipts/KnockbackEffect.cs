using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public Vector3 knockback = Vector3.zero;
    public bool hasLauched = false;
    public bool cancelMomentum = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            if (cancelMomentum) 
            {
                other.attachedRigidbody.velocity = Vector3.zero;
            }

            other.attachedRigidbody.AddForce(transform.right * knockback.x, ForceMode.Impulse);
            other.attachedRigidbody.AddForce(transform.up * knockback.y, ForceMode.Impulse);
            other.attachedRigidbody.AddForce(transform.forward * knockback.z, ForceMode.Impulse);
            other.attachedRigidbody.useGravity = true;
        }
    }
}
