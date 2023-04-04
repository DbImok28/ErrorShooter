using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform character;
    private bool isOpen;
    private float openRadius = 5;
    public float openHeight = 2;
    private float gesterezis=0.9f;
    public float openTime = 3000;
    private Transform door;
    private float doorColliderHeight;
    private float doorColliderWidth;
    private bool doorIsMoving;
    private Vector3 openPositon;
    private Vector3 closePosition;
    private Vector3 doorBottom;
    void Start()
    {
        isOpen = false;
        door = GetComponentInChildren<Transform>();
        doorBottom = GetComponentInChildren< BoxCollider>().bounds.min;
        //doorColliderHeight = gameObject.GetComponent<BoxCollider>().size.y;
        //doorColliderWidth = gameObject.GetComponent<BoxCollider>().size.x;
        openPositon = door.position + new Vector3(0, openHeight, 0);
        closePosition= door.position ;

    }


    IEnumerator MoveDoor(Vector3 end)
    {
        doorIsMoving = true;
        Debug.Log("start move");
        float elapsedTime = 0;
        Vector3 startingPos =door.position;
        //Debug.Log(startingPos+" "+end);
        while (elapsedTime < openTime)
        {
            //Debug.Log(elapsedTime);
            door.position = Vector3.Lerp(startingPos, end, (elapsedTime / openTime));
            //Debug.Log(door.position);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        door.position = end;
        Debug.Log("end move");
        doorIsMoving = false;
        yield return null;
    }

    

    private void BeOpened()
    {
        Debug.Log("start open");
        Vector3 up =door.position+ new Vector3(0, openHeight, 0);
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

    private void CheckIfOpen()
    {
        float checkDistance;
        checkDistance = (isOpen) ? openRadius / gesterezis : openRadius * gesterezis;
        Debug.Log(checkDistance);
        
        var colliders = Physics.OverlapSphere(doorBottom, checkDistance);
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
            if (!isOpen && !doorIsMoving)
            {
                this.BeOpened();
            }
        }
        else
        {
            //Debug.Log("no icanioendoor");
            if (isOpen && !doorIsMoving)
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
