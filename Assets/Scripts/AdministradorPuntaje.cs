using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdministradorPuntaje : MonoBehaviour
{
    public static AdministradorPuntaje Instance;
    public TextMeshProUGUI scoreText;
    private float score = 0;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    public void AgregarPuntos(float points){
        score += points;
        UpdateScoreText();
    }
    void UpdateScoreText(){
        scoreText.text = "Puntaje: " + score.ToString("0");  
    }
}
