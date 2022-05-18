using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntryControllerHouse : MonoBehaviour
{

    public PlayerMovement player;

    private void Start()
    {
        StartCoroutine(WalkIn());
    }


    IEnumerator WalkIn()
    {
        player.movementOverride = true;
        player.overrideDirectionLeft = true;

        yield return new WaitForSeconds(0.5f);

        player.movementOverride = false;
    }

}
