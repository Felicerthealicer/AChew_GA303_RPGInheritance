using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : PowerUp
{
    Coroutine co;

    protected override void Power()
    {
        co = StartCoroutine(RenablePowerUp());
    }

    IEnumerator RenablePowerUp()
    {
        while (this.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            player.attackDamage += attackDamageIncrease;
            Disable();
            yield return null;
        }

        yield return new WaitForSeconds(5f);

        player.attackDamage = 5f;

        yield return new WaitForSeconds(8f);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;

    }

}
