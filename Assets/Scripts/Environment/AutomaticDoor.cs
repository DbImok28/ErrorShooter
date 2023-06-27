using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : Door
{
    protected override void Start()
    {
        base.Start();
    }

    public override bool CanBeOpened()
    {
        return PlayerIsNear();
    }

    public override bool CanBeClosed()
    {
        return !PlayerIsNear();
    }


}
