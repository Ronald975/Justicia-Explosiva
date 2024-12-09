using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual = 100;
    public float vidaMaxima = 100;
    [SerializeField] private AudioClip sonido;
    void Update()
    {
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        if(vidaActual <= 0){
            SonidoNivel1.Instance.PlaySound(sonido);
            gameObject.SetActive(false);
        }
    }          
}
