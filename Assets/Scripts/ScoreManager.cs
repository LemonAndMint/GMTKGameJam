using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [field:SerializeField]
    public int score { get; private set; }

    private void Start() {
        
        score = 0;

    }

    public void IncreaseScore(){

        score++ ;

    }
}
