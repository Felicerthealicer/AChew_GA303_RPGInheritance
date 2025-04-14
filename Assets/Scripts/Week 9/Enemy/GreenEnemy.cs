using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : BaseEnemy
{

    public AudioSource greenAttackSFX;
    public AudioSource greenDamageSFX;
    public override void Attack()
    {
        base.Attack();
        greenAttackSFX.enabled = true;
        greenAttackSFX.Play();

        //Debug.Log(this.gameObject.name + " deals " + attackDamage + " damage to you!");
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        greenDamageSFX.enabled = true;
        greenDamageSFX.Play();
    }
}
