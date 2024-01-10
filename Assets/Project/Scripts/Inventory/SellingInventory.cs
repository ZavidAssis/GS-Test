using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SellingInventory : InventoryBase
{
    [SerializeField]
    private ItemSO[] itensToSell;
    // Start is called before the first frame update
    void Awake()
    {
        myItens = itensToSell.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowHide(InventoryState.Buying);
        }
    }
}
