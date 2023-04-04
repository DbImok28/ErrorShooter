using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanPickUp
{
    List<IPickableItem> pickedUpItems { get; set; }

    public void PickUpItem(IPickableItem pickableItems);
}
