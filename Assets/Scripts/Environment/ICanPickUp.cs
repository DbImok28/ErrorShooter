using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanPickUp
{
    List<GameObject> pickedUpItems { get; set; }

    public void PickUpItem();
}
