using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health = 20;
    public int maxHealth = 20;

    public UnityEvent OnHealthChanged;
    public UnityEvent OnDie;
    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthChanged.Invoke();
        if (health <= 0)
        {
            OnDie.Invoke();
        }
    }
}
