using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash")]
    private Rigidbody2D rb;

    public float speedDash = 2f;
    public float timeDash = .4f;
    private float gravityInicial;
    private Animator animator;

    [SerializeField] [Tooltip("Audio de dash")]
    private AudioClip dashSound;

    [SerializeField]
    private float nextDashTime;
    [SerializeField]
    private float cooldownDashTime = 1f;

    public static bool isDash = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        gravityInicial = rb.gravityScale;
    }
    private void Update()
    {
        if (nextDashTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isDash)
            {
                StartCoroutine(Dash());
                animator.SetTrigger("dash");
                ControllerAudio.Instance.ExecuteSound(dashSound);
                nextDashTime = cooldownDashTime ;
            }
        }
        else
        {
            nextDashTime -= Time.deltaTime;
        }
    }

    private IEnumerator Dash()
    {
        isDash = true;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(speedDash * transform.localScale.x, 0);

        yield return new WaitForSeconds(timeDash);

        isDash = false;
        rb.gravityScale = gravityInicial;
    }
}
