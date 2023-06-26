using UnityEngine;

public class SkillsSystem : MonoBehaviour
{
    public GameObject shieldPrefab; // Prefab del escudo
    public float shieldDuration = 3f; // Duración del escudo en segundos
    public float shieldHeight = .5f; // Altura del escudo
    public float shieldWidth = .5f; // Ancho del escudo
    public Transform shieldPositionObject; // Objeto que proporciona la posición del escudo

    private bool isShieldActive = false; // Estado del escudo
    private GameObject shieldInstance; // Instancia del escudo

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla "p" y el escudo no está activo, se crea el escudo
        if (Input.GetKeyDown(KeyCode.P) && !isShieldActive)
        {
            CreateShield();
            isShieldActive = false;
        }
    }

    void CreateShield()
    {
        // Activar el escudo
        isShieldActive = true;

        // Verificar si se ha asignado un objeto para la posición del escudo
        if (shieldPositionObject != null)
        {
            // Obtener la posición del escudo a partir del objeto asignado
            Vector3 shieldPosition = shieldPositionObject.position;

            // Crear la instancia del escudo en la posición y rotación proporcionadas
            shieldInstance = Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);
        }

        // Establecer el tamaño del escudo
        shieldInstance.transform.localScale = new Vector3(shieldWidth, shieldHeight, 1f);

        // Establecer la duración del escudo
        Destroy(shieldInstance, shieldDuration);
    }
}
