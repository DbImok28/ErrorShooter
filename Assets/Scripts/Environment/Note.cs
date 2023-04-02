using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDisplayed;

    public Image noteImage;

    private void Display()
    {
        Debug.Log("Display");
        noteImage.enabled = true;
        isDisplayed = true;
    }

    public void DisplayOrHide()
    {
        if (isDisplayed)
        {
            Hide();
        }
        else
        {
            Display();
        }
    }

    private void Hide()
    {
        Debug.Log("Hide");
        noteImage.enabled = false;
        isDisplayed = false;
    }
    void Start()
    {
        noteImage.enabled = false;
        isDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
