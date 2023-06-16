using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PjController : MonoBehaviour
{
    [Header("Mover")]
    private bool isWalking = false;
    public float moveSpeed = 1f;

    // Variables de salud y daño
    public HealthSystem healthSystem;

    // Variables de combate
    public int attackDamage = 10;
    public float attackRate = 1f;

    // Variables de animación
    private Animator animator;

    [Header("Detectar el suelo")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.025f;
    public bool isGrounded = false;

    [Header("Salto y Doble salto")]
    private Rigidbody2D rb;
    public float jumpForce = 3f;
    public bool isJumping = false;
    public float doubleJumpForce = 3f;
    public bool canDoubleJumping = false;

    private AudioSource audioSource;

    private RaycastHit2D hit;
    private Vector3 v3;

    [Header("Variables de audio")]
    [SerializeField]
    [Tooltip("Audio del primer salto")]
    private AudioClip jumpSound;
    [SerializeField]
    [Tooltip("Audio del segundo salto")]
    private AudioClip doubleJumpSound;
    [SerializeField]
    [Tooltip("Audio de correr")]
    private AudioClip runSound;
    [SerializeField]
    [Tooltip("Audio del ataque a cuerpo")]
    private AudioClip attackSound;


    private void Awake()
    {
        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
        if (!PlayerDash.isDash)
        {
            Move();
        }
    }

    private void Update()
    {
        Jump();
    }

    public void Move()
    {
        // Lógica de movimiento común para todos los personajes
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            int isLeft = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;

            transform.Translate(Vector3.right * moveSpeed * isLeft * Time.deltaTime);
            transform.localScale = new Vector3(isLeft, 1f, 1f);

            isWalking = true;
            ToggleAnimator("run", isWalking);
            ControllerAudio.Instance.IsSound(runSound);

        }
        else
        {
            isWalking = false;
            ToggleAnimator("run", isWalking);
            ControllerAudio.Instance.IsStopSound(runSound);
        }

        // Detectar si está en el piso o suelo: Is Grounded?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void ToggleAnimator(string nameAnimator, bool state)
    {
        animator.SetBool(nameAnimator, state);
    }

    public void TakeDamage(int damageAmount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(damageAmount);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !PlayerDash.isDash)
        {
            
            if (isGrounded && !isJumping)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJumping = true;

                //ToggleAnimator("jumFall", isJumping);

                // Desactivar sonido de caminar para saltar
                ControllerAudio.Instance.GetComponent<AudioSource>().clip = null;

                ControllerAudio.Instance.ExecuteSound(jumpSound);
            }
            else if (canDoubleJumping && !isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                canDoubleJumping = false;
                isJumping = false;

                //ToggleAnimator("jumFall", canDoubleJumping);
                ControllerAudio.Instance.ExecuteSound(doubleJumpSound);
            }
            animator.SetFloat("jumFall", 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
            canDoubleJumping = false;
            //ToggleAnimator("jumFall", isJumping);
            animator.SetFloat("jumFall", 1f);
            ControllerAudio.Instance.IsStopSound(jumpSound);
            ControllerAudio.Instance.IsStopSound(doubleJumpSound);
        }
    }
}
