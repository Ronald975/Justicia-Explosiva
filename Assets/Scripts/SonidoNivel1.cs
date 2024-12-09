using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoNivel1 : MonoBehaviour
{
    public static SonidoNivel1 Instance;
    private AudioSource audioSource;

    private void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
