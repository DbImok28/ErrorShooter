using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    //Скрипт надо вешать на саму модель обьекта, а не на ее пустого родителя, иначе не работает подсветка.

    private bool highlighted;

    private Transform transform;

    public string Tooltip;
    private Text tooltipUI;

    public Color OutlineColor;
    public float OutlineWidth;

    public void DisplayText()
    {
        //tooltipUI.text = Tooltip;
    }

    public void HideText()
    {
        //tooltipUI.text = "";
    }

    public void Highlight()
    {
        transform.gameObject.AddComponent<Outline>();
        transform.gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
        transform.gameObject.GetComponent<Outline>().OutlineColor = OutlineColor != null ? OutlineColor : Color.blue;
        transform.gameObject.GetComponent<Outline>().OutlineWidth = OutlineWidth != null ? OutlineWidth : 10;
        DisplayText();
    }

    public void Dehighlight()
    {
        highlighted = false;
        Destroy(gameObject.GetComponent<Outline>());
        HideText();
    }

    void Start()
    {
        //tooltipUI = GameObject.Find("ItemInfo").GetComponent<Text>();
        transform = GetComponentInChildren<Transform>().GetComponentInChildren<Transform>();

    }

}
