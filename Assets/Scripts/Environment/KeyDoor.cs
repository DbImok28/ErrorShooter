using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Key;
    private bool userHasKey;
    
    public void CompareKeys(List<GameObject> playerKeys)
    {
        
        var matches = playerKeys.Find(item=>item.GetComponent<KeyForDoor>().ItemName==Key.GetComponent<KeyForDoor>().ItemName);
        if (matches)
        {
            userHasKey = true;
        }
        else
        {
        }
        
    }


    public float OpenHeight = 2;
    public float openTime = 3000;

    private bool isOpen;
    private float openRadius = 5;
    private float gesterezis = 0.9f;
    private Transform door;
    private bool doorIsMoving;
    private Vector3 openPositon;
    private Vector3 closePosition;
    private Vector3 doorBottom;
    void Start()
    {
        isOpen = false;
        door = GetComponentInChildren<Transform>();
        doorBottom = GetComponentInChildren<BoxCollider>().bounds.min;
        openPositon = door.position + new Vector3(0, OpenHeight, 0);
        closePosition = door.position;
    }


    IEnumerator MoveDoor(Vector3 end)
    {
        doorIsMoving = true;
        float elapsedTime = 0;
        Vector3 startingPos = door.position;
        while (elapsedTime < openTime)
        {
            door.position = Vector3.Lerp(startingPos, end, (elapsedTime / openTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        door.position = end;
        doorIsMoving = false;

        yield return null;
    }



    private void BeOpened()
    {
        StartCoroutine(MoveDoor(openPositon));
        isOpen = true;
    }

    private void BeClosed()
    {
        StartCoroutine(MoveDoor(closePosition));
        isOpen = false;
    }

    private void CheckIfOpen()
    {
        float checkDistance;
        checkDistance = (isOpen) ? openRadius / gesterezis : openRadius * gesterezis;

        var colliders = Physics.OverlapSphere(doorBottom, checkDistance);
        List<GameObject> context = new List<GameObject>();
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ICanOpenDoor>(out ICanOpenDoor canOpenDoor))
            {
                context.Add(collider.gameObject);
            }
        }
        if (context.Count > 0)
        {
            if (!isOpen && !doorIsMoving)
            {
                this.BeOpened();
            }
        }
        else
        {
            if (isOpen && !doorIsMoving)
            {
                this.BeClosed();
            }
        }

    }

    void Update()
    {
        CheckIfOpen();
    }


}
