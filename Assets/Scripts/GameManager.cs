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
    private float sliceTimer;
    private int spawnAmount;
    private float timer;

    private float timeEvaluated;
    
    void Start()
    {

        bladeSpawn = GetComponent<BladeSpawn>();
    
        isGameOn = false;
        timeEvaluated = 0;

        timer = spawnTimeGraph.Evaluate(timeEvaluated);

        spawnAmount = Mathf.RoundToInt(spawnAmountGraph.Evaluate(timeEvaluated));
    
    }

    void FixedUpdate()
    {

        if(isGameOn == true){

            timeEvaluated += Time.deltaTime;

            if(timer > 0f){

                timer -= Time.deltaTime;

            }
            else{

                spawnAmount = Mathf.RoundToInt(spawnAmountGraph.Evaluate(timeEvaluated));

                for(int i = 0; i <= spawnAmount - 1; i++){

                    sliceTimer = sliceTimeGraph.Evaluate(timeEvaluated);
                    bladeSpawn.Spawn(Random.Range(sliceTimer - 0.1f, sliceTimer + 0.1f));

                }

                timer = spawnTimeGraph.Evaluate(timeEvaluated);

            }

        }

    }

    public void GameOver(){

        Destroy(GetComponent<BladeSpawn>());
        DOTween.PauseAll();
        this.enabled = false;

    }

    public void PauseGame(){

        //#TODO

    }
}
