using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpriteAnim
{
    public SpriteAnimType Type;
    public Sprite[] Sprites;
}
public enum SpriteAnimType
{
    Hair, Body, Eye, Clothes
}
public class SpriteAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
