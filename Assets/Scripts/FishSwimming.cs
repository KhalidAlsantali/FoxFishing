using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{

    public float FishSpeed = 1;

    public bool caught = false;

    public int fishValue;

    public FishingRod rodThatCaughtMe;


    private void Start()
    {
        rodThatCaughtMe = GameObject.Find("FishingLine").GetComponent<FishingRod>();
    }


    void Update()
    {
        if(gameObject.GetComponent<HingeJoint2D>() == null && !caught)
        {
            transform.Translate(Vector2.right * Time.deltaTime * FishSpeed);
        }

        if(transform.position.y > 0.8)
        {

            Destroy(gameObject.GetComponent<HingeJoint2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            caught = true;
            rodThatCaughtMe.fishInAnimation = true;
            rodThatCaughtMe.fishCaught = false;
            rodThatCaughtMe.goDown = true;
            rodThatCaughtMe.goUp = false;
            rodThatCaughtMe.moving = false;
        }

        
    }


}
