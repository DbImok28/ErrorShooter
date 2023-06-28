using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class PlayerEnvironmentInteraction : MonoBehaviour, ICanOpenDoor
{
    
    public float СanReadNoteRadius;
    public float CanPickUpItemRadius = 2;
    public float CanOpenDoorRadius = 2;
    public float CanInteractRadius = 4;

    private Note nearestNote;

    public GameObject currentInteractable;

    private PlayerInventory inventory;

    public void Init(PlayerInventory playerInventory)
    {
        this.inventory = playerInventory;
    }

    public void PickUpKey()
    {
        GameObject key;

        if (KeyIsNear(out key))
        {
            inventory.Keys.Add(key);

            //Анимация подбора ключа

            key.gameObject.SetActive(false);
        }
    }

    public bool KeyIsNear(out GameObject key)
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
          
        foreach (var collider in colliders)
        {
            if(collider.gameObject.GetComponent<KeyForDoor>())
            {
                key = collider.gameObject;
                return true;
            }
        }

        key = null;
        return false;
    }

    public void AttachKey()
    {
        GameObject keyDoor;

        if(KeyDoorIsNear(out keyDoor))
        {
            GameObject matchingKey;

            if (TryMatchKey(keyDoor, out matchingKey))
            {
                matchingKey.SetActive(true);

                //Анимация прикладывания ключа

                //Анимация открытия двери

            }
        }
    }

    //Работает только тогда, когда обьект со скриптом Cardreader вложен в обьект со скриптом KeyDoor
    public bool KeyDoorIsNear(out GameObject keyDoor)
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, CanPickUpItemRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.GetComponentInParent<KeyDoor>())
            {
                keyDoor = collider.gameObject.transform.parent.gameObject;
                return true;
            }
        }

        keyDoor = null;
        return false;

    }

    public bool TryMatchKey(GameObject keyDoor, out GameObject matchingKey)
    {
        KeyDoor _keyDoor = keyDoor.GetComponent<KeyDoor>();
        if (_keyDoor)
        {
            GameObject _matchingKey;

            if (_keyDoor.PlayerHasMatchingKey(inventory.Keys, out  _matchingKey))
            {
                matchingKey = _matchingKey;
                return true;
            }
        }

        matchingKey = null;
        return false;
    }


    public void DisplayOrHideNote()
    {
        /*
        var colliders = Physics.OverlapSphere(transform.position, СanReadNoteRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent<Note>(out Note note))
            {
                nearestNote = note;
                nearestNote.DisplayOrHide();
                break;
            }
        }
        */
    }

    public void Interact()
    {
        RaycastHit hit;
        //Переделать поиск камеры
        Ray ray = GameObject.Find("Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, CanInteractRadius))
        {
            Transform objectHit = hit.transform;
            if (objectHit.gameObject.TryGetComponent(out Interactable interactable))
            {
                if (currentInteractable == interactable.gameObject)
                {
                   return;
                }
                if (currentInteractable)
                {
                    currentInteractable.GetComponent<Interactable>().ReleaseInteraction();
                }
                
                currentInteractable = interactable.gameObject;
                currentInteractable.GetComponent<Interactable>().Interact();
            }
            else
            {
                if (currentInteractable)
                {
                    currentInteractable.GetComponent<Interactable>().ReleaseInteraction();
                    currentInteractable = null;
                }
            }
        }

    }

}
