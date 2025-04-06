using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UppiesDoor : Door
{
    public bool doesItUppies = true;

    public override void OpenDoor()
    {
        base.OpenDoor();
        this.transform.Translate(Vector3.up * 5f);
    }
}
