using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;
public class PlayerVisualManager : MonoBehaviour
{
    #region bodyParts
    [EnumNamedArray(typeof(ArmorTypes))]
    [SerializeField]
    private BodyParts[] myBodyParts;
    [Serializable]
    struct BodyParts
    {
        [Tooltip("Order: Left, Right")]
        public SpriteRenderer[] sides;
    }

    //aux var
    private Dictionary<string, SpriteRenderer[]> bodyPartsDic = new();

    void SetBodyPartsDic()
    {
        for (int i = 0; i < myBodyParts.Length; i++)
        {
            bodyPartsDic.Add(((ArmorTypes)i).ToString(), myBodyParts[i].sides);
        }
    }

    #endregion
    protected void Awake()
    {
        SetBodyPartsDic();
    }
    public void SetVisual(ArmorSO item)
    {
        SpriteRenderer[] target = bodyPartsDic[item.MyType.ToString()];

        for (int i = 0; i < target.Length; i++)
            target[i].sprite = item.MyVisual[i];


        //here we add status effect and other things
    }
}
