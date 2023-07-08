using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladePositioning : MonoBehaviour
{
    public float minRadius;
    public float maxRadius;

    [SerializeField]
    private float radius;

    [field:SerializeField]
    public Vector3 endVector { get; private set;}

    private Rect cameraRect;

    public void StartCalculate(){

        _getCameraBoundaries();
        _setRadiusAndEndVector();

    }

    public Vector3 GetEndPosition(){

        return endVector;

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

    private void _setRadiusAndEndVector(){

        radius = Random.Range(minRadius, maxRadius);

        Vector3 spawnPositionVector = transform.position;

        //minimum cap ile rastgele cap arasında bir deger belirlemesini istedigimizden minRadius - radius arasinda
        //rastgele sectirdik. \ Corpyr

        //Clamp cozumu https://discussions.unity.com/t/how-to-keep-object-from-going-off-screen/93736 \ Corpyr

        float endvectorx = Mathf.Clamp(spawnPositionVector.x + Random.Range(minRadius, radius) * (Random.Range(0,2)*2-1), cameraRect .xMin, cameraRect .xMax);
        float endvectory = Mathf.Clamp(spawnPositionVector.y + Random.Range(minRadius, radius) * (Random.Range(0,2)*2-1), cameraRect .yMin, cameraRect .yMax);

        endVector = new Vector3(endvectorx , endvectory, 0); 

    }

}
