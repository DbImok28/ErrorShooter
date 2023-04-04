using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour
{



    private bool isOpen;
    private float openRadius = 5;
    public float openHeight = 2;
    public float openTime = 3000;
    private Transform door;
    private float doorColliderHeight;
    private float doorColliderWidth;
    private bool doorIsMoving;
    private Vector3 openPositon;
    private Vector3 closePosition;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        door = GetComponentInChildren<Transform>();
        doorColliderHeight = gameObject.GetComponent<BoxCollider>().size.y;
        doorColliderWidth = gameObject.GetComponent<BoxCollider>().size.x;
        openPositon = door.position + new Vector3(0, openHeight, 0);
        closePosition = door.position;
    }

    private void BeOpened()
    {
        Debug.Log("start open");
        Vector3 up = door.position + new Vector3(0, openHeight, 0);
        //StartCoroutine(MoveCoroutine(up, true));
        //Debug.Log("before moving : " + isOpen);
        StartCoroutine(MoveDoor(openPositon));
        isOpen = true;
        Debug.Log("end open");
        //Debug.Log("after moving : " + isOpen);


    }

    private void BeClosed()
    {
        Debug.Log("start close");
        Vector3 down = door.position;// + new Vector3(0, -openHeight, 0);
        StartCoroutine(MoveDoor(closePosition));
        MoveDoor(down);
        isOpen = false;
        Debug.Log("end close");


    }

    IEnumerator MoveDoor(Vector3 end)
    {
        doorIsMoving = true;
        Debug.Log("start move");
        float elapsedTime = 0;
        Vector3 startingPos = door.position;
        while (elapsedTime < openTime)
        {
            door.position = Vector3.Lerp(startingPos, end, (elapsedTime / openTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        door.position = end;
        Debug.Log("stop move");
        doorIsMoving = false;
        yield return null;
    }



    public bool CanBeOpened()
    {
        return true;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
