using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardreader : MonoBehaviour
{


    public string CardreaderKeyName;
    public float PlayerNearRadius = 5.0f;
    private KeyDoor keyDoor;
    public void CompareKeys(List<string> playerKeysNames)
    {
        if (PlayerIsNear())
        {
            if (playerKeysNames.Contains(CardreaderKeyName))
            {
                keyDoor.playerHasKey = true;
            }
        }
        
    }
        void Start()
    {
        
        if (transform.parent.gameObject.TryGetComponent<KeyDoor>(out KeyDoor _keyDoor))
        {
            keyDoor = _keyDoor;
        }
    }

    public bool PlayerIsNear()
    {

        var colliders = Physics.OverlapSphere(gameObject.transform.position, PlayerNearRadius);
        List<GameObject> context = new List<GameObject>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ICanOpenDoor>(out ICanOpenDoor canOpenDoor))
            {
                return true;
            }
        }

        return false;
    }
}
