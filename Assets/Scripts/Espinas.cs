using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    public int cantidadDaño = 10;
    public float fuerzaEmpuje  = 2f;
    public PjController pjController;

    public float nextTime;
    public float cooldown = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && pjController != null)
        {
            pjController.TakeDamage(cantidadDaño);

            Vector2 direccionEmpuje = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode2D.Impulse);
            
        }
    }
}
