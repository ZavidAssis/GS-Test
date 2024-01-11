using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InventoryState
{
    Buying,
    Selling,
    Managing,
    Equipment
}
public class InventoryBase : MonoBehaviour
{
    [SerializeField]
    protected ItemEntry itemEntry;


    [SerializeField]
    private GameObject myTab;
    [SerializeField]
    protected Transform contentTransform;


    //aux vars
    protected List<ItemSO> myItens = new();
    private InventoryState currentState;
    public InventoryState CurrentState { get => currentState; }

    public void ShowHide(InventoryState state, bool ForceOn = false)
    {
        bool turn = ForceOn ? true : !myTab.activeInHierarchy;
        myTab.SetActive(turn);



        if (turn)
            TurnOn(state);

    }
    public void Hide()
    {
        myTab.SetActive(false);
        ChoicesPanel.Instance.Hide();
    }
    private void TurnOn(InventoryState state)
    {
        CountItens();
        currentState = state;
    }
    protected virtual void CountItens()
    {
        ResetItens();
        for (int i = 0; i < myItens.Count; i++)
        {
            Instantiate(itemEntry, contentTransform).Init(this, myItens[i]);
        }
    }
   protected virtual void ResetItens()
    {
        foreach (ItemEntry Item in transform.GetComponentsInChildren<ItemEntry>())
        {
            Destroy(Item.gameObject);
        }
    }
    public virtual void RemoveItem(ItemSO target)
    {
        myItens.Remove(target);
        CountItens();
    }
    public virtual void AddItem(ItemSO target)
    {
        myItens.Add(target);
        CountItens();
    }
}
