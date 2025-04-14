using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : BaseEnemy
{

    public AudioSource redAttackSFX;
    public AudioSource redDamageSFX;
    public AudioSource redNODamageSFX;

    public override void Attack()
    {
        base.Attack();
        redAttackSFX.enabled = true;  
        redAttackSFX.Play();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        redDamageSFX.enabled = true;
        redDamageSFX.Play();
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            redNODamageSFX.Play();
        }
    }

}
