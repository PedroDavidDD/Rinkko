using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PjController : MonoBehaviour
{
    // Variables de movimiento
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
    [Header("Dash")]
    private bool CanMove = true;
    private bool canBeDash = true;
    /*
    public float speedDash = 20f;
    public float timeDash = .4f;
    private float gravityInicial;
    */


    private void Awake()
    {
        // Obtener referencias a los componentes necesarios
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        // gravityInicial = rb.gravityScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Update()
    {
        Jump();
       /* if (Input.GetKeyDown(KeyCode.F) && canBeDash)
        {
            StartCoroutine(Dash());
        }*/
    }

    public void Move()
    {
        // Lógica de movimiento común para todos los personajes
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {

            int isLeft = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;

            transform.Translate(Vector3.right * moveSpeed * isLeft * Time.deltaTime);
            transform.localScale = new Vector3(isLeft, 1f, 1f);

            ToggleAnimator("run", true);
        }
        else
        {
            ToggleAnimator("run", false);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded && !isJumping)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJumping = true;
            }
            else if (canDoubleJumping && !isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                canDoubleJumping = false;
                isJumping = false;
            }
        }
    }
    /*
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
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
            canDoubleJumping = false;
        }
    }
}
