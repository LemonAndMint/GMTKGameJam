using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOn;
    public AnimationCurve sliceTimeGraph;
    public AnimationCurve spawnTimeGraph;
    public AnimationCurve spawnAmountGraph;
    public FruitMovement fruitMovement;


    
    private BladeSpawn bladeSpawn;
    private UIManager uiManager;


    private int spawnAmount;
    private float sliceTimer;
    private float timer;
    private float timeEvaluated;
    private bool isGamePaused;
    
    void Start()
    {

        bladeSpawn = GetComponent<BladeSpawn>();
        uiManager = GetComponent<UIManager>();

        uiManager.StartPanelShow(); 
    
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
                    bladeSpawn.Spawn(Random.Range(sliceTimer - 0.1f, sliceTimer + 0.2f));

                }

                timer = spawnTimeGraph.Evaluate(timeEvaluated);

            }

        }

    }

    public void SetGameOn(bool isOn){

        isGameOn = isOn;
        uiManager.StartPanelHide();
        uiManager.ScoreBoardShow();

    }

    public void GameOver(){

        DOTween.PauseAll();
        isGameOn = false;
        uiManager.GameOverPanelShow();
        uiManager.ScoreBoardHide();

    }

    public void PauseGame(){

        DOTween.PauseAll();
        Time.timeScale = 0;
        fruitMovement.enabled = false;
        uiManager.PausePanelShow();

    }

    public void UnPauseGame(){

        DOTween.PlayAll();
        Time.timeScale = 1;
        fruitMovement.enabled = true;
        uiManager.PausePanelHide();

    }

    public void RestartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitApplicaton(){

        Application.Quit();

    }

    private void _pauseSpawn(){

        while(isGamePaused == true){

        }

    }
}
