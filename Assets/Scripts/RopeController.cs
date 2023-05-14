using UnityEngine;

public class RopeController : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float ropeLength = 10f; // Longitud de la cuerda
    public float ropeSpeed = 5f; // Velocidad de lanzamiento de la cuerda
    public LineRenderer lineRenderer; // Componente LineRenderer para visualizar la cuerda

    private bool isSwinging = false; // Indica si el jugador está balanceándose
    private Vector3 targetPosition; // Posición objetivo de la cuerda

    void Start()
    {
        // Inicializar la cuerda visual
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Lanzar la cuerda al hacer clic con el botón izquierdo del mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
            isSwinging = true;
        }

        if (isSwinging)
        {
            // Mover al jugador hacia la posición objetivo de la cuerda
            player.position = Vector3.MoveTowards(player.position, targetPosition, ropeSpeed * Time.deltaTime);

            // Actualizar la cuerda visual utilizando el LineRenderer
            lineRenderer.SetPosition(0, player.position);
            lineRenderer.SetPosition(1, targetPosition);

            // Comprobar si el jugador ha alcanzado la posición objetivo
            if (player.position == targetPosition)
            {
                isSwinging = false;
            }
        }
    }
}
