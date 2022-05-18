using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHouseTransitionAvailable : MonoBehaviour
{
    public SellHouseLoader houseTransition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        houseTransition.available = true;
    }

}
