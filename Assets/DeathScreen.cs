using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private Canvas canvas;
    private Button[] buttons;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        buttons = this.GetComponentsInChildren<Button>();
        EnableButtons();
        canvas.enabled = false;
    }
    // Start is called before the first frame update
    public void Show()
    {
        canvas.enabled = true;
        EnableButtons();
        Cursor.lockState = CursorLockMode.None;
    }

    public void Hide()
    {
        canvas.enabled = false;
        DisableButtons();
        Cursor.lockState = CursorLockMode.Locked;

    }

   private void EnableButtons()
    {
        foreach (Button button in buttons)
        {

            button.interactable = true;

        }
    }

    private void DisableButtons()
    {
        foreach (Button button in buttons)
        {

            button.interactable = false;

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
