
using UnityEngine;

public class PjSwordRun : MonoBehaviour
{   
    private Rigidbody2D rb;
    private float velocidad = 1f;
    private float fuerzaSalto = 5f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float ejeH = Input.GetAxis("Horizontal");
        float ejeV = Input.GetAxis("Vertical");

        // rb.AddForce(new Vector3(ejeH * velocidad, ejeV * velocidad, 0f));
        transform.Translate(ejeH * velocidad * Time.deltaTime, ejeV * velocidad * Time.deltaTime, 0f);

        if (Input.GetKeyDown(KeyCode.Space)) Saltar();

    }

    private void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}
