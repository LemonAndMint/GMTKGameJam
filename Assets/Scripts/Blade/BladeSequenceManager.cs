using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSequenceManager : MonoBehaviour
{

    private Vector3 endPointVector;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<BladeEffects>().CloseTrailEffect();
        
        GetComponent<BladePositioning>().StartCalculate();
        endPointVector = GetComponent<BladePositioning>().GetEndPosition();

        GetComponent<BladeMovement>().endPosition = endPointVector;
        GetComponent<BladeEffects>().InstantiateIndicator(endPointVector);
        GetComponent<BladeEffects>().OpenEffects();

        GetComponent<BladeMovement>().startMovement();

    }

    private void Update() {

        if(GetComponent<BladeMovement>().isMovementStarted == true){

            GetComponent<BladeEffects>().CloseIndicatorImage();

        }
        
        if(GetComponent<BladeMovement>().isEnded == true){

            _deactivateBlade();

        }

    }

    private void _deactivateBlade(){

        GetComponent<BladeEffects>().DestroyIndicator();
        Destroy(gameObject);

    }
  
}
