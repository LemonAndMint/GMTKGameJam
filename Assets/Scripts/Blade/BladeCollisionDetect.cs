using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCollisionDetect : MonoBehaviour
{
    public SphereCollider sphereCollider;
    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag == "Fruit"){

            if(other.GetComponent<FruitCut>() == true){

                other.GetComponent<FruitCut>().Cut();

            }

        }

    }

    public void CloseCollider(){

        sphereCollider.enabled = false;

    }

    public void OpenCollider(){

        sphereCollider.enabled = true;

    }
}
