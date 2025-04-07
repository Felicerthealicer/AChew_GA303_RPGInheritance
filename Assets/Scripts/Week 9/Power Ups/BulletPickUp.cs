using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickUp : PowerUp
{

    private Bullet bullet;

    protected override void Start()
    {
        base.Start();
        bullet = GameObject.FindAnyObjectByType<Bullet>().GetComponent<Bullet>();
    }

    protected override void Power()
    {
        bullet.bulletCount += ammoIncrease;
    }
}
