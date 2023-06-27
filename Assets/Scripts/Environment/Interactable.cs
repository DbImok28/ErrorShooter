using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public  class Interactable:MonoBehaviour
{
    
    public UnityEvent InteractableMouseEnter = new UnityEvent();
    public UnityEvent InteractableMouseLeave = new UnityEvent();

    public void Interact()
    {
        InteractableMouseEnter?.Invoke();
    }

    public void ReleaseInteraction()
    {
        InteractableMouseLeave?.Invoke();
    }

    

}
