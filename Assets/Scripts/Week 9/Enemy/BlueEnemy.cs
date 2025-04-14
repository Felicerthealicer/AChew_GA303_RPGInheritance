using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : BaseEnemy
{

    public AudioSource blueAttackSFX;
    public AudioSource blueDamageSFX;

    public override void Attack()
    {
        base.Attack();
        blueAttackSFX.enabled = true;
        blueAttackSFX.Play();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        blueDamageSFX.enabled = true;
        blueDamageSFX.Play();
    }
}
