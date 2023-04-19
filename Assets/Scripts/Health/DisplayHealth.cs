using TMPro;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]
    public HealthComponent Health;
    [SerializeField]
    public TMP_Text HealthText;

    private void Start()
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
            Health.OnTakeDamage.AddListener(UpdateHealth);
            Health.OnDie.AddListener(OnDie);
            UpdateHealth(0);
        }
    }

    public void UpdateHealth(float damage)
    {
        HealthText.text = $"Damage: {damage} Health: {Health.CurrentHealth}";
    }

    private void OnDie()
    {
        HealthText.text = $"Is died";
    }
}
