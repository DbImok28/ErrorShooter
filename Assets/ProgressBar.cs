using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text text;
    public void SetText(float value)
    {
        Debug.Log("SetText");
        Debug.Log(value.ToString());
        text.text = value.ToString();
    }
}
