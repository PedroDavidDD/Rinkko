using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjController : MonoBehaviour
{
    private float MeleeAttack;
    private float DistanceAttack;

    // Variables de movimiento
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Variables de salud y daño
    public int maxHealth = 100;
    public int currentHealth;
    private float defense;

    // Variables de combate
    public int attackDamage = 10;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    // Variables de control
    // private bool isGrounded = false;

    // Variables de animación
    private Animator animator;

    // Variables de sonido
    public AudioClip jumpSound;
    public AudioClip attackSound;
    private AudioSource audioSource;

    ///////////////////////////////////////////////////////////////

    public float AlturaSalto;
    public float Gravedad;
    private int Fase1;
    private int Fase2;
    public bool Saltando;
    public float Fallen;
    private float YPos;
    private float sky_;
    public int LimiteDeVelocidadPorCaida = -10;
    ////////////////////////DETECTOR DE PISO//////////////////////////


    private RaycastHit2D hit;
    public Vector3 v3;
    public float distance;
    public LayerMask layer;


    ///////////////////////////////////////////////////////////////



    private void Awake()
    {
        currentHealth = maxHealth;

        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDrawGizmos(){
        Gizmos.DrawRay(transform.position + v3, Vector3.up * -1 * distance);
    }
    private bool CheckCollision {
        get
        {
            hit = Physics2D.Raycast(transform.position + v3, Vector3.up * -1, distance, layer);
            return hit.collider != null;
        }
    }
    private void DetectorPlataforma(){
        if(CheckCollision)
        {
            animator.SetBool("sky", false);
            sky_ =0;
            if(!Saltando){
                Gravedad = 0;
                Fase1 = 0;
                Fase2 = 0;
            }
        }else{
            animator.SetBool("sky", true);
            if(!Saltando){
                switch(Fase2){
                    case 0: 
                        Gravedad = 0;
                        Fase2 = 1;
                        break;
                    case 1:
                        if(Gravedad > LimiteDeVelocidadPorCaida){
                            Gravedad -= AlturaSalto / Fallen * Time.deltaTime;
                        }
                        break;
                }
            }
        }

        if(transform.position.y > YPos){
            animator.SetFloat("gravedad", 1);
        }
        if(transform.position.y < YPos){
            animator.SetFloat("gravedad", 0);
            switch(sky_){
                case 0: 
                    animator.Play("Base Layer.Sky", 0, 0);
                    sky_++;
                    break;
            }
        }
        YPos = transform.position.y;
    }

    private void Start()
    {
        currentHealth = maxHealth;

        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }  

    void Update()
    {
        DetectorPlataforma();
        transform.Translate(Vector3.up * Gravedad * Time.deltaTime);
    }

    public void Move()
    {
        // Lógica de movimiento común para todos los personajes
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("run", true);
        }else{
            animator.SetBool("run", false);
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("run", true);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Lógica adicional cuando el personaje recibe daño
        // ...
        if (currentHealth <= 0)
        {
            Die();
        }
    }  

    private void Jump()
    {
        // Lógica de saltar del personaje
        if(Input.GetKey(KeyCode.X)){
            switch(Fase1){
                case 0: 
                    if (CheckCollision){
                        Gravedad = AlturaSalto;
                        Fase1 = 1;
                        Saltando = true;
                    }
                    break;
                case 1:
                    if (Gravedad > 0){
                        Gravedad -= jumpForce * Time.deltaTime;
                    }else{
                        Fase1 = 2;
                    }
                    Saltando = true;
                    break;
                case 2:
                    Saltando = false;
                    break;
            }
        }else{
            Saltando = false;
        }

    }

    private void Die()
    {
        // Lógica de muerte del personaje
        // ...
        Debug.Log("Muerto");
    }

    private void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
        }
    }

    // private void PlayJumpSound()
    // {
    //     audioSource.PlayOneShot(jumpSound);
    // }

    // private void PlayAttackSound()
    // {
    //     audioSource.PlayOneShot(attackSound);
    // }

    // // Detectar si el personaje está en el suelo
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = true;
    //     }
    // }

    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = false;
    //     }
    // }

}
