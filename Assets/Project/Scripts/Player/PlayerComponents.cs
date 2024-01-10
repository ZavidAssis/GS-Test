using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : SingletonBase<PlayerComponents>
{
    [SerializeField]
    private PlayerInventory inventory;
    [SerializeField]
    private PlayerVisualManager visualManager;

    public PlayerInventory Inventory { get => inventory; }
    public PlayerVisualManager VisualManager { get => visualManager; }
}
