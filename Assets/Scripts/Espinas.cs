using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    public int cantidadDaño = 10;
    public float ForceDamage = 3f;
    public PjController pjController;

    public float nextTime;
    public float cooldown = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && pjController != null)
        {
            pjController.TakeDamage(cantidadDaño);
            
            int direction = (collision.transform.position.x < this.gameObject.transform.position.x) ? -1 : 1;
           
            collision.transform.position = new Vector3(
                collision.transform.position.x + ForceDamage * direction,
                collision.transform.position.y + ForceDamage,
                collision.transform.position.z
                );
        }
    }
}
