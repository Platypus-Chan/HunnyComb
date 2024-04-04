using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float CurrentHealth;

    [SerializeField]
    private float MaxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return CurrentHealth / MaxHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public void TakeDamage(float damageAmount)
    {
        if (CurrentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        CurrentHealth -= damageAmount;

        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }

        if (CurrentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (CurrentHealth == MaxHealth)
        {
            return;
        }

        CurrentHealth += amountToAdd;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}

