using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeEffects : MonoBehaviour
{
    public GameObject trailGameObject;
    public GameObject endIndicatorImagePrefab;
    public GameObject startIndicator;

    private GameObject endIndicatorImage;

    public void InstantiateIndicator(Vector3 position){

        endIndicatorImage = Instantiate(endIndicatorImagePrefab, position, Quaternion.identity);

    }

    public void CloseTrailEffect(){

        trailGameObject.SetActive(false);

    }

    public void OpenEffects(){

        trailGameObject.SetActive(true);
        endIndicatorImage.SetActive(true);

    }

    public void CloseIndicatorImage(){

        endIndicatorImage.SetActive(false);
        startIndicator.SetActive(false);

    }

    public void DestroyIndicator(){

        Destroy(endIndicatorImage);

    }

}
