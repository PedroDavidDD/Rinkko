using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;
    private Material material;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();  

    }

    // Update is called once per frame
    private void Update()
    {
        offset =  (playerRB.velocity.x * .1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
