using TMPro;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]
    public HealthComponent Health;
    [SerializeField]
    public TMP_Text HealthText;

    public void SetDefault()
    {
        if (Health == null)
        {
            Health = GetComponent<HealthComponent>();
        }
        if (HealthText == null)
        {
            HealthText = gameObject.GetComponentInChildren<TMP_Text>();
        }
        if (Health != null && HealthText != null)
        {
            //Health.OnTakeDamage.AddListener(UpdateHealth);
            //Health.OnDie.AddListener(UpdateDeath);
            UpdateHealth(0);
        }
    }

    private void Start()
    {
        SetDefault();
    }

    public void UpdateHealth(float damage)
    {
        HealthText.text = $"Damage: {damage} Health: {Health.CurrentHealth}";
    }

    public void UpdateDeath()
    {
        HealthText.text = $"Is died";
    }
}
