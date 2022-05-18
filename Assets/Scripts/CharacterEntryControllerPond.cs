using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntryControllerPond : MonoBehaviour
{
    public PlayerMovement player;

    private void Start()
    {

        StartCoroutine(WalkIn());
    }


    IEnumerator WalkIn()
    {


        player.movementOverride = true;
        player.overrideDirectionLeft = false;

        yield return new WaitForSeconds(0.8f);

        player.movementOverride = false;
    }
}
