using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempInputTest : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveLoadManager.instance.SaveGame();
            Debug.Log("v");

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveLoadManager.instance.LoadGame();
            Debug.Log("o");
        }
    }
}
