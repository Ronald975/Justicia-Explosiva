using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefabCenter;
    public GameObject explosionPrefabCilindro;
    public float delay = 3f; // Retraso antes de explotar
    public float explosionDuration = 1f; // Duración de la explosión
    private bool hasExploded = false;
    [SerializeField] private AudioClip sonido;
    public static int num = 1;
    // Poner el static int después de las pruebas

    void Update()
    {
        // Inicia el temporizador de la explosión
        Invoke("Explode", delay);
    }
    
    void Explode()
    {
        SonidoNivel1.Instance.PlaySound(sonido);
        if (hasExploded) return;

        hasExploded = true;

        // Posición de la bomba
        Vector3 bombPosition = transform.position;
        
        // Destruir la bomba
        Destroy(gameObject);

        // Rotaciones para las explosiones en horizontal y vertical
        Quaternion rotacionVertical = Quaternion.Euler(90,0,0);
        Quaternion rotacionHorizontal = Quaternion.Euler(0,0,90);

        // Instanciar explosión en el centro y destruirla después de explosionDuration segundos
        Destroy(Instantiate(explosionPrefabCenter, bombPosition , Quaternion.identity), explosionDuration);

        // Instanciar explosiones hacia arriba, abajo, izquierda y derecha. 
        GameObject arriba = Instantiate(explosionPrefabCilindro, bombPosition, rotacionVertical);
        GameObject abajo = Instantiate(explosionPrefabCilindro, bombPosition, rotacionVertical);
        GameObject izquierda = Instantiate(explosionPrefabCilindro, bombPosition, rotacionHorizontal);
        GameObject derecha = Instantiate(explosionPrefabCilindro, bombPosition, rotacionHorizontal);

        Ray lineaArriba = new Ray(bombPosition, Vector3.forward);
        Ray lineaAbajo = new Ray(bombPosition, Vector3.back);
        Ray lineaIzquierda = new Ray(bombPosition, Vector3.left);
        Ray lineaDerecha = new Ray(bombPosition, Vector3.right);

        if(Physics.Raycast(lineaArriba, out RaycastHit hitArriba, 2*num-1)){
            Renderer renderer = hitArriba.collider.GetComponent<Renderer>();
            if(hitArriba.collider.CompareTag("DestructibleWall") && renderer != null){
                renderer.material.color = new Color(1.0f, 0.5f, 0.0f, 1.0f);
                Destroy(hitArriba.collider.gameObject, 0.5f);
            }
            switch(hitArriba.distance) {
                case 1:arriba.transform.localScale = new Vector3(0,0,0);
                       arriba.transform.position = bombPosition + new Vector3(0,0,1);break;
                case 3:arriba.transform.localScale = new Vector3(1,1,1);
                       arriba.transform.position = bombPosition + new Vector3(0,0,2);break;
                case 5:arriba.transform.localScale = new Vector3(1,2,1);
                       arriba.transform.position = bombPosition + new Vector3(0,0,3);break;
                case 7:arriba.transform.localScale = new Vector3(1,3,1);
                       arriba.transform.position = bombPosition + new Vector3(0,0,4);break;
            }
        }else{
            arriba.transform.localScale = new Vector3(1,num,1);
            arriba.transform.position = bombPosition + new Vector3(0,0,num+1);
        }
        if(Physics.Raycast(lineaAbajo, out RaycastHit hitAbajo, 2*num - 1)){
            Renderer renderer1 = hitAbajo.collider.GetComponent<Renderer>();
            if(hitAbajo.collider.CompareTag("DestructibleWall") && renderer1 != null){
                renderer1.material.color = new Color(1.0f, 0.5f, 0.0f, 1.0f);
                Destroy(hitAbajo.collider.gameObject, 0.5f);
            }
            switch(hitAbajo.distance) {
                case 1:abajo.transform.localScale = new Vector3(0,0,0);
                       abajo.transform.position = bombPosition - new Vector3(0,0,1);break;
                case 3:abajo.transform.localScale = new Vector3(1,1,1);
                       abajo.transform.position = bombPosition - new Vector3(0,0,2);break;
                case 5:abajo.transform.localScale = new Vector3(1,2,1);
                       abajo.transform.position = bombPosition - new Vector3(0,0,3);break;
                case 7:abajo.transform.localScale = new Vector3(1,3,1);
                       abajo.transform.position = bombPosition - new Vector3(0,0,4);break;
            }
        }else{
            abajo.transform.localScale = new Vector3(1,num,1);
            abajo.transform.position = bombPosition + new Vector3(0,0,-(num+1));
        }
        if(Physics.Raycast(lineaIzquierda, out RaycastHit hitIzquierda, 2*num - 1)){
            Renderer renderer2 = hitIzquierda.collider.GetComponent<Renderer>();
            if(hitIzquierda.collider.CompareTag("DestructibleWall") && renderer2 != null){
                renderer2.material.color = new Color(1.0f, 0.5f, 0.0f, 1.0f);
                Destroy(hitIzquierda.collider.gameObject, 0.5f);
            }
            switch(hitIzquierda.distance) {
                case 1:izquierda.transform.localScale = new Vector3(0,0,0);
                       izquierda.transform.position = bombPosition - new Vector3(1,0,0);break;
                case 3:izquierda.transform.localScale = new Vector3(1,1,1);
                       izquierda.transform.position = bombPosition - new Vector3(2,0,0);break;
                case 5:izquierda.transform.localScale = new Vector3(1,2,1);
                       izquierda.transform.position = bombPosition - new Vector3(3,0,0);break;
                case 7:izquierda.transform.localScale = new Vector3(1,3,1);
                       izquierda.transform.position = bombPosition - new Vector3(4,0,0);break;
            }
        }else{
            izquierda.transform.localScale = new Vector3(1,num,1);
            izquierda.transform.position = bombPosition + new Vector3(-(num+1),0,0);
        }
        if(Physics.Raycast(lineaDerecha, out RaycastHit hitDerecha, 2*num - 1)){
            Renderer renderer3 = hitDerecha.collider.GetComponent<Renderer>();
            if(hitDerecha.collider.CompareTag("DestructibleWall") && renderer3 != null){
                renderer3.material.color = new Color(1.0f, 0.5f, 0.0f, 1.0f);
                Destroy(hitDerecha.collider.gameObject, 0.5f);
            }
            switch(hitDerecha.distance) {
                case 1:derecha.transform.localScale = new Vector3(0,0,0);
                       derecha.transform.position = bombPosition + new Vector3(1,0,0);break;
                case 3:derecha.transform.localScale = new Vector3(1,1,1);
                       derecha.transform.position = bombPosition + new Vector3(2,0,0);break;
                case 5:derecha.transform.localScale = new Vector3(1,2,1);
                       derecha.transform.position = bombPosition + new Vector3(3,0,0);break;
                case 7:derecha.transform.localScale = new Vector3(1,3,1);
                       derecha.transform.position = bombPosition + new Vector3(4,0,0);break;
            }
        }else{
            derecha.transform.localScale = new Vector3(1,num,1);
            derecha.transform.position = bombPosition + new Vector3(num+1,0,0);
        }

        //Destruirlas después de explosionDuration segundos
        Destroy(arriba, explosionDuration);
        Destroy(abajo, explosionDuration);
        Destroy(izquierda, explosionDuration);
        Destroy(derecha, explosionDuration);

    }
}
