using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickableItem
{
    public override bool isEquiped { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void PickUp()
    {
        throw new System.NotImplementedException();
    }

    public int id { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
