using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public  class Interactable:MonoBehaviour
{
    public UnityEvent<Interactable> InteractableAssigned;
    public UnityEvent<Interactable> InteractableMouseEnter;
    public UnityEvent<Interactable> InteractableMouseLeave;

    public string ItemInfo;
    public void Assign()
    {
        InteractableAssigned?.Invoke(this);
    }

    public void Interact()
    {
        InteractableMouseEnter?.Invoke(this);
    }

    public void ReleaseInteraction()
    {
        InteractableMouseLeave?.Invoke(this);
    }

    

}
