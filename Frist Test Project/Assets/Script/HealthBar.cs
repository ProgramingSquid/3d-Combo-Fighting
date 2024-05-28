using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider bar;
    public Health entity;

    // Start is called before the first frame update
    void Start()
    {
        entity.OnHealthChanged.AddListener(UpdateHealthBar);
    }

    private void OnDestroy()
    {
        entity.OnHealthChanged.RemoveListener(UpdateHealthBar);

    }

    public void UpdateHealthBar()
    {
        bar.value = entity.health / (float)entity.maxHealth;
    }
}
