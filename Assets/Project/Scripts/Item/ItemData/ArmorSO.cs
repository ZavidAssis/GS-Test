using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Armor", menuName = "Itens/New Armor")]
public class ArmorSO : ItemSO
{
    public ArmorTypes MyType;
    [Tooltip("Order: Left, Right")]
    public Sprite[] MyVisual;
}
