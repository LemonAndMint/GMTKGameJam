using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPieceExplode : MonoBehaviour
{
    public float explosionForceValue ,range;
    public void Explode(){

        foreach( Transform child in this.transform ){

            child.transform.parent = null;
            child.GetComponent<Rigidbody>().AddExplosionForce(explosionForceValue, transform.position, range);

        }

    }

    
}
