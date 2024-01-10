using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoicesPanel : SingletonBase<ChoicesPanel>
{
    [SerializeField]
    private Transform buttonContender;
    [SerializeField]
    private PanelButtonEntry buttonEntry;

    public struct ButtonFunction
    {
        public string name;
        public UnityAction action;
    }


    public void Show(Vector2 pos,ButtonFunction[] buttons)
    {
        this.transform.position = pos;



        for (int i = 0; i < buttons.Length; i++)
            Instantiate(buttonEntry, buttonContender).Init(buttons[i]);
    }
}
