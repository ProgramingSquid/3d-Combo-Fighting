using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    Light, Medium, Heavy
};

[System.Serializable]
public class Condition 
{
    public AttackType Button;

    public bool grounded = false;
    public bool landing = false;
    public bool sprinting = false;
    public bool crouching = false;

    public bool airborne = false;
    public bool fliping = false;
    public bool knockback = false;
    public bool IsMet(PlayerData player)
    {
        if (grounded != player.grounded) return false;
        if (landing != player.landing) return false;
        if (sprinting != player.sprinting) return false;
        if (crouching != player.crouching) return false;

        if (airborne != player.airborne) return false;
        if (fliping != player.fliping) return false;
        if (knockback != player.knockback) return false;

        if (Button == AttackType.Light && player.lightAttack) return true;
        if (Button == AttackType.Medium && player.mediumAttack) return true;
        if (Button == AttackType.Heavy && player.heavyAttack) return true;
        
        return false;
    }
}
