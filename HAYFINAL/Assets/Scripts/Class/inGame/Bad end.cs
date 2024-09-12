using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badend : MonoBehaviour
{
    public Camera Camera;
    public GameObject targert;

    private ButtonControll btnCon;

    public GameObject contlr;
    
    public float fadeInDuration = 1f; // Длительность затемнения
    public float fadeOutDuration = 1f; // Длительность осветления

    private CanvasGroup canvasGroup;
    private bool isFadingOut = false;
    public GameObject darkPanel;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = darkPanel.GetComponent<CanvasGroup>();
        btnCon = contlr.GetComponent<ButtonControll>();
    }

    public void BadEnd()
    {
        btnCon.Dont();
        TextContainer.currentText = 8;
        darkPanel.SetActive(true);
        StartCoroutine(FadeInCoroutine());
        StartCoroutine(FadeOutCoroutine());
        darkPanel.SetActive(false);
    } 
    
    private IEnumerator FadeInCoroutine()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float endAlpha = 1f; // Конечная непрозрачность (полностью непрозрачный)

        while (elapsedTime < fadeInDuration)
        {
            // Линейно интерполируем alpha значение от startAlpha к endAlpha
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Убедитесь, что в конце alpha равен endAlpha
        canvasGroup.alpha = endAlpha;
        isFadingOut = false;
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float endAlpha = 0f; // Конечная прозрачность (полностью прозрачный)

        while (elapsedTime < fadeOutDuration)
        {
            // Линейно интерполируем alpha значение от startAlpha к endAlpha
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Убедитесь, что в конце alpha равен endAlpha
        canvasGroup.alpha = endAlpha;
        isFadingOut = true;
    }
}
