using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanOpenDoor
{
    // Start is called before the first frame update

    public float ÑanReadNoteRadius;
    public float CanPickUpItemRadius=2;
    public float CanOpenDoorRadius = 2;

    private Note nearestNote;

    public List<string> playerKeysNames;
    public List<GameObject> pickedUpItems { get; set; }

    public void PickUpKey()
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        foreach (var collider in colliders)
        {
            KeyForDoor pickableItem = collider.GetComponentInParent(typeof(KeyForDoor)) as KeyForDoor;

            if (pickableItem != null)
            {
                playerKeysNames.Add(pickableItem.KeyName);
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
            if(raycastHit.transform.TryGetComponent<Cardreader>(out Cardreader cardreader))
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

    void Start()
    {
        playerKeysNames = new List<string>();
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
    }

}
