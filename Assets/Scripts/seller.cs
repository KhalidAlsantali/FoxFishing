using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seller : MonoBehaviour
{
    public Manager manager;

    public GameObject ShopUI;

    public ButtonColorChanger buttonColorUpdater;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonColorUpdater.Start();
        manager.SellFish();
        Debug.Log("fish sold");
        ShopUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShopUI.SetActive(false);
    }
}
