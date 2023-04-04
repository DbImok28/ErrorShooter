using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanPickUp
{
    // Start is called before the first frame update

    public float ÑanReadNoteRadius;
    public float CanPickUpItemRadius=2;
    public float CanOpenDoorRadius = 2;

    private Note nearestNote;

    public List<GameObject> pickedUpItems { get; set; }

    public void PickUpItem()
    {
        Debug.Log("trypickup");
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        foreach (var collider in colliders)
        {
            IPickableItem pickableItem = collider.GetComponentInParent(typeof(IPickableItem)) as IPickableItem;

            if (pickableItem != null)
            {
                Debug.Log(collider.gameObject.GetInstanceID());
                pickedUpItems.Add(collider.gameObject);
                //Destroy(collider.gameObject);
                Debug.Log(pickedUpItems.Count);
            }
        }
    }

    public void AttachKey()
    {
        var colliders = Physics.OverlapSphere(transform.position, CanOpenDoorRadius);
        foreach (var collider in colliders)
        {
            KeyDoor keyDoor = collider.GetComponentInParent(typeof(KeyDoor)) as KeyDoor;

            if (keyDoor != null)
            {
                Debug.Log("KeyDoor detected");
                keyDoor.CompareKeys(pickedUpItems);
            }
        }
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


    void Start()
    {
        pickedUpItems = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //TryReadNote();
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisplayOrHideNote();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            PickUpItem();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Attach key command");
            AttachKey();
        }
    }

}
