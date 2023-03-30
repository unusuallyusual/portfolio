using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HealthObj : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float CurrentHealth;
    public float MaxHealth => maxHealth;

    public void ChangeCurrentHealth(float currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}
