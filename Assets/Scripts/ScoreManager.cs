using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [field:SerializeField]
    public int score { get; private set; }

    public Text ingameText;
    public TextMeshProUGUI scoreboardText;

    public GameManager gameManager;


    private void Start() {
        
        score = 0;

    }

    public void IncreaseScore(){

        if(gameManager.isGameOn == true){
            
            score++ ;

        }

    }

    private void Update() {
        
        ingameText.text = score.ToString();
        scoreboardText.text = score.ToString();

    }
}
