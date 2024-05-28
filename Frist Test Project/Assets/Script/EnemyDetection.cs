using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public LayerMask playerMask;
    public float radius = 10f;
    public Transform target;


    public void LookForPlayer()
    {
       Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, playerMask);
       
        if (hitColliders.Length > 0)
        {
           target = hitColliders[0].attachedRigidbody.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) return;
        LookForPlayer();
    }
}
