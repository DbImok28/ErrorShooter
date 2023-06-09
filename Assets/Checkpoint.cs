using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn playerRespawn = other.gameObject.GetComponent<PlayerRespawn>();
        if (playerRespawn)
        {
            if (!playerRespawn.CheckPoints.Contains(gameObject))
            {
                playerRespawn.CheckPoints.Add(gameObject);
            }
            
        }
    }
}
