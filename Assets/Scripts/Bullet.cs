using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 1f;
	public Vector2 direction;

	public float livingTime = 2f;
	public Color explosionColor;

	private SpriteRenderer _renderer;
	private Color _initialColor;
	private float _startingTime;

	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	void Start()
    {
		// Save initial color
		_initialColor = _renderer.color;
		_startingTime = Time.time;
		
		// Destroy the bullet after some time
		Destroy(this.gameObject, livingTime);
	}

    // Update is called once per frame
    void Update()
    {
		// Move the object
		Vector2 movement = direction.normalized * speed * Time.deltaTime;
		transform.Translate(movement);

		// Change bullet's color over time
		float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(_initialColor, explosionColor, _percentageCompleted);
	}
}
