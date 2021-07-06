using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //private void OnMouseOver()   //taki sam efekt jak onMouseDown, tylko ¿e tutaj mo¿na dodaæ jeszcze ró¿ne funkcjonalnoœci
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log(transform.name);
    //    }
    //}

    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }  // chcemy skorzystaæ z tego w innm skrypcie ale nie chcemy mieæ mo¿liwoœci zmiany ¿eby nie zrobiæ problemów dlatego ustawiamy geta 

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }

}
