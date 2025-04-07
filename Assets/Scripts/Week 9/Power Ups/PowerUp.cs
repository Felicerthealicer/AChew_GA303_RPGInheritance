using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected PlayerRPG player;

    public float healthIncrease = 1f;
    public float attackDamageIncrease = 1f;
    public float ammoIncrease = 1f;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Power();
            Destroy(this.gameObject);
        }
    }

    protected virtual void Power()
    {
        
    }    

}
