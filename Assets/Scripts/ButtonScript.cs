using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string itemName;
    public string description;
    public int itemCost;


    public Sprite itemIcon;

    public Manager manager;

    public Image GUIitemIcon;
    public TextMeshProUGUI GUIitemName;
    public TextMeshProUGUI GUIdescription;
    public TextMeshProUGUI GUIitemCost;

    public Button button;

    ColorBlock Colors;



    // Start is called before the first frame update
    void Start()
    {
        GUIitemName.SetText(itemName);
        GUIitemCost.SetText(itemCost.ToString());
        GUIdescription.SetText(description);
        GUIitemIcon.sprite = itemIcon;
    }

    public void purchaseRod(int rodType)
    {

        if (PlayerPrefs.GetInt("rodType" + rodType + "Bought", 0) == 1)
        {
            manager.rodType = rodType;
            manager.UpdateVars();
            return;
        }

        if (itemCost <= manager.gold)
        {
            Debug.Log("item bought");
            manager.gold -= itemCost;
            manager.rodType = rodType;
            manager.UpdateVars();
            turnGreen();
            PlayerPrefs.SetInt("rodType" + rodType + "Bought", 1);
        }
        else
        {
            Debug.Log("wrong");
            turnRed();
        }
    }

    public void canBuy(int rodType)
    {
        if(manager == null)
        {
            Debug.Log("Null manager");
        }
        Debug.Log("Debug" + rodType);
        if (PlayerPrefs.GetInt("rodType" + rodType + "Bought", 0) == 1)
        {
            turnRed();
        }

        if (this.itemCost <= manager.gold)
        {
            turnGreen();
        }
        else
        {
            turnRed();
        }
    }

    public void canBuyBarrel(int barrelSize)
    {
        if (manager.barrelSize >= barrelSize)
        {
            turnRed();
            return;
        }

        if (itemCost <= manager.gold)
        {
            turnGreen();
        }
        else
        {
            turnRed();
        }
    }

    public void purchaseBarrelUpgrade(int barrelSize)
    {
        if(manager.barrelSize >= barrelSize)
        {
            turnRed();
            return;
        }

        if(itemCost <= manager.gold)
        {
            manager.gold -= itemCost;
            turnGreen();
            manager.barrelSize = barrelSize;
            manager.UpdateVars();
        }
        else
        {
            turnRed();
        }
    }

    public void turnRed()
    {
        Colors = button.colors;
        Colors.pressedColor = Color.red;
        Colors.highlightedColor = Color.red;
        button.colors = Colors;
    }

    public void turnGreen()
    {
        Colors = button.colors;
        Colors.pressedColor = Color.green;
        Colors.highlightedColor = Color.green;

        button.colors = Colors;
    }



}
