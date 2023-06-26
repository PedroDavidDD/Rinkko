using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        FadeOut();
        Invoke(nameof(FadeIn), 2f);
    }
    void Update()
    {
    }
    void FadeOut()
    {
        // ocultar PJ
        animator.Play("Fade");
    }
    void FadeIn()
    {
        // aparecer PJ
        animator.Play("FadeIn");
        Invoke("ResetGame", 1f);
    }
    public void ResetGame()
    {
        // Obtener el nobmre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

    }
}
