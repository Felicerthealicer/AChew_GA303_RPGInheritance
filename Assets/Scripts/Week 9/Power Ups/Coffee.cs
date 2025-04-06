using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : PowerUp
{
    protected override void Power()
    {
        player.attackDamage += attackDamageIncrease;
    }
}
