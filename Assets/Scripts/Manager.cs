using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public int barrelSize;
    public int rodType;
    public int gold;
    public int fishBarrelValue;
    public int fishInBarrel;
    // Start is called before the first frame update
    private void Awake()
    {
        
        barrelSize = PlayerPrefs.GetInt("barrelSize", 10);
        rodType = PlayerPrefs.GetInt("rodType", 0);
        gold = PlayerPrefs.GetInt("gold", 0);
        fishBarrelValue = PlayerPrefs.GetInt("fishBarrelValue", 0);
        fishInBarrel = PlayerPrefs.GetInt("fishInBarrel", 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVars();
    }

    private void OnDestroy()
    {
        UpdateVars();
    }

    public void SellFish()
    {
        gold += fishBarrelValue;
        fishBarrelValue = 0;
        fishInBarrel = 0;
    }

    public void UpdateVars()
    {
        PlayerPrefs.SetInt("barrelSize", barrelSize);
        PlayerPrefs.SetInt("rodType", rodType);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("fishBarrelValue", fishBarrelValue);
        PlayerPrefs.SetInt("fishInBarrel", fishInBarrel);
    }

    public void DeleteData()
    {
        Debug.Log("deleted all data");
        PlayerPrefs.DeleteAll();
        barrelSize = 10;
        rodType = 0;
        gold = 0;
        fishBarrelValue = 0;
        fishInBarrel = 0;
        UpdateVars();
    }
}
