using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, ILifeSystem
{
    // Variables de salud y daño
    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth;
    public static int defense;
    [SerializeField]
    [Header("Solo para el Player")]
    private GameObject fade;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
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
        if (this.gameObject.CompareTag("Player") && fade != null)
        {
            fade.SetActive(true);
        }
    }
}
