using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinHud : MonoBehaviour
{
    [SerializeField]
    TMP_Text myText;
    void Awake()
    {
        AttributesManager.Instance.OnMoneyChange += AttText;
    }

    void AttText(int newValue)
    {
        myText.SetText(newValue.ToString());
    }
}
