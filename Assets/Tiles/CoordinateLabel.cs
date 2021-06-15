using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }


    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpadeObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); //because this script is on a child -- sprawdzić potem Convert.toint32 - wg mnie nie używać żeby nie korzystać niepotrzebnie z using System
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); 

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpadeObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
