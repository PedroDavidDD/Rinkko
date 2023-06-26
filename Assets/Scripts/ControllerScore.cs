using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScore : MonoBehaviour
{
    [SerializeField]
    private Text moneypoint;

    private float moneyTotal = 1f;
    [SerializeField]
    private Text crystalpoint;

    private int crystalTotal = 2;

    [SerializeField]
    private Text corazonpoint;

    [SerializeField]
    private Text scorepoint;
    private float scoreTotal;

    public HealthSystem healthSystem;

    void Start()
    {
        healthSystem.SetMaxHealth(100);
    }

    void Update()
    {
        moneypoint.text = moneyTotal.ToString();
        crystalpoint.text = crystalTotal.ToString();
        corazonpoint.text = healthSystem.GetCurrentHealth().ToString();

        scoreTotal = moneyTotal + crystalTotal;
        scorepoint.text = scoreTotal.ToString();
    }

    public void ObtenerMoneda(float puntosDelObjeto)
    {
        moneyTotal += puntosDelObjeto;
    }
    public void ObtenerCrystal(int puntosDelObjeto)
    {
        crystalTotal += puntosDelObjeto;
    }
    public void ObtenerCorazon(int puntosDelObjeto)
    {
        if (healthSystem.GetCurrentHealth() < healthSystem.GetMaxHealth())
        {
            healthSystem.SetAumentarVida(puntosDelObjeto);
        }
    }

}
