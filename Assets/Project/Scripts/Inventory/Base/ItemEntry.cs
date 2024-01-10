using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntry : MonoBehaviour
{
    [SerializeField]
    private Image myImage;


    InventoryBase myInv;
    ItemSO myItem;
    public void Init(InventoryBase Inv, ItemSO Item)
    {
        myInv = Inv;
        myItem = Item;

        SetVisual();
    }
    void SetVisual()
    {
        myImage.sprite = myItem.MyIcon;
    }

    private void OnMouseUpAsButton()
    {
        MousePress();
    }
    void MousePress()
    {
        List<ChoicesPanel.ButtonFunction> functions = new();

        switch (myInv.CurrentState)
        {
            case InventoryState.Buying:
                functions.Add(new ChoicesPanel.ButtonFunction { name = "Buy", action = Buy });
                break;
            case InventoryState.Selling:
                functions.Add(new ChoicesPanel.ButtonFunction { name = "Sell", action = Sell });
                break;
            case InventoryState.Managing:
                functions.Add(new ChoicesPanel.ButtonFunction { name = "Equip", action = Equip });
                break;
        }
        //add here other commmom methods for all itens or you can verify item type
    }
    void Equip()
    {
        PlayerComponents.Instance.VisualManager.SetVisual((ArmorSO)myItem);
    }
    void Buy()
    {
        myInv.RemoveItem(myItem);
        PlayerComponents.Instance.Inventory.AddItem(myItem);
        //add on player inventory
    }
    void Sell()
    {
        myInv.RemoveItem(myItem);
    }
}
