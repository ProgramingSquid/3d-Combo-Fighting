using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState 
{ 
    idle,
    chasing,
    attacking,
    stunned
}
public class Enemy : MonoBehaviour
{
    public int health = 3;
    public Health healthComponent;
    public EnemyAttack enemyAttack;
    public float stun = 0f;
    public EnemyDetection enemyDetection;
    public EnemyMovement enemyMovement;
    public bool isStunned = false;
    public GameObject stunObject;
    public EnemyState state = EnemyState.idle;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent.OnDie.AddListener(Die);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.idle:
                if (enemyDetection.target != null)
                {
                    state = EnemyState.chasing;
                    enemyMovement.target = enemyDetection.target;
                }
                    break;
            case EnemyState.chasing:
                enemyMovement.Move();
                if (Vector3.Distance(transform.position, enemyDetection.target.position) < enemyAttack.startDistence)
                {
                    state = EnemyState.attacking;
                    enemyAttack.StartAttack();
                }
                break;
            case EnemyState.attacking:
                if (!enemyAttack.isActive)
                {
                    state = EnemyState.chasing;
                }
                break;
            case EnemyState.stunned:
                stun -= Time.deltaTime;
                if (stun <= 0)
                {
                    stunObject.SetActive(false);
                    stun = 0;
                    isStunned = false;
                    state = EnemyState.idle;
                }
                break;
        }
        if (isStunned)
        {
            state = EnemyState.stunned;
        }
        
    }

    private void FixedUpdate()
    {
        if (state == EnemyState.chasing)
        {
            enemyMovement.FixedMove();
        }
    }

    public void TakeDamage(int damage, float stunAmount = 0)
    {
        stun += stunAmount;
        if (stun > 0) 
        { 
            isStunned = true;
            stunObject.SetActive(true);
        }
        healthComponent.TakeDamage(damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}