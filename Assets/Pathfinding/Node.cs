using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //dziêki temu widzimy w inspektorze zmienne
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo; //which node this node is connected to

    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates; //makes connect public variables with constructor's
        this.isWalkable = isWalkable;
    }
}
