using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, ISaveable
{
    [Header("Parameters")]
    public float CurrentHealth = 10.0f;
    public float MaxHealth = 10.0f;
    public bool IsDead { get; private set; } = false;

    [Header("Events")]
    public UnityEvent<HealthComponent,float> OnTakeDamage;
    public UnityEvent OnDie;
    public UnityEvent OnRespawn;

    public void TakeDamage(float damage)
    {
        if (IsDead) return;
        
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0.0f, MaxHealth);
        OnTakeDamage.Invoke(this,damage);
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
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        OnDie.Invoke();
    }

    public void Respawn()
    {
        IsDead = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        OnRespawn.Invoke();
    }

    public void SetDefault()
    {
        CurrentHealth = 10.0f;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.playerHealth=CurrentHealth;
    }

    public void LoadData(GameData gameData)
    {
        CurrentHealth=gameData.playerHealth;
    }
}
