using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleDictionary : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject[] obstacles = null;

    static public void Main(GameObject obstaclePrefab, GameObject[] obstacles)
    {
        // Creating a dictionary using Dictionary<TKey,TValue> class
        Dictionary<int, GameObject> obsDict = new Dictionary<int, GameObject>();
        
        if (obstacles == null)
        {
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            Debug.Log("A");
        }

        foreach (GameObject obstacle in obstacles)
        {
            int hold = Convert.ToInt32("obstacle.name");
            obsDict.Add(hold, obstacle);
            Debug.Log("holding: " + hold);
        }
    }
    /*
    void Start()
    {
        if (obstacles == null)
        {
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        }
    }

    private void Update()
    {
        foreach (GameObject obstacle in obstacles)
        {
            Debug.Log("holding: " + Convert.ToInt32("obstacle.name"));
        }
    }
    */
}