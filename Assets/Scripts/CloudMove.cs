using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    public float speed;
    public Transform reset;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = reset.position;
        }
    }
}
