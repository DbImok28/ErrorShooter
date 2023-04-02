using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public float ÑanReadNoteRadius;
    public float CanPickUpKeyRadius;
    public void PickUpKey()
    {

    }

    public void TryReadNote()
    {
        var colliders = Physics.OverlapSphere(transform.position, ÑanReadNoteRadius);
        List<GameObject> context = new List<GameObject>();
        //Debug.Log(colliders.Length);
        foreach (var collider in colliders)
        {
            //Debug.Log("smth nearby");
            //Debug.Log(collider.gameObject.name);
            if (collider.gameObject.TryGetComponent<Note>(out Note note))
            {
                Debug.Log("note nearby");
                note.DisplayOrHide();
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TryReadNote();
        if (Input.GetKeyDown(KeyCode.R))
        {
            TryReadNote();
        }
    }
}
