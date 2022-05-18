using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FishPath : MonoBehaviour
{
    public FishSwimming fish;
    public PathCreator pathCreator;

    public float speed = 40;
    float distanceTravelled;

    private void Start()
    {
        pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fish.caught)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            
        }

    }
}
