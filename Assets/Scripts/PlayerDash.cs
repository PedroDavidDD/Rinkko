using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash")]
    private Rigidbody2D rb;
    private bool CanMove = true;
    private bool canBeDash = true;
    public float speedDash = 20f;
    public float timeDash = .4f;
    private float gravityInicial;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        gravityInicial = rb.gravityScale;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canBeDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        CanMove = false;
        canBeDash = false;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(speedDash * transform.localScale.x, 0);

        yield return new WaitForSeconds(timeDash);

        CanMove = true;
        canBeDash = true;
        rb.gravityScale = gravityInicial;
    }
}
