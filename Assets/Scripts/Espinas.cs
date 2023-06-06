using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    public int cantidadDaño = 10;
    public float efectoDelDaño = .5f;
    public PjController pjController;

    public float nextTime;
    public float cooldown = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && pjController != null)
        {
            pjController.TakeDamage(cantidadDaño);
            collision.transform.position = new Vector3(collision.transform.position.x- efectoDelDaño, collision.transform.position.y + efectoDelDaño, collision.transform.position.z);
        }
    }
}
