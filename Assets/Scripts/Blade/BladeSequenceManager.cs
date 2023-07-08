using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSequenceManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    private Vector3 endPointVector;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BladeMovement>().enabled = false;
        GetComponent<BladeCollisionDetect>().CloseCollider();
        GetComponent<BladeEffects>().CloseTrailEffect();
        
        GetComponent<BladePositioning>().StartCalculate();
        endPointVector = GetComponent<BladePositioning>().GetEndPosition();

        GetComponent<BladeMovement>().endPosition = endPointVector;
        GetComponent<BladeEffects>().InstantiateIndicator(endPointVector);
        GetComponent<BladeEffects>().OpenEffects();

        GetComponent<BladeMovement>().enabled = true;

    }

    private void Update() {

        if(GetComponent<BladeMovement>().isMovementStarted == true){

            GetComponent<BladeEffects>().CloseIndicatorImage();
            GetComponent<BladeCollisionDetect>().OpenCollider();

        }
        
        if(GetComponent<BladeMovement>().isEnded == true){

            _deactivateBlade();

        }

    }

    private void _deactivateBlade(){

        _increaseScore();
        GetComponent<BladeEffects>().DestroyIndicator();
        Destroy(gameObject);

    }

    private void _increaseScore(){

        scoreManager.IncreaseScore();

    }
  
}
