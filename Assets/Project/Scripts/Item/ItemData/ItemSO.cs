using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Itens/New Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public int Value;
    public Sprite MyIcon;
}
