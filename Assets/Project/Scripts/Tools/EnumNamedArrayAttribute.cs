using System;
using UnityEngine;

public class EnumNamedArrayAttribute : PropertyAttribute
{
    public Type enumType;

    public EnumNamedArrayAttribute(Type _enumType)
    {
        enumType = _enumType;
    }
}