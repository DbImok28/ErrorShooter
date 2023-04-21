using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public HealthComponent playerHealthComponent;
    void Start()
    {
        playerHealthComponent.OnTakeDamage.AddListener(DisplayRedScreen);
    }

    private void DisplayRedScreen(float damage)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
