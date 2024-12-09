using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private AudioClip sonido;
    void Start()
    {
        if(portal != null){
            portal.SetActive(false);
        }
    }

    void Update()
    {
        checkEnemies();
    }
    private void checkEnemies(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0 && portal != null){
            portal.SetActive(true);
        }
    }
}
