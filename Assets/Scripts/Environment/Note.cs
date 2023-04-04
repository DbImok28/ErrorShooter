using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface INoteState
{
    void Display(Note note);
    void Hide(Note note);

    void NextState(Note note);
}

public class DisplayedNoteState : INoteState
{
    public void Display(Note note)
    {
        note.isDisplayed = true;
        note.enabled = true;
        note.State = new DisplayedNoteState();
        Debug.Log("display");
    }

    public void Hide(Note note)
    {
        note.isDisplayed = false;
        note.enabled = false;
        note.State = new HiddenNoteState();
        Debug.Log("hide");
    }

    public void NextState(Note note)
    {
        Debug.Log("display to hide");
        note.State=new HiddenNoteState();
    }
}

public class HiddenNoteState : INoteState
{
    public void Display(Note note)
    {
        note.isDisplayed = true;
        note.enabled = true;
        note.State = new DisplayedNoteState();
        Debug.Log("display");
    }

    public void Hide(Note note)
    {
        note.isDisplayed = false;
        note.enabled = false;
        note.State = new HiddenNoteState();
        Debug.Log("hide");
    }

    public void NextState(Note note)
    {
        Debug.Log("hide to display");
        note.State = new DisplayedNoteState();
    }
}

public class Note : MonoBehaviour
{
    public INoteState State { get; set; }
    // Start is called before the first frame update
    public bool isDisplayed;

    public Image noteImage;

    public void Display()
    {
        State.Display(this);
    }

    public void DisplayOrHide()
    {
        State.NextState(this);
    }


    public void Hide()
    {
        State.Hide(this);
    }
    void Start()
    {
        
        noteImage.enabled = false;
        isDisplayed = false;
        State = new HiddenNoteState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
