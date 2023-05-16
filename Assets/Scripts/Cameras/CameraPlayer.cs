
using UnityEngine;
using Cinemachine;

public class CameraPlayer : MonoBehaviour
{
    private CinemachineTargetGroup cinemachineTargetGroup;
    private GameObject jugador;

    private void Start(){
        cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        // transform del obj, peso, radio
        cinemachineTargetGroup.AddMember(jugador.transform, 1, 1);
    }

}
