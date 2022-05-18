using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{

    public Button[] rodButtons;

    public Button[] barrelButtons;

    int i = 0;

    public int[] barrelSizes =
    {
        25, 50, 100
    };

    int j = -1;

    public void Start()
    {
        foreach (Button button in rodButtons)
        {
            button.GetComponent<ButtonScript>().canBuy(++i);
        }

//        foreach(Button button in barrelButtons)
//        {
//            button.GetComponent<ButtonScript>().canBuyBarrel(barrelSizes[++j]);
//        }

        for(j = 0; j < 3; j++)
        {
            barrelButtons[j].GetComponent<ButtonScript>().canBuyBarrel(barrelSizes[j]);
        }
    }
}
