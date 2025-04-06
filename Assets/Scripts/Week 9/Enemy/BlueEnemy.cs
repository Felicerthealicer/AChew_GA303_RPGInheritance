using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : BaseEnemy
{
    public GameObject bulletPreFab;
    public Transform bulletSpawnPosition;
    public float force = 500;

    protected override void Start()
    {
        base.Start();

        // Debug.Log("HeeHo I'm the best slime BEBE!");
    }

    protected override void Update()
    {
        base.Update();

        this.transform.LookAt(player.transform.position);
    }

    protected override void Attack()
    {
        base.Attack();
        
        GameObject go = Instantiate(bulletPreFab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * force);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }



}
