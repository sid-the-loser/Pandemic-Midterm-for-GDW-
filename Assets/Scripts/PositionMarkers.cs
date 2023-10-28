using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMarkers : MonoBehaviour
{
    void Start()
    {
        Board._positionMarkers[this.name] = this.gameObject;
    }
}
