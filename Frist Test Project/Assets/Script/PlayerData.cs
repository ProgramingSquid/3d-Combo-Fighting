using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool grounded = false;
    public bool landing = false;
    public bool sprinting = false;
    public bool crouching = false;

    public bool airborne = false;
    public bool fliping = false;
    public bool knockback = false;

    public bool lightAttack = false;
    public bool mediumAttack = false;
    public bool heavyAttack = false;
}
