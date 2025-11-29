using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public TMP_Text healthText;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthDisplay()
    {
        healthText.text = $"HP: {currentHealth}/{maxHealth}";
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    internal void TakeDamage(float v)
    {
        throw new NotImplementedException();
    }
}
