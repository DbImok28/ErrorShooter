using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour
{
    private bool isOpen;
    private bool isMoving;

    private float gesterezis = 0.9f;

    public float DoorMoveTime = 3;
    public float OpenRadius = 5;

    protected Vector3 DoorBottom;
    

    private Animator animator;

    
    protected virtual void Start()
    {
        isOpen = false;
        DoorBottom = GetComponentInChildren<BoxCollider>().bounds.min;
        animator = GetComponent<Animator>();
        
    }

    public void BeOpened()
    {
        if (CanBeOpened())
        {
            animator.SetBool("CanBeOpened", true);
            isOpen = true;
        }
        
    }

    public void BeClosed()
    {
        if (CanBeClosed())
        {
            animator.SetBool("CanBeOpened", false);
            isOpen = false;
        }
    }

    public bool PlayerIsNear()
    {
        float checkDistance;
        checkDistance = (isOpen) ? OpenRadius / gesterezis : OpenRadius * gesterezis;
        var colliders = Physics.OverlapSphere(DoorBottom, checkDistance);
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
            return true;
        }

        return false;
    }

    public abstract bool CanBeOpened();
    public abstract bool CanBeClosed();
    public virtual void CheckIfOpen()
    {
        if (CanBeOpened())
        {
            if (!isOpen && !isMoving)
            {
                this.BeOpened();
            }
        }
        else
        {
            if (isOpen && !isMoving)
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
