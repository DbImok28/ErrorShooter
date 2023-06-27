using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Cardreader : MonoBehaviour
{
    public string CardreaderKeyName;

    public bool PlayerHasMatchingKey(List<GameObject> playerkeys, out GameObject matchingKey)
    {
       
        foreach(GameObject playerKey in playerkeys)
        {
            if (playerKey.TryGetComponent<KeyForDoor>(out KeyForDoor keyForDoor))
            {
                matchingKey = playerKey;
                return true;
            }
        }

        matchingKey = null;
        return false;
    }
    
}
