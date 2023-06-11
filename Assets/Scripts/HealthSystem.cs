using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    // Variables de salud y daño
    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth;
    public static int defense;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public void SetAumentarVida(int aumentarPuntosDeVida)
    {
        this.currentHealth += aumentarPuntosDeVida;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Personaje ha muerto");
        // Obtener el nobmre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
