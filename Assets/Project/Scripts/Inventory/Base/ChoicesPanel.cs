using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoicesPanel : SingletonBase<ChoicesPanel>
{
    [SerializeField]
    private RectTransform myRect;
    [SerializeField]
    private Transform buttonContender;
    [SerializeField]
    private PanelButtonEntry buttonEntry;

    public struct ButtonFunction
    {
        public string name;
        public UnityAction action;
    }

    private void Start()
    {
        Hide();
    }
    public void Show(Vector2 pos, ButtonFunction[] buttons)
    {
        this.transform.position = pos;
        this.gameObject.SetActive(true);

        ResetItens();
        for (int i = 0; i < buttons.Length; i++)
            Instantiate(buttonEntry, buttonContender).Init(buttons[i]);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    void ResetItens()
    {
        foreach (PanelButtonEntry Item in transform.GetComponentsInChildren<PanelButtonEntry>())
        {
            Destroy(Item.gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = (Input.mousePosition);
            Vector2 contenderPos = (buttonContender.position);

            Vector2 distance = new Vector2(Mathf.Abs(contenderPos.x - mousePos.x), Mathf.Abs(contenderPos.y - mousePos.y));
            Vector2 rectSize = myRect.rect.size / 2;

            if (distance.x > rectSize.x || distance.y > rectSize.y) Hide();
        }
    }
}
