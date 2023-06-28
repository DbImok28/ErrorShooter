using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableColorBorder : MonoBehaviour
{
    public Color OutlineColor;
    public float OutlineWidth;

    private Interactable interactable;

    private void Start()
    {
        interactable = gameObject.GetComponent<Interactable>();

        interactable.InteractableMouseEnter.AddListener(Highlight);
        interactable.InteractableMouseLeave.AddListener(Dehighlight);
    }

    private void OnDestroy()
    {
        interactable.InteractableMouseEnter.RemoveListener(Highlight);
        interactable.InteractableMouseLeave.RemoveListener(Dehighlight);
    }

    public void Highlight(Interactable interactable)
    {
        transform.gameObject.AddComponent<Outline>();
        transform.gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
        transform.gameObject.GetComponent<Outline>().OutlineColor = OutlineColor != null ? OutlineColor : Color.blue;
        transform.gameObject.GetComponent<Outline>().OutlineWidth = OutlineWidth != null ? OutlineWidth : 10;
    }

    public void Dehighlight(Interactable interactable)
    {
        Destroy(transform.gameObject.GetComponent<Outline>());
    }
}
