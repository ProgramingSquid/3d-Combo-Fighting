using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounceEffect : MonoBehaviour
{
    public Rigidbody rb;
    public float LaunchSpeed = 3;
    public bool hasLauched = false;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            rb.AddForce(transform.up * LaunchSpeed, ForceMode.Impulse);
            rb.AddForce(transform.forward * -LaunchSpeed, ForceMode.Impulse);
        }
    }

}
