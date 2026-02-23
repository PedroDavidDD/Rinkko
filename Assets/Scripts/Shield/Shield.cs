using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string[] repelTags; // Etiquetas de los objetos a repeler/destruir
    public float fuerzaEmpuje = 2f;

    [Header("Variables de ataque")]
    [Tooltip("cantidad de daño")]
    public int damageAmount = 20;

    [Header("Variables de sonido")]
    [SerializeField] private AudioClip sonidoEscudo;
    private AudioSource audioSource;

    private void Start()
    {
        // 1. Intentamos obtener el componente
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 2. Configuramos y reproducimos
        if (sonidoEscudo != null)
        {
            audioSource.clip = sonidoEscudo;
            audioSource.loop = true; // Hace que el sonido nunca termine
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioClip de 'Sonido Escudo' en el Inspector.");
        }
    }

    private void OnDisable()
    {
        // OnDisable se ejecuta justo cuando el objeto se destruye o se desactiva.
        // Aquí cortamos el sonido inmediatamente.
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto es un enemigo y hay etiquetas para repeler
        if (other.gameObject.CompareTag("Enemy") && repelTags.Length != 0)
        {
            // Calcular la dirección de empuje hacia atrás
            Vector2 direccionEmpuje = (other.transform.position - transform.position).normalized;

            // Aplicar una fuerza de impulso al objeto enemigo en la dirección opuesta al escudo
            Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //rb.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode2D.Impulse);
                Debug.Log("Bajo vida al enemigo con escudo");
                ILifeSystem iLifeSystem = other.gameObject.GetComponent<ILifeSystem>();
                if (iLifeSystem != null)
                {
                    iLifeSystem.TakeDamage(damageAmount);
                }

            }
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            // Verificar si el objeto es una bala y si su etiqueta está en el array de etiquetas a repeler
            if (ArrayContains(repelTags, other.gameObject.tag))
            {
                // Destruir la bala
                Destroy(other.gameObject);
            }
        }
    }

    bool ArrayContains(string[] array, string value)
    {
        // Verificar si el valor está presente en el array
        foreach (string element in array)
        {
            if (element == value)
                return true;
        }
        return false;
    }

}
