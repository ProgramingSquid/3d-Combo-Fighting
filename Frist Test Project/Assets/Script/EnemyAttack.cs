using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float startDistence = 2;
    public int damage = 5;
    public GameObject hitBox;
    public float timer = 0;
    private float duration = 3;
    public float startUp = .5f;
    public float activeTime = 1;
    public float endLag = 1.5f;
    public bool isActive = false;


    public float GetDuration()
    {
        duration = startUp + activeTime + endLag;
        return duration;
    }

    public void StartAttack()
    {
        timer = 0;
        isActive = true;
        GetDuration();
    }

    public void EndAttack()
    {
        isActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;


        timer += Time.deltaTime;

        if (timer >= duration)
        {
            EndAttack();
        }

        if (timer > duration - endLag) // endLag
        {
            DisableAtack();
        }
        else if (timer > duration - endLag - activeTime) // active
        {
            EnableAttack();
        } 
        else // start
        {

        }
    }

    private void DisableAtack()
    {
        hitBox.SetActive(false);
    }

    private void EnableAttack()
    {
        hitBox.SetActive(true);
    }
}
