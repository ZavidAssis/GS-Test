using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InventoryState
{
    Buying,
    Selling,
    Managing
}
public class InventoryBase : MonoBehaviour
{

    [SerializeField]
    private ItemEntry itemEntry;
    [SerializeField]
    private Transform choicesPanel;


    [SerializeField]
    private GameObject myTab;
    [SerializeField]
    private Transform contentTransform;


    //aux vars
    protected List<ItemSO> myItens = new();
    private InventoryState currentState;

    public InventoryState CurrentState { get => currentState;}

    public void ShowHide(InventoryState state)
    {
        bool turn = !myTab.activeInHierarchy;
        myTab.SetActive(turn);


        if (turn)
            TurnOn(state);
        
    }

    private void TurnOn(InventoryState state)
    {
        CountItens();
        currentState = state;
    }
    void CountItens()
    {
        for (int i = 0; i < myItens.Count; i++)
        {
            Instantiate(itemEntry, contentTransform).Init(this, myItens[i]);
        }
    }

    public void RemoveItem(ItemSO target)
    {
        myItens.Remove(target);
    }
    public void AddItem(ItemSO target)
    {
        myItens.Add(target);
    }
}
