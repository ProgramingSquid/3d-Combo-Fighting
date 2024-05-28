using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public PlayerData data;
    public Ability airKick;
    public Ability sweepKick;
    public Ability highKick;
    public Ability airPunch;
    public List<Ability> abilities;
    public Health healthComponent;

    public UnityEvent OnHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        healthComponent.OnDie.AddListener(Die);
    }

    // Update is called once per frame
    void Update()
    {
        bool lightAttack = Input.GetKeyDown(KeyCode.J);
        bool mediumAttack = Input.GetKeyDown(KeyCode.K);
        bool heavyAttack = Input.GetKeyDown(KeyCode.L);

        data.lightAttack = lightAttack;
        data.mediumAttack = mediumAttack;
        data.heavyAttack = heavyAttack;

        for (int i = 0; i < abilities.Count; i++)
        {
            if (abilities[i].condition.IsMet(data))
            {
                abilities[i].StartAbility();
            }
            abilities[i].UpdateAbility();
        }
    }



    private void Die()
    {
        Debug.Log("bla...");
    }
}
