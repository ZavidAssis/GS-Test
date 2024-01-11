using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;
public class PlayerVisualManager : MonoBehaviour
{
    [EnumNamedArray(typeof(ArmorTypes))]
    [SerializeField]
    private BodyParts[] myBodyParts;
    [Serializable]
    struct BodyParts
    {
        [Tooltip("Order: Left, Right")]
        public SpriteRenderer[] sides;
    }
    public const int BodyPartsNumber = 9;
    //aux var
    private Dictionary<string, SpriteRenderer[]> bodyPartsDic = new();
    private Dictionary<string, ItemSO> equipedItens = new();
    private Dictionary<string, Sprite[]> bodyPartsBase = new();

    public Dictionary<string, ItemSO> EquipedItens { get => equipedItens;}

    void SetBodyPartsDic()
    {
        for (int i = 0; i < myBodyParts.Length; i++)
        {
            List<Sprite> sprites = new();
            for (int j = 0; j < myBodyParts[i].sides.Length; j++)
                sprites.Add(myBodyParts[i].sides[j].sprite);

            bodyPartsDic.Add(((ArmorTypes)i).ToString(), myBodyParts[i].sides);
            equipedItens.Add(((ArmorTypes)i).ToString(), null);
            bodyPartsBase.Add(((ArmorTypes)i).ToString(), sprites.ToArray());
        }

    }

    protected void Awake()
    {
        SetBodyPartsDic();
    }
    public void SetVisual(ArmorSO item)
    {
        SpriteRenderer[] target = bodyPartsDic[item.MyType.ToString()];

        for (int i = 0; i < target.Length; i++)
            target[i].sprite = item.MyVisual[i];

        if (equipedItens[item.MyType.ToString()])
            PlayerInventory.Instance.AddItem(equipedItens[item.MyType.ToString()]);

        //replace equiped item
        equipedItens[item.MyType.ToString()] = item;

        //here we add status effect and other things
    }
    public void SetVisualBase(ArmorTypes type)
    {
        PlayerInventory.Instance.AddItem(equipedItens[type.ToString()]);

        //remove item from equipeds
        equipedItens[type.ToString()] = null;

        SpriteRenderer[] target = bodyPartsDic[type.ToString()];
        Sprite[] sprites = bodyPartsBase[type.ToString()];

        for (int i = 0; i < target.Length; i++)
            target[i].sprite = sprites[i];
    }
}
