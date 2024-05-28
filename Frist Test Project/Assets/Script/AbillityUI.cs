using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AbillityUI : MonoBehaviour
{
    public Player player;
    public TMP_Text lightText;
    public TMP_Text mediumText;
    public TMP_Text heavyText;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightText.text = "light";
        mediumText.text = "medium";
        heavyText.text = "heavy";

        PlayerData testData = player.data;
        foreach (Ability ability in player.abilities)
        {
            testData.lightAttack = false;
            testData.mediumAttack = false;
            testData.heavyAttack = false;

            testData.lightAttack = true;
            if (ability.condition.IsMet(testData))
            {
                lightText.text = ability.abiltyName;
                continue;
            }
            testData.lightAttack = false;
            testData.mediumAttack = true;
            if (ability.condition.IsMet(testData))
            {
                mediumText.text = ability.abiltyName;
                continue;
            }
            testData.mediumAttack = false;
            testData.heavyAttack = true;
            if (ability.condition.IsMet(testData))
            {
                heavyText.text = ability.abiltyName;
                continue;
            }
            testData.heavyAttack = false;
        }
    }
}
