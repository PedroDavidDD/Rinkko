using System.Collections;
using UnityEngine;

public class SkillsSystem : MonoBehaviour
{
    [Header("Escudo")]
    public GameObject shieldPrefab;
    public float shieldDuration = 3f;
    public float shieldHeight = .5f;
    public float shieldWidth = .5f;
    public Transform shieldPositionObject;

    private bool isShieldActive = false;
    private bool shieldOnCooldown = false;
    private GameObject shieldInstance;

    void Update()
    {
        HandleShieldInput();
    }

    /// <summary>
    /// Detecta si el jugador presiona la tecla P
    /// y verifica si el escudo puede activarse.
    /// </summary>
    private void HandleShieldInput()
    {
        if (Input.GetKeyDown(KeyCode.P) && !shieldOnCooldown)
        {
            StartCoroutine(ShieldLifecycle());
        }
    }

    /// <summary>
    /// Controla todo el ciclo de vida del escudo:
    /// activar -> esperar duración -> destruir -> resetear estado.
    /// </summary>
    private IEnumerator ShieldLifecycle()
    {
        ActivateShieldState();
        SpawnShield();

        yield return WaitShieldDuration();

        DestroyShield();
        ResetShieldState();
    }

    /// <summary>
    /// Activa el estado del escudo y bloquea el input (cooldown).
    /// </summary>
    private void ActivateShieldState()
    {
        isShieldActive = true;
        shieldOnCooldown = true;
    }

    /// <summary>
    /// Instancia el escudo en la posición indicada
    /// y configura su tamaño.
    /// </summary>
    private void SpawnShield()
    {
        if (shieldPositionObject == null) return;

        Vector3 shieldPosition = shieldPositionObject.position;

        shieldInstance = Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);

        ConfigureShieldScale();
    }

    /// <summary>
    /// Ajusta la escala del escudo según los valores configurados.
    /// </summary>
    private void ConfigureShieldScale()
    {
        if (shieldInstance == null) return;

        shieldInstance.transform.localScale = new Vector3(shieldWidth, shieldHeight, 1f);
    }

    /// <summary>
    /// Espera el tiempo configurado de duración del escudo.
    /// </summary>
    private WaitForSeconds WaitShieldDuration()
    {
        return new WaitForSeconds(shieldDuration);
    }

    /// <summary>
    /// Destruye la instancia del escudo si existe.
    /// </summary>
    private void DestroyShield()
    {
        if (shieldInstance != null)
        {
            Destroy(shieldInstance);
        }
    }

    /// <summary>
    /// Restaura el estado para permitir volver a usar el escudo.
    /// </summary>
    private void ResetShieldState()
    {
        isShieldActive = false;
        shieldOnCooldown = false;
    }
}