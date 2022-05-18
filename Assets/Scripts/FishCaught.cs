using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCaught : MonoBehaviour
{
    public FishingRod fishrod;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
    }
}
