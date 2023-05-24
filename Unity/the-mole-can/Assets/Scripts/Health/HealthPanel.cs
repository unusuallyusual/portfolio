using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;

    private HealthObj healthObj;
    private Image hpColor;
    private float currentHealth;
    private float maxHealth;

    private Color startColor;

    private void Awake()
    {
        healthObj = gameObj.GetComponent<HealthObj>();
        hpColor = GetComponent<Image>();
        startColor = hpColor.color;
    }
    private void Update()
    {
        currentHealth = healthObj.CurrentHealth;
        maxHealth = healthObj.MaxHealth;

        hpColor.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= maxHealth / 2)
            hpColor.color = Color.yellow;
        else
            hpColor.color = startColor;
    }
}
