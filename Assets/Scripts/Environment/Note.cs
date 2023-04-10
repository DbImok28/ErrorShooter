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
    }

    public void Hide(Note note)
    {
        note.isDisplayed = false;
        note.enabled = false;
        note.State = new HiddenNoteState();
    }

    public void NextState(Note note)
    {
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
    }

    public void Hide(Note note)
    {
        note.isDisplayed = false;
        note.enabled = false;
        note.State = new HiddenNoteState();
    }

    public void NextState(Note note)
    {
        note.State = new DisplayedNoteState();
    }
}

public class Note : MonoBehaviour
{
    public INoteState State { get; set; }

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
        this.State = new HiddenNoteState();
    }

    
}
