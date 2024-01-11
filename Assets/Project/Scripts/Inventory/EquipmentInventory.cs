using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentInventory : InventoryBase
{
    public static EquipmentInventory Instance;


    [SerializeField]
    private TMP_Text EquipmentName;


    private void Awake()
    {
        Instance = this;
    }
    public void ShowHideButton()
    {
        ShowHide(InventoryState.Equipment);
    }
    protected override void ResetItens()
    {
        base.ResetItens();

        foreach (TMP_Text Item in transform.GetComponentsInChildren<TMP_Text>())
        {
            Destroy(Item.gameObject);
        }
    }
    public void CountEquip()
    {
        CountItens();
    }
    protected override void CountItens()
    {
        ResetItens();

        for (int i = 0; i < PlayerVisualManager.BodyPartsNumber; i++)
        {
            Instantiate(EquipmentName, contentTransform).SetText(((ArmorTypes)i).ToString());
            ItemSO item = PlayerComponents.Instance.VisualManager.EquipedItens[((ArmorTypes)i).ToString()] ? PlayerComponents.Instance.VisualManager.EquipedItens[((ArmorTypes)i).ToString()] : null;
            Instantiate(itemEntry, contentTransform).Init(this, item);
        }
    }
}
