using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDUpdater : MonoBehaviour
{

    public TextMeshProUGUI GemsText;
    public TextMeshProUGUI FishText;

    private void FixedUpdate()
    {
        GemsText.text = PlayerPrefs.GetInt("gold").ToString();
        FishText.text = PlayerPrefs.GetInt("fishInBarrel").ToString() + "/" + PlayerPrefs.GetInt("barrelSize").ToString();
    }
}
