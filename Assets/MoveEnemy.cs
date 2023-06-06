using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private float velocidadDeMovimiento = 2f;
    [SerializeField]
    // [Header:"Minima distancia para que se mueva al punto"]
    private float minDistancia;
    [SerializeField]
    private Transform[] puntosDeMovimiento;
    [SerializeField]
    private int siguientePunto = 0;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public static bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {      
        if (isMoving && Attacking.isAttacking == false)
        {
            // Para que el objeto se mueva a la nueva posición
            transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimiento[siguientePunto].position, velocidadDeMovimiento * Time.deltaTime);

            /* 
             * Para ir al siguiente punto: distancia entre dos objetos
             * Si el Mounstro llega al primer punto, siga el siguiente
            */
            if (Vector2.Distance(transform.position, puntosDeMovimiento[siguientePunto].position) < minDistancia)
            {

                siguientePunto += 1;

                if (siguientePunto >= puntosDeMovimiento.Length)
                {
                    siguientePunto = 0;
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                }
            }

            // Girar a esa dirección
            Girar();
        }

    }

    private void Girar()
    {
        if (transform.position.x < puntosDeMovimiento[siguientePunto].position.x)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }

        if (transform.position.y < puntosDeMovimiento[siguientePunto].position.y)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 10f);
        }

        if (transform.position.y > puntosDeMovimiento[siguientePunto].position.y)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -10f);
        }
    }
}
