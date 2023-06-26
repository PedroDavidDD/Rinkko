using UnityEngine;

public class ResetDeletePlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject fade;
    private void Awake()
    {
        //fade = GameObject.FindGameObjectWithTag("Fade");
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && fade != null)
        {
            Debug.Log(fade);
            fade.SetActive(true);
        }
    }
}
