using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //private void OnMouseOver()   //taki sam efekt jak onMouseDown, tylko �e tutaj mo�na doda� jeszcze r�ne funkcjonalno�ci
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log(transform.name);
    //    }
    //}

    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }  // chcemy skorzysta� z tego w innm skrypcie ale nie chcemy mie� mo�liwo�ci zmiany �eby nie zrobi� problem�w dlatego ustawiamy geta 

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)   //TUTAJ PATHFINDER WIE �E JEST ZABLOKOWANY KWADRAT
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
            gridManager.BlockNode(coordinates);
        }
    }

}
