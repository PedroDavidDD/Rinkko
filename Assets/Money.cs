using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField]
    private float puntosMoney = 2f;

    // Referencia al objeto ControllerScore asignada en el editor de Unity
    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {
            controllerScore.ObtenerMoneda(puntosMoney);
            Destroy(gameObject);
        }
    }

}

