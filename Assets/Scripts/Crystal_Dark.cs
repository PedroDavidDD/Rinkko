using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal_Dark : MonoBehaviour
{
    [SerializeField]
    private float puntosCrystal = 3f;

    // Referencia al objeto ControllerScore asignada en el editor de Unity
    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {
            controllerScore.ObtenerCrystal(puntosCrystal);
            Destroy(gameObject);
        }
    }
}
