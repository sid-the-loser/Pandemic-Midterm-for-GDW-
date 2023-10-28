using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string currentPosition;

    void Start()
    {
        currentPosition = "Bogota";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Board._positionMarkers[currentPosition].transform.position, 10 * Time.deltaTime);
        
    }
}
