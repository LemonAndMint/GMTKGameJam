using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCut : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject fruitGFXGameObject;
    public GameObject piecesGameObject;
    public ParticleSystem particlePrefab;

    public void Cut(){

        fruitGFXGameObject.SetActive(false);
        piecesGameObject.SetActive(true);

        GetComponent<SoundPlay>().PlayRandomSound();

        GetComponentInChildren<FruitPieceExplode>().Explode();
        GetComponent<FruitMovement>().enabled = false;

        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        gameManager.GameOver();

        gameObject.GetComponent<CapsuleCollider>().enabled = false;

    }

}
