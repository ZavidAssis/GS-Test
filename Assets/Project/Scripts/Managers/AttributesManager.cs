using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AttributesManager : SingletonBase<AttributesManager>
{
    public Action<int> OnMoneyChange;

    [SerializeField]
    private int InitialMoney;

    int currentMoney;
    private void Start()
    {
        currentMoney = InitialMoney;
        OnMoneyChange.Invoke(currentMoney);
    }

    public bool VerifyBuy(int price)
    {
        bool canBuy = currentMoney >= price ? true : false;
        return canBuy;
    }
    public void SpendMoney(int amount)
    {
        currentMoney-=amount;
        OnMoneyChange.Invoke(currentMoney);
        //visuals here

    }
    public void GainMoney(int amount)
    {
        currentMoney += amount;
        OnMoneyChange.Invoke(currentMoney);
        //visuals here
    }
}
