using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [Header("Parameters")]
    public float CurrentHealth = 10.0f;
    public float MaxHealth = 10.0f;
    public bool IsDead { get; private set; } = false;

    [Header("Events")]
    public UnityEvent<float> OnTakeDamage;
    public UnityEvent OnDie;

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0.0f, MaxHealth);
        OnTakeDamage.Invoke(damage);
        if (CurrentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void Heal(float recovery)
    {
        if (IsDead) return;
        CurrentHealth = Mathf.Clamp(CurrentHealth + recovery, 0.0f, MaxHealth);
    }

    public void Die()
    {
        IsDead = true;
        OnDie.Invoke();
    }
}
