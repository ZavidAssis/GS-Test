using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerInventory : InventoryBase
{
    public static PlayerInventory Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    public void ShowHideButton()
    {
        ShowHide(InventoryState.Managing);
    }
}
