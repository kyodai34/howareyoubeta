using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject canvasG;
    private CanvasGroup gCanvas;
    private float speed = 3f;

    private Text sui;
    private string current = ""; 
    [SerializeField] private GameObject tx;

    [SerializeField] private GameObject but;

    private readonly List<string> quot= new List<string> {"Я захожу в блинную, единственное здание в ночной пустоши.", "Как же хочется есть. ", "Открыв дверь, я подхожу к стойке. ", "Знакомый голос... А, это он. " };
   
    
    private void Start()
    {
        gCanvas = canvasG.GetComponent<CanvasGroup>();
        sui = tx.GetComponent<Text>();
    }

    public void But()
    {
        but.SetActive(false);
        StartCoroutine(Fade());
        StartCoroutine(text());
    }

    public IEnumerator text()
    {
        yield return new WaitForSeconds(3f);
        foreach (var sentence in quot)
        {
            foreach (var chars in sentence)
            {
                current += chars;
                sui.text = current;
                yield return new WaitForSeconds(0.005f);
                yield return null;
            }
            yield return new WaitForSeconds(3f);
            current = "";
        }

        SceneManager.LoadScene(1);
    }
    
    public IEnumerator Fade()
    {
        float end = 1f;
        float time = 0f;
        float start = gCanvas.alpha;

        while (time < speed)
        {
            gCanvas.alpha = Mathf.Lerp(start, end, time / speed);
            time += Time.deltaTime;
            yield return null;
        }
        gCanvas.alpha = 1f;
        yield break;
        
    }
}