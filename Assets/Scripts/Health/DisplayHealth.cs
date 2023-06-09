using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    private HealthComponent health;
    [SerializeField]
    public Text HealthText;

    public void SetDefault()
    {
        
        if (health != null && HealthText != null)
        {
            UpdateHealth(0);
        }
    }

    private void Start()
    {
        health = Player.GetComponent<HealthComponent>();
        SetDefault();
    }

    public void UpdateHealth(float damage)
    {
        HealthText.text = $"{health.CurrentHealth}";
    }

    public void UpdateDeath()
    {
        HealthText.text = $"dead";
    }
}
