using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Movement movement;
    public BombController controller;
    public float incremento = 2f;
    [SerializeField] private AudioClip sonido;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Velocidad")){
            SonidoNivel1.Instance.PlaySound(sonido);
            movement.moveSpeed += incremento;
            Destroy(other.gameObject);
        }else if(other.CompareTag("Explosion")){
            SonidoNivel1.Instance.PlaySound(sonido);
            Explosion.num += 1; 
            Destroy(other.gameObject);
        }else if(other.CompareTag("Bombas")){
            SonidoNivel1.Instance.PlaySound(sonido);
            controller.bombAmount += 1; 
            controller.bombsRemaining += 1;
            Destroy(other.gameObject);
        }
    }
    

}

