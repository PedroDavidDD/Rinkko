using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject explosionEffect;  // Referencia al efecto de explosión
    public LineRenderer lineRenderer;   // Referencia al LineRenderer
    public Transform firePoint;         // Punto de origen de los disparos
    public float cooldown = 1f;         // Tiempo de enfriamiento entre disparos
    public float detectionRadius = 10f;  // Radio de detección del jugador
    private float nextTime;             // Tiempo para el siguiente disparo

    public static bool isAttacking;
    private SpriteRenderer spriteRenderer;

    public Sprite[] spriteAttacking;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // Comprueba si se puede realizar un nuevo disparo
        if (nextTime <= 0)
        {
            StartCoroutine(ShootWithRaycast());  // Realiza el disparo
            nextTime = cooldown;                  // Reinicia el tiempo de enfriamiento           
        }
        else
        {
            nextTime -= Time.deltaTime;  // Reduce el tiempo de enfriamiento
        }
    }

    private IEnumerator ShootWithRaycast()
    {
        // Comprueba si las referencias necesarias existen
        if (explosionEffect == null || lineRenderer == null)
        {
            yield break;  // Sale del método si alguna referencia es nula
        }

        // Obtiene los colliders dentro del radio de detección
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        // Itera a través de los colliders encontrados
        foreach (Collider2D collider in colliders)
        {
            // Comprueba si el collider es del tag "Player"
            if (collider.CompareTag("Player"))
            {
                isAttacking = true;
                spriteRenderer.sprite = spriteAttacking[1];

                // Calcula la dirección hacia el jugador
                Vector2 direction = (collider.transform.position - firePoint.position).normalized;
                Debug.Log(collider.transform.position);
                Debug.Log(firePoint.position);
                Debug.Log(collider.transform.position - firePoint.position);
                Debug.Log(direction);
                // Realiza un raycast en la dirección calculada
                RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction);

                // Comprueba si el raycast golpeó al jugador
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    HandleSuccessfulAttack(hit);  // Maneja el ataque exitoso
                    yield break;                   // Sale del método
                }
                else
                {
                    Girar(collider);
                    yield break;                   // Sale del método
                }
            }
            else
            {
                isAttacking = false;
                spriteRenderer.sprite = spriteAttacking[0];
            }
        }

        HandleMissedAttack();  // Maneja el ataque fallido
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja un círculo amarillo que representa el radio de detección
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void HandleSuccessfulAttack(RaycastHit2D hit)
    {
        Debug.Log("<color=green>Ataque exitoso</color>");
        Instantiate(explosionEffect, hit.point, Quaternion.identity);
        lineRenderer.SetPositions(new Vector3[] { firePoint.position, hit.point });
        lineRenderer.enabled = true;
        StartCoroutine(DisableLineRenderer());
    }

    private void HandleMissedAttack()
    {
        Debug.Log("<color=red>El jugador no fue alcanzado</color>");
        lineRenderer.SetPositions(new Vector3[] { firePoint.position, firePoint.position + firePoint.right * 100 });
        lineRenderer.enabled = true;
        StartCoroutine(DisableLineRenderer());
    }

    private IEnumerator DisableLineRenderer()
    {
        yield return null;
        lineRenderer.enabled = false;
    }
    private void Girar(Collider2D collider)
    {
        if (firePoint.position.x > collider.transform.position.x)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        Debug.Log("giro");

    }
}
