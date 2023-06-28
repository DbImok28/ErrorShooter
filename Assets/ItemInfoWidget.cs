using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoWidget : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ItemInfoTextField;

    private GameObject currentInteractable;

    private Interactable interactable;

    private void SetItemInfoText(Interactable interactable) {
        ItemInfoTextField.text = interactable.ItemInfo;
    }

    private void SetItemInfoTextDefault(Interactable interactable)
    {
        ItemInfoTextField.text = "";
    }
    void Start()
    {
        //Переделать поиск игрока для подписки
        var player = FindObjectsOfType(typeof(PlayerEnvironmentInteraction)) as PlayerEnvironmentInteraction[];
        interactable = player[0].gameObject.GetComponent<Interactable>();

        if (interactable)
        {
            Debug.Log("there is smth");
            interactable.InteractableMouseEnter.AddListener(SetItemInfoText);
            interactable.InteractableMouseLeave.AddListener(SetItemInfoTextDefault);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
