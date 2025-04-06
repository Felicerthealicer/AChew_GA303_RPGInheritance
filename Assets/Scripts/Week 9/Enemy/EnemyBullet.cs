using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public BlueEnemy blue;
    public PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            blue.attackDamage = 1f;
            player.TakeDamage(blue.attackDamage);


            Destroy(this.gameObject);

        }
    }

}
