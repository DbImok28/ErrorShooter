using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public float ÑanReadNoteRadius;
    public float CanPickUpKeyRadius;

    private Note nearestNote;
    public void PickUpKey()
    {

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //TryReadNote();
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisplayOrHideNote();
        }
    }
}
