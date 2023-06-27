using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDoor : Door
{

    private bool playerHasMatchingKey=false;

    private Cardreader cardreader;

    public UnityEvent KeyMatchedEvent;
    protected override void Start()
    {
        base.Start();
        cardreader = gameObject.GetComponentsInChildren<Cardreader>()[0];
    }

    public override bool CanBeOpened()
    {
        return PlayerIsNear() && playerHasMatchingKey;
    }

    public bool PlayerHasMatchingKey(List<GameObject> playerkeys, out GameObject matchingKey)
    {
        playerHasMatchingKey = cardreader.PlayerHasMatchingKey(playerkeys, out matchingKey);
        return playerHasMatchingKey;
    }

    public override bool CanBeClosed()
    {
        return !PlayerIsNear();
    }
}
