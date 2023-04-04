using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanPickUp
{
    // Start is called before the first frame update

    public float �anReadNoteRadius;
    public float CanPickUpItemRadius;

    private Note nearestNote;

    public List<IPickableItem> pickedUpItems { get; set; }

    public void PickUpItem(IPickableItem pickableItem)
    {
        pickedUpItems.Add(pickableItem);
    }

    public void DisplayOrHideNote()
    {
        //List<Note> nearestNotes = new List<Note>();
        var colliders = Physics.OverlapSphere(transform.position, �anReadNoteRadius);
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
        if (distance < �anReadNoteRadius)
        {
            nearestNote.Hide();
            nearestNote = null;
        }
    }

    private void TryPickUpItem()
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        List<GameObject> context = new List<GameObject>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<IPickableItem>(out IPickableItem pickableItem))
            {
                pickedUpItems.Add(pickableItem);
                Debug.Log(pickedUpItems.Count);
            }
        }
    }

    void Start()
    {
        
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
