using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key :  MonoBehaviour, IPickableItem
{
    protected ItemsInventory itemsInventory;
    public float PickUpRadius;
    public bool isEquiped { get; set; }

    public void PickUp()
    {
        itemsInventory.Keys.Add(gameObject);
        Destroy(gameObject);
    }

    public int id { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, PickUpRadius);
        List<GameObject> context = new List<GameObject>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ICanPickUp>(out ICanPickUp canPickUp))
            {
                canPickUp.PickUpItem(this);
            }
        }
    }
}
