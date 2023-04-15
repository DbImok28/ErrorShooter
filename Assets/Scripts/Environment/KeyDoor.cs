using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Door
{
    public bool playerHasKey;
    protected override void Start()
    {
        base.Start();
    }


    public override bool CanBeOpened()
    {
        return PlayerIsNear() && playerHasKey;
    }

}
