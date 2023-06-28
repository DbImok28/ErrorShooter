using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWidget : MonoBehaviour
{
    public ProgressBar ProgressBar;

    private HealthComponent playerHealth;

    public void HandlePlayerDamaged(HealthComponent healthInfo, float damage)
    {
        Debug.Log("handle player damaged from health widget");
        ProgressBar.SetText(healthInfo.CurrentHealth);
    }

    private void OnEnable()
    {
        playerHealth = FindPlayerDamagable();
        playerHealth.OnTakeDamage.AddListener(HandlePlayerDamaged);
    }

    private void OnDisable()
    {
        playerHealth.OnTakeDamage.RemoveListener(HandlePlayerDamaged);
    }

    public HealthComponent FindPlayerDamagable()
    {
        //Нужен глобальный метод для однозначного поиска игрока
        PlayerController player = Object.FindObjectsOfType<PlayerController>()[0];
        return player.gameObject.GetComponent<HealthComponent>();


    }
}
