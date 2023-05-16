using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAddedElements : MonoBehaviour
{
    private CinemachineTargetGroup cinemachineTargetGroup;
    private GameObject jugador;
    private GameObject[] enemigos;

    private void Start(){
        cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        // transform del obj, peso, radio
        cinemachineTargetGroup.AddMember(jugador.transform, 1, 1);

        enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemigos){
            cinemachineTargetGroup.AddMember(enemy.transform, 1, 1);
        }
    }
}
