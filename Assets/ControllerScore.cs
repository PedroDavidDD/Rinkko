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

    private float crystalTotal = 2f;

    [SerializeField]
    private Text corazonpoint;

    private float corazonTotal = 3f;

    [SerializeField]
    private Text scorepoint;
    private float scoreTotal;

    void Update()
    {
        moneypoint.text = moneyTotal.ToString();
        crystalpoint.text = crystalTotal.ToString();
        corazonpoint.text = corazonTotal.ToString();

        scoreTotal = moneyTotal + crystalTotal;
        scorepoint.text = scoreTotal.ToString();
    }

    public void ObtenerMoneda(float puntosDelObjeto)
    {
        moneyTotal += puntosDelObjeto;
    }
    public void ObtenerCrystal(float puntosDelObjeto)
    {
        crystalTotal += puntosDelObjeto;
    }
    public void ObtenerCorazon(float puntosDelObjeto)
    {
        corazonTotal += puntosDelObjeto;
    }

}
