using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOn;
    public AnimationCurve sliceTimeGraph;
    public AnimationCurve spawnTimeGraph;
    public AnimationCurve spawnAmountGraph;

    
    private BladeSpawn bladeSpawn;
    private int spawnAmount;
    private float sliceTimer;
    private float timer;
    private float timeEvaluated;
    private bool isGamePaused;
    
    void Start()
    {

        bladeSpawn = GetComponent<BladeSpawn>();
    
        isGameOn = false;
        timeEvaluated = 0;

        timer = spawnTimeGraph.Evaluate(timeEvaluated);

        spawnAmount = Mathf.RoundToInt(spawnAmountGraph.Evaluate(timeEvaluated));

        isGamePaused = false;
    
    }

    void FixedUpdate()
    {

        if(isGameOn == true && isGamePaused == false){

            timeEvaluated += Time.deltaTime;

            if(timer > 0f){

                timer -= Time.deltaTime;

            }
            else{

                spawnAmount = Mathf.RoundToInt(spawnAmountGraph.Evaluate(timeEvaluated));

                for(int i = 0; i <= spawnAmount - 1; i++){

                    _pauseSpawn(); // oyunu durdurmak icin bos while actik. \ Corpyr
                    sliceTimer = sliceTimeGraph.Evaluate(timeEvaluated);
                    bladeSpawn.Spawn(Random.Range(sliceTimer - 1f, sliceTimer + 1));

                }

                timer = spawnTimeGraph.Evaluate(timeEvaluated);

            }

        }

    }

    public void GameOver(){

        PauseGame();

    }

    public void PauseGame(){

        //#TODO
        DOTween.PauseAll();
        Time.timeScale = 0;

    }

    private void _pauseSpawn(){

        while(isGamePaused == true){

        }

    }
}
