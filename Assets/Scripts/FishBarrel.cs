using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishBarrel : MonoBehaviour
{
    public FishingRod rod;
    public Manager manager;

    public Animator animator;

    public int valueModifier;


    
    public int fishBarrelSize;
    public int fishInBarrel;

    private void Start()
    {
       valueModifier = rod.valueModifier;
       fishBarrelSize = manager.barrelSize;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        valueModifier = rod.valueModifier;

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            rod.fishInAnimation = false;
            rod.interactable = true;
            fishInBarrel = manager.fishInBarrel;
            if (fishInBarrel < fishBarrelSize)
            {
                manager.fishBarrelValue += collision.gameObject.GetComponent<FishSwimming>().fishValue * valueModifier;
                manager.fishInBarrel++;
                fishInBarrel = manager.fishInBarrel;
            }
            else
            {
                animator.SetTrigger("BarrelFull");
                animator.SetTrigger("BarrelFull");
                Debug.Log("Too many fish");
            }
            
        }
        
    }
}
