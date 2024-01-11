using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelButtonEntry : MonoBehaviour
{
    [SerializeField]
    private TMP_Text buttonText;
    [SerializeField]
    private Button myButton;



    public void Init(ChoicesPanel.ButtonFunction function)
    {
        buttonText.text = function.name;
        myButton.onClick.AddListener(function.action);
        myButton.onClick.AddListener(ButtonFunctionBase);
    }
    void ButtonFunctionBase()
    {
        ChoicesPanel.Instance.Hide();
    }
}
