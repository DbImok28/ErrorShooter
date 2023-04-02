using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform character;
    private bool isOpen;
    private float time;
    public float openRadius = 1;
    public float openHeight = 2;
    public float openTime = 1;
    private Transform door;
    void Start()
    {
        isOpen = false;
        door = GetComponentInChildren<Transform>();
    }

    private void Animate(Vector3  targetPosition) {
        door.position = Vector3.Lerp(transform.position, targetPosition, time);
        time += Time.deltaTime;
    }

    IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        Vector3 startPosition = door.position;
        for(float i=0; i<1; i += Time.deltaTime/openTime)
        {
            door.position = Vector3.Lerp(startPosition, targetPosition, i);

            yield return null;
        }

        door.position = targetPosition;
    }

    private void BeOpened()
    {
        Debug.Log("open");
        Vector3 up =door.position+ new Vector3(0, openHeight, 0);
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
