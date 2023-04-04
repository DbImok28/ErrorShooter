using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableItem
{
    public abstract bool isEquiped { get; set; }

    public abstract void PickUp();
}
