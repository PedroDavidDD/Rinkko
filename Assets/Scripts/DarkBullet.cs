using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 3f);
    }
}
