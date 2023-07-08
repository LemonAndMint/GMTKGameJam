using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BladeMovement : MonoBehaviour
{
    public float timer;

    public Vector3 endPosition;

    public bool isStarted { get; private set;}
    public bool isMovementStarted { get; private set;}
    public bool isEnded { get; private set;}

    private void Start() {
        
        isStarted = false;
        isEnded = false;
        isMovementStarted = false;

    }

    private void Update() {

        if(isStarted == true){

            if(timer > 0f){

                timer -= Time.deltaTime;

            }
            else{

                _movement();

            }

        }

    }

    public void startMovement(){

        isStarted = true;

    }

    private void _movement(){

        isMovementStarted = true;

        transform.DOMove(endPosition, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => { transform.DOKill(); isEnded = true; });

    }
   
}
