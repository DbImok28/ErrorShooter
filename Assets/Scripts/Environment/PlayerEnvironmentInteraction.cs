using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanOpenDoor
{
    // Start is called before the first frame update

    public UnityEvent InteractableMouseEnter;
    public UnityEvent InteractableMouseLeave;

    public float ÑanReadNoteRadius;
    public float CanPickUpItemRadius = 2;
    public float CanOpenDoorRadius = 2;
    public float CanInteractRadius = 4;

    private Note nearestNote;

    public List<string> playerKeysNames;

    private Text playerKeysUI;
    public List<GameObject> pickedUpItems { get; set; }

    private Interactable currentInteractable;
    public string PrintPlayerKeysNames()
    {
        string keysNames = "Your keys : \n" + System.String.Join(",", playerKeysNames.Select(p => p).ToArray());

        return keysNames;
    }

    public void PickUpKey()
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        foreach (var collider in colliders)
        {
            KeyForDoor pickableItem = collider.GetComponentInParent(typeof(KeyForDoor)) as KeyForDoor;

            if (pickableItem != null)
            {
                playerKeysNames.Add(pickableItem.KeyName);
                playerKeysUI.text = PrintPlayerKeysNames();
                Destroy(pickableItem.gameObject);
            }
        }
    }

    public void AttachCardreaderKey()
    {
        RaycastHit raycastHit;
        Ray ray = gameObject.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100f))
        {
            if (raycastHit.transform.TryGetComponent<Cardreader>(out Cardreader cardreader))
            {
                cardreader.CompareKeys(playerKeysNames);
            }
        }
    }

    public void DisplayOrHideNote()
    {
        var colliders = Physics.OverlapSphere(transform.position, ÑanReadNoteRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent<Note>(out Note note))
            {
                nearestNote = note;
                nearestNote.DisplayOrHide();
                break;
            }
        }
    }

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = gameObject.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, CanInteractRadius))
        {
            Transform objectHit = hit.transform;
            if (objectHit.gameObject.TryGetComponent(out Interactable interactable))
            {
                if (currentInteractable)
                {
                    if (currentInteractable == interactable)
                    {
                        return;
                    }
                    else
                    {
                        currentInteractable.Dehighlight();
                        currentInteractable = null;
                        currentInteractable = interactable;
                        currentInteractable.Highlight();
                    }
                }
                else
                {
                    currentInteractable = interactable;
                    currentInteractable.Highlight();
                }

            }
            else if (currentInteractable)
            {
                currentInteractable.Dehighlight();
                currentInteractable = null;
            }
        }

    }

    void Start()
    {
        playerKeysNames = new List<string>();
        //playerKeysUI = GameObject.Find("PlayerKeys").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            DisplayOrHideNote();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PickUpKey();
        }
        if (Input.GetMouseButtonDown(0))
        {
            AttachCardreaderKey();
        }
        Interact();
    }

}
