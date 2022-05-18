using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePondTransitionAvailable : MonoBehaviour
{

    public PondTransition pondTransition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pondTransition.available = true;
    }
}
