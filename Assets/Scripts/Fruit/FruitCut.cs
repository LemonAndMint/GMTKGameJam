using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCut : MonoBehaviour
{
    public GameObject fruitGFXGameObject;
    public GameObject piecesGameObject;
    public void Cut(){

        fruitGFXGameObject.SetActive(false);
        piecesGameObject.SetActive(true);

        GetComponentInChildren<FruitPieceExplode>().Explode();
        GetComponent<FruitMovement>().enabled = false;

    }

}
