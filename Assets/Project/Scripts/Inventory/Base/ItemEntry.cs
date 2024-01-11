using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemEntry : MonoBehaviour
{
    [SerializeField]
    private Image myImage;
    [SerializeField]
    private TMP_Text PriceText;

    InventoryBase myInv;
    ItemSO myItem;
    public void Init(InventoryBase Inv, ItemSO Item = null)
    {
        myInv = Inv;
        myItem = Item;
        SetVisual();
    }
    void SetVisual()
    {
        if (myItem)
        {
            myImage.sprite = myItem.MyIcon;

            if (myInv.CurrentState == InventoryState.Buying)
                PriceText.SetText($"{myItem.Value}$");
        }
    }
    public void MousePress()
    {
        if (myItem)
        {
            List<ChoicesPanel.ButtonFunction> functions = new();

            switch (myInv.CurrentState)
            {
                case InventoryState.Buying:
                    functions.Add(new ChoicesPanel.ButtonFunction { name = $"Buy {myItem.Value}$", action = Buy });
                    break;
                case InventoryState.Selling:
                    functions.Add(new ChoicesPanel.ButtonFunction { name = "Equip", action = Equip });
                    functions.Add(new ChoicesPanel.ButtonFunction { name = $"Sell {myItem.Value}$", action = Sell });
                    break;
                case InventoryState.Managing:
                    functions.Add(new ChoicesPanel.ButtonFunction { name = "Equip", action = Equip });
                    break;
                case InventoryState.Equipment:
                    functions.Add(new ChoicesPanel.ButtonFunction { name = "Unequip", action = Unequip });
                    break;
            }
            ChoicesPanel.Instance.Show(transform.position, functions.ToArray());
            //add here other commmom methods for all itens or you can verify item type
        }
    }
    void Unequip()
    {
        PlayerComponents.Instance.VisualManager.SetVisualBase(((ArmorSO)myItem).MyType);
        myInv.RemoveItem(myItem);
        EquipmentInventory.Instance.CountEquip();
    }
    void Equip()
    {
        PlayerComponents.Instance.VisualManager.SetVisual((ArmorSO)myItem);
        myInv.RemoveItem(myItem);
        EquipmentInventory.Instance.CountEquip();
    }
    void Buy()
    {
        if (AttributesManager.Instance.VerifyBuy(myItem.Value))
        {
            myInv.RemoveItem(myItem);
            PlayerInventory.Instance.AddItem(myItem);
            AttributesManager.Instance.SpendMoney(myItem.Value);
        }
    }
    void Sell()
    {
        myInv.RemoveItem(myItem);
        AttributesManager.Instance.GainMoney(myItem.Value);
        SellingInventory.Instance.AddItem(myItem);
    }
}
