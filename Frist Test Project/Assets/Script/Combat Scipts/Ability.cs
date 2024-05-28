using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abiltyName;
    public Condition condition;
    public Player player;
    public HitBox hitBox;
    public float coolDown = .1f;
    private float timer = 0f;

    private void Reset()
    {
        abiltyName = name;
    }

    public virtual void StartAbility()
    {
        if (timer > 0) return;

        Debug.Log(abiltyName);
        timer = coolDown;

        if(hitBox != null)
        {
            hitBox.EnableHitBox();
        }
    }

    public virtual void EndAbility() // not in use yet, fix later.
    {
        if(hitBox != null)
        {
            hitBox.DisableHitBox();
        }
    }

    public virtual void UpdateAbility()
    {
        if (timer > 0) 
        {
            timer -= Time.deltaTime;
        }
    }
}
