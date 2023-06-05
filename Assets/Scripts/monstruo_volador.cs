using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstruo_volador : MonoBehaviour
{
    public GameObject explosionEffect;
    public LineRenderer lineRenderer;
    public float velocidad = 3f;
    public Transform _firePoint;

    public float nextTime;
    public float cooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime > 0)
        {
            nextTime -= Time.deltaTime;
        }
        if (nextTime <= 0)
        {
            StartCoroutine(ShootWithRaycast());
            nextTime = cooldown;
        }
    }

    public IEnumerator ShootWithRaycast()
    {
        if (explosionEffect != null && lineRenderer != null)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right*-1);

            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Estoy atacando al jugador con mis balas predictivas");

                Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                Debug.Log("El jugador no fue alcanzado");

                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, _firePoint.position + _firePoint.right * 100);
            }

            lineRenderer.enabled = true;

            yield return null;

            lineRenderer.enabled = false;
        }
    }
}
