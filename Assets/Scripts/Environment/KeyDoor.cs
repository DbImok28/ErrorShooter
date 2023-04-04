using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject key;

    /*
    private void BeOpened()
    {
        Debug.Log("open");
        Vector3 up = door.position + new Vector3(0, openHeight, 0);
        StartCoroutine(MoveCoroutine(up));
        //door.position+= up;
        //Animate(up);
        isOpen = true;
    }

    private void BeClosed()
    {
        Debug.Log("close");
        Vector3 down = door.position + new Vector3(0, -openHeight, 0);
        StartCoroutine(MoveCoroutine(down));
        //door.position += down;
        //Animate(down);
        isOpen = false;
    }
    */

    private void CheckIfOpen()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //если у игрока в инвентаре есть дубль ключа
        }
    } 
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
