using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int damage = 1;
    public float activeTimer = 0;
    public float duration = 1;
    public float hitStun = 0f;
    public Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        activeTimer -= Time.deltaTime;

        if(activeTimer <= 0)
        {
            DisableHitBox();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().TakeDamage(damage, hitStun);
        }
    }

    public void DisableHitBox()
    {
        collider.enabled = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void EnableHitBox()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        collider.enabled = true;
        activeTimer = duration;
    }
}
