// https://www.youtube.com/watch?v=AGiRP6e090c&list=PLjAb99vXJuCRD04EUp8p2az1ILZbq_ZfY&index=24

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    //Ref to waypoints
    public List<Transform> points;
    public int nextPoint;
    int pointChange = 1;
    public float speed = 2;
    public string sceneName;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject root = new GameObject(name + "_root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("WayPoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        //Init points list then add the points to it 
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextPoint];
        if(goalPoint.transform.position.x > transform.position.x) //looking left
        {
            transform.localScale = new Vector2(-1,1);
        }
        else //looking right
        {
            transform.localScale = new Vector2(1,1);
        }

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);
        if(Vector2.Distance(transform.position, goalPoint.position)<0.2f)
        {
            //Check if we are at the end of the line (make the change -1)
            if(nextPoint == points.Count -1)
            {
                pointChange = -1;
            }
            //Check if we are at the start of the line (make the change 1)
            if(nextPoint == 0)
            {
                pointChange = 1;
            }
            //Apply change to nextPoint 
            nextPoint += pointChange;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("SceneChange " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }

}
