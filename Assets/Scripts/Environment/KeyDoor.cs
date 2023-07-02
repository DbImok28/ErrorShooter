using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDoor : Door
{
    private Cardreader cardreader;
    public UnityEvent KeyMatchedEvent;
    private bool playerHasMatchingKey = false;

    protected override void Start()
    {
        base.Start();
        cardreader = gameObject.GetComponentInChildren<Cardreader>();
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
