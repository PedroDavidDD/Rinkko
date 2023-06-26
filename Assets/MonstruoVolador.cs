
using UnityEngine;
using UnityEngine.UI;

public class MonstruoVolador : MonoBehaviour, ILifeSystem
{

    // Variables de salud y daño
    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth;

    [SerializeField] FloatingHealthBar floatingHealthBar;

    private void Awake()
    {
        floatingHealthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        floatingHealthBar.UpdateFloatingHealthBar(currentHealth, maxHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        floatingHealthBar.UpdateFloatingHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
