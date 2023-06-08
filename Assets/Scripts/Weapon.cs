using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject shooter;

	private Transform _firePoint;

	void Awake()
	{
		// Añada al hijo "FirePoint"
		_firePoint = transform.Find("FirePoint");
	}

	void Start()
    {
		Invoke("Shoot", 1);
		Invoke("Shoot", 2);
		Invoke("Shoot", 3);
	}
	void Update(){
		ShooterWithKeyCode();
	}

	void ShooterWithKeyCode(){
		if (Input.GetKeyDown(KeyCode.G)) {
			Shoot();
		}
	}

	void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				// Left
				bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
			} else {
				//Right
				bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
			}
		}
	}
}
