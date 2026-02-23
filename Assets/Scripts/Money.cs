using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoRecoleccion;
    [SerializeField]
    private float puntosMoney = 2f;

    // Referencia al objeto ControllerScore asignada en el editor de Unity
    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {

            if (sonidoRecoleccion != null)
            {
                // ControllerAudio.Instance.ExecuteSound(sonidoRecoleccion);
                AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);
                // Esto no, porque crea objeto y se guarda en memoria, Garbage Collection, genera mucha basura en memoria.
            }

            controllerScore.ObtenerMoneda(puntosMoney);
            Destroy(gameObject);
        }
    }

}

