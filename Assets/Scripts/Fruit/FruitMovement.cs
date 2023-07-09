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
    private Rect cameraRect;


    private void Awake() {
        
        isGameStarted = false;
    
    }

    private void Start() {
        
        rb = GetComponent<Rigidbody>();
        _getCameraBoundaries();

    }

    private void OnMouseOver() {
        
        if(isGameStarted == false && this.enabled == true){

            isGameStarted = true;
            gameManager.SetGameOn(true);
        
        }
    }
    
    private void Update() {

        _movement();
        _rotation();
        
    }

    private void _getCameraBoundaries(){ //https://discussions.unity.com/t/how-to-keep-object-from-going-off-screen/93736 \ Corpyr.
        
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);

        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect( bottomLeft.x,
                               bottomLeft.y,
                               topRight.x - bottomLeft.x,
                               topRight.y - bottomLeft.y);

    }

    private void _movement(){

        if(isGameStarted == true){

            crusorPosInGame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            crusorPosInGame = new Vector3(crusorPosInGame.x, crusorPosInGame.y, 0);

            transform.position = new Vector3( Mathf.Clamp(crusorPosInGame.x, cameraRect.xMin, cameraRect.xMax),
                                              Mathf.Clamp(crusorPosInGame.y, cameraRect.yMin, cameraRect.yMax), 0 );

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
