using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public float puntos = 500;
    public float moveSpeed = 2f;
    private Vector3 direction;
    private bool movingVertically = true;

    private void Start()
    {
        // Comienza moviéndose verticalmente (de arriba hacia abajo)
        direction = Vector3.up; // Puede ser Vector3.down si quieres que empiece moviéndose hacia abajo
    }

    private void Update()
    {
        // Mueve al enemigo en la dirección actual
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Corner"))
        {
            // Cambia la dirección cuando se toca una esquina
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        // Alterna entre movimiento vertical y horizontal
        if (movingVertically)
        {
            direction = Vector3.right; // Cambia a movimiento horizontal
        }
        else
        {
            direction = Vector3.up; // Cambia a movimiento vertical
        }
        movingVertically = !movingVertically; // Alterna el estado
    }
    
    
}
