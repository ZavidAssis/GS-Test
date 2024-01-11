using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    public List<ItemSO> itensSelling=new();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerComponents>())
        {
            SellingInventory.Instance.SetShow(InventoryState.Buying,this, itensSelling.ToArray());
            PlayerInventory.Instance.ShowHide(InventoryState.Selling, true);
            EquipmentInventory.Instance.ShowHide(InventoryState.Equipment, true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerComponents>())
        {
            SellingInventory.Instance.Hide();
            PlayerInventory.Instance.Hide();
            EquipmentInventory.Instance.Hide();
        }
    }
}
