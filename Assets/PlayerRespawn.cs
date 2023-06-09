using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> CheckPoints;

    public void RespawnToCheckPoint()
    {
        if (CheckPoints.Count > 0)
        {
            gameObject.transform.position = CheckPoints[^1].transform.position;
        }
        
    }
    void Start()
    {
        CheckPoints = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
