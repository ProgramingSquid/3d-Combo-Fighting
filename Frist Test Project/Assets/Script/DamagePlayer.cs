using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.attachedRigidbody.TryGetComponent(out Player player))
        {
            player.healthComponent.TakeDamage(damage);
        }
    }

}
