using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickUp : PowerUp
{
    protected override void Power()
    {
        bullet.bulletCount += ammoIncrease;
    }
}
