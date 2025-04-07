using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : BaseEnemy
{

    public AudioSource redAttackSFX;
    public AudioSource redDamageSFX;

    protected override void Start()
    {
        base.Start();

        // Debug.Log("HeeHo I'm ARRA");
    }

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


}
