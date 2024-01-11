using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SellingInventory : InventoryBase
{
    public static SellingInventory Instance { get; private set; }
    public VendorScript CurrentVendor {  get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public void SetShow(InventoryState state,VendorScript Vendor, ItemSO[] ItensToSell)
    {
        CurrentVendor = Vendor;
        myItens = ItensToSell.ToList();
        base.ShowHide(state, true);
    }
    public override void AddItem(ItemSO target)
    {
        base.AddItem(target);
        CurrentVendor.itensSelling.Add(target);
    }
    public override void RemoveItem(ItemSO target)
    {
        base.RemoveItem(target);
        CurrentVendor.itensSelling.Remove(target);
    }
}
