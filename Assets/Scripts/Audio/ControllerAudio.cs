using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAudio : MonoBehaviour
{
    public static ControllerAudio Instance;
    private AudioSource audioSource;



    // Update is called once per frame
    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void ExecuteSound(AudioClip sound){
        
        audioSource.PlayOneShot(sound);
    }
}
