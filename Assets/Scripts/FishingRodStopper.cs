using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRodStopper : MonoBehaviour
{
    public FishingRod rod;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rod"))
        {
            rod.goUp = !rod.goUp;
            rod.goDown = !rod.goDown;
            rod.moving = !rod.moving;
            rod.fishCaught = false;
            

            if (this.gameObject.CompareTag("Top"))
            {
                rod.canGoUp = false;
            }
            else
            {
                rod.canGoDown = false;
            }
            rod.UpdateCrank();
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("Top"))
        {
            rod.canGoUp = true;
        }
        else
        {
            rod.canGoDown = true;
        }
    }
}
