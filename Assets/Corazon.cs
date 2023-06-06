using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    [SerializeField]
    private int puntosCorazon = 1;

    public ControllerScore controllerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && controllerScore != null)
        {
            controllerScore.ObtenerCorazon(puntosCorazon);
            Destroy(gameObject);
        }
    }

}
