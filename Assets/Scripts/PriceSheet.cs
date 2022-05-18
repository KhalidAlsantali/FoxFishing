using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceSheet : MonoBehaviour
{
    public GameObject PriceUI;

    private void Start()
    {
        PriceUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PriceUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PriceUI.SetActive(false);
    }
}
