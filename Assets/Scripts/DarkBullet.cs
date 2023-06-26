using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    [Header("Variables de ataque")]
    [Tooltip("cantidad de daño")]
    public int damageAmount = 20;

    void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ILifeSystem iLifeSystem = other.gameObject.GetComponent<ILifeSystem>();
            if (iLifeSystem != null)
            {
                iLifeSystem.TakeDamage(damageAmount);
            }
        }
    }
}
