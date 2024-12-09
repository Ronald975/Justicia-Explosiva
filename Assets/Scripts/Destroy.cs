using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private AudioClip sonido1;
    [SerializeField] private AudioClip sonido2;
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            SonidoNivel1.Instance.PlaySound(sonido1);
            EnemyMov enemigo = collision.gameObject.GetComponent<EnemyMov>();
            AdministradorPuntaje.Instance.AgregarPuntos(enemigo.puntos);
            Destroy(collision.gameObject);
        }else if(collision.gameObject.CompareTag("Player")){
            SonidoNivel1.Instance.PlaySound(sonido2);
            Destroy(collision.gameObject);
        }
        
    }
}
