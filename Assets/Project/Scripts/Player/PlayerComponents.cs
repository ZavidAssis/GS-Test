using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : SingletonBase<PlayerComponents>
{
    [SerializeField]
    private PlayerVisualManager visualManager;
    public PlayerVisualManager VisualManager { get => visualManager; }
}
