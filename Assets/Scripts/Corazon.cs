using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoRecoleccion;
    [SerializeField]
    private int puntosCorazon = 1;

    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {

            if (sonidoRecoleccion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);
            }

            controllerScore.ObtenerCorazon(puntosCorazon);
            Destroy(gameObject);
        }
    }

}
