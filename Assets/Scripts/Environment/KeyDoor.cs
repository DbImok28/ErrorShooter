using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Door
{
    public bool playerHasKey;
    public float OpenHeight=3;
    protected override void Start()
    {
        base.Start();
        OpenedPosition = DoorTransform.position + new Vector3(0, OpenHeight, 0);
        ClosedPosition = DoorTransform.position;
    }


    public override bool CanBeOpened()
    {
        return PlayerIsNear() && playerHasKey;
    }

}
