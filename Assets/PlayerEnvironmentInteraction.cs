using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanPickUp
{
    // Start is called before the first frame update

    public float ÑanReadNoteRadius;
    public float CanPickUpItemRadius=2;

    private Note nearestNote;

    public List<IPickableItem> pickedUpItems { get; set; }

    public void PickUpItem(IPickableItem pickableItem)
    {
        pickedUpItems.Add(pickableItem);
    }

    public void DisplayOrHideNote()
    {
        //List<Note> nearestNotes = new List<Note>();
        var colliders = Physics.OverlapSphere(transform.position, ÑanReadNoteRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent<Note>(out Note note))
            {
                nearestNote = note;
                Debug.Log("note nearby");
                //note.DisplayOrHide();
                nearestNote.DisplayOrHide();
                break;
            }
        }
        float distance = Vector3.Distance(nearestNote.gameObject.transform.position, gameObject.transform.position);
        if (distance < ÑanReadNoteRadius)
        {
            nearestNote.Hide();
            nearestNote = null;
        }
    }

    private void TryPickUpItem()
    {
        Debug.Log("trypickup");
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        foreach (var collider in colliders)
        {
            IPickableItem pickableItem = collider.GetComponentInParent(typeof(IPickableItem)) as IPickableItem;

            if (pickableItem != null)
            {
                pickedUpItems.Add(pickableItem);
                Debug.Log(pickedUpItems.Count);
            }
        }
    }

    void Start()
    {
        pickedUpItems = new List<IPickableItem>();
    }

    // Update is called once per frame
    void Update()
    {
        //TryReadNote();
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisplayOrHideNote();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TryPickUpItem();
        }
    }

}
