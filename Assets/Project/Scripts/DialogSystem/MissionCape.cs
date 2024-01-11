using UnityEngine;
using TMPro;
using System.Collections;

public class MissionCape : MonoBehaviour
{
    [SerializeField]
    private string[] dialogList;

    [Header("Components")]
    [SerializeField]
    private GameObject dialogUI;
    [SerializeField]
    private TextMeshProUGUI dialogText;

    [SerializeField]
    private CanvasGroup Credits;

    private void Start()
    {
        dialogUI.SetActive(false);
        Credits.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerComponents>())
        {
            if (PlayerComponents.Instance.VisualManager.EquipedItens[ArmorTypes.Hood.ToString()] && PlayerComponents.Instance.VisualManager.EquipedItens[ArmorTypes.Face.ToString()])
                Finish();
            else
                ShowDialog();
        }
    }
    void ShowDialog()
    {
        dialogUI.SetActive(true);
        int rng = Random.Range(0, dialogList.Length);
        dialogText.SetText(dialogList[rng]);

        StopAllCoroutines();
        StartCoroutine(TurnOff());
    }
    IEnumerator TurnOff()
    {
        float rngTime = Random.Range(4, 9);
        yield return new WaitForSeconds(rngTime);
        dialogUI.SetActive(false);
    }
    void Finish()
    {
        Credits.gameObject.SetActive(true);
        StartCoroutine(FadeCanvasGroup(Credits, 0, 1, 1));
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }

        canvasGroup.alpha = targetAlpha;


        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}