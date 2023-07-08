using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class FruitMovement : MonoBehaviour
{

    public GameManager gameManager;

    [SerializeField]
    bool isGameStarted;

    private Vector3 crusorPosInGame;
    private Rigidbody rb;

    private void Awake() {
        
        isGameStarted = false;
    
    }

    private void Start() {
        
        rb = GetComponent<Rigidbody>();

    }

    private void OnMouseOver() {
        
        isGameStarted = true;
        gameManager.isGameOn = true;
    }
    
    private void Update() {

        _movement();
        _rotation();
        
    }

    private void _movement(){

        if(isGameStarted == true){

            crusorPosInGame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            crusorPosInGame = new Vector3(crusorPosInGame.x, crusorPosInGame.y, 0);

            transform.position = crusorPosInGame;

        }

    }

    private void _rotation(){

        if(isGameStarted == true){

        Vector3 movementVector3 = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        Debug.DrawRay(movementVector3, movementVector3.normalized, Color.red, 0.1f);

        rb.AddTorque(movementVector3, ForceMode.Impulse);

        }

    }
   
}
