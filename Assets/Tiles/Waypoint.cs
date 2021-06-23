using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
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


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }

}
