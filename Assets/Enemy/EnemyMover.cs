using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    
    void Start()
    {
        //Debug.Log("Start here");
        StartCoroutine(FollowPath());
        //Debug.Log("Finishing start"); - to see how yield works
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            
            while(travelPercent <1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

            //Przeskakiwanie po Tilesach    
            //transform.position = waypoint.transform.position;
            //Debug.Log(waypoint.name); - to see how yield works
            //yield return new WaitForSeconds(waitTime);
        }
    }
}
