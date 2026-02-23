using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal_Dark : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoRecoleccion;
    [SerializeField]
    private int puntosCrystal = 3;

    // Referencia al objeto ControllerScore asignada en el editor de Unity
    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {

            if (sonidoRecoleccion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);
            }

            controllerScore.ObtenerCrystal(puntosCrystal);
            Destroy(gameObject);
        }
    }
}
