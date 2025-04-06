using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : PowerUp
{
    protected override void Power()
    {
        player.health += healthIncrease;
    }    
}
