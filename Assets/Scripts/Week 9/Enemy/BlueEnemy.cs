using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : BaseEnemy
{

    public AudioSource blueAttackSFX;
    public AudioSource blueDamageSFX;

    protected override void Start()
    {
        base.Start();

        // Debug.Log("HeeHo I'm BEBE!");
    }

    public override void Attack()
    {
        base.Attack();
        blueAttackSFX.Play();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        blueDamageSFX.Play();
    }
}
