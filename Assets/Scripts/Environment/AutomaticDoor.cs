using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform character;
    private bool isOpen;
    private float time;
    private float openRadius = 5;
    public float openHeight = 2;
    public float openTime = 3;
    private Transform door;
    private float doorColliderHeight;
    private float doorColliderWidth;
    void Start()
    {
        isOpen = false;
        door = GetComponentInChildren<Transform>();
        doorColliderHeight = gameObject.GetComponent<BoxCollider>().size.y;
        doorColliderWidth = gameObject.GetComponent<BoxCollider>().size.x;
    }

    private void Animate(Vector3  targetPosition) {
        door.position = Vector3.Lerp(transform.position, targetPosition, time);
        time += Time.deltaTime;
    }

    public void MoveDoor(Vector3 end)
    {
        float elapsedTime = 0;
        Vector3 startingPos =door.position;
        while (elapsedTime < openTime)
        {
            Debug.Log("moving door...");
            door.position = Vector3.Lerp(startingPos, end, (elapsedTime / openTime));
            elapsedTime += Time.deltaTime;
        }
        door.position = end;
        Debug.Log("stopped moving door...");
    }

    IEnumerator MoveCoroutine(Vector3 targetPosition, bool newDoorState)
    {
        Debug.Log("move coroutine : "+ isOpen);
        Debug.Log("start coroutine");
        Debug.Log("move coroutine : " + isOpen);
        Vector3 startPosition = door.position;
        for(float i=0; i<1; i += Time.deltaTime/openTime)
        {
            door.position = Vector3.Lerp(startPosition, targetPosition, i);

            yield return null;
        }

        door.position = targetPosition;
        isOpen = newDoorState;
        Debug.Log("move coroutine : " + isOpen);
        Debug.Log("end coroutine");
        Debug.Log("move coroutine : " + isOpen);
    }

    private void BeOpened()
    {
        Debug.Log("open");
        Vector3 up =door.position+ new Vector3(0, openHeight, 0);
        //StartCoroutine(MoveCoroutine(up, true));
        Debug.Log("be opened : " + isOpen);
        MoveDoor(up);
        isOpen = true;
        Debug.Log("be opened : " + isOpen);


    }

    private void BeClosed()
    {
        Debug.Log("close");
        Vector3 down = door.position + new Vector3(0, -openHeight, 0);
        //StartCoroutine(MoveCoroutine(down, false));
        MoveDoor(down);
        isOpen = false;
        
        
    }

    private void CheckIfOpen()
    {
        var colliders = Physics.OverlapSphere(transform.position, openRadius);
        List<GameObject> context = new List<GameObject>();
        foreach(var collider in colliders)
        {
            if(collider.TryGetComponent<ICanOpenDoor>(out ICanOpenDoor canOpenDoor))
            {
                context.Add(collider.gameObject);
            }
        }
        if (context.Count > 0)
        {
            //Debug.Log("context.Count > 0");
            if (!isOpen)
            {
                this.BeOpened();
            }
        }
        else
        {
            //Debug.Log("no icanioendoor");
            if (isOpen)
            {
                this.BeClosed();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfOpen();
    }
}
