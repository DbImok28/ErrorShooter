using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    // Start is called before the first frame update
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        HealthComponent healthComponent = other.gameObject.GetComponent<HealthComponent>();
        if (healthComponent)
        {
            healthComponent.TakeDamage(Damage);
            Debug.Log("Player is damaged");
        }
    }
}
