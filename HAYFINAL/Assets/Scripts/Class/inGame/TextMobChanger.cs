using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypewriterEffectWithList : MonoBehaviour
{
    public GameObject MobText;
    private Text textComponent;
    public float charDelay = 0.01f;

    private bool isTyping = false;
    private List<string> textLines;
    private int currentLineIndex = 0;

    private int j = 0;

    public GameObject panel;
    private Button pnl;
    public GameObject butController;

    private ButtonControll btnControll;

    public Sprite[] srites;
    public SpriteRenderer mobik;

    public AudioSource ambient;
    public AudioSource TheSlowTrack;
    public AudioSource GoodEnd;
    public AudioSource BadEnd;
    public AudioSource Tolpa;
    public AudioSource Gorod;
    private int musI;

    public CanvasGroup eye;
    public GameObject titi;
    public RectTransform titles;
    public Camera mainCamera;
    public GameObject scream;
    public Button generalButton;

    public static float vol = 100f;
    public static float lastVol;
    private void Start()
    {
        btnControll = butController.GetComponent<ButtonControll>();
        textComponent = MobText.GetComponent<Text>();
        textLines = TextContainer.textMob[j];
        textComponent.text = "";
        pnl = panel.GetComponent<Button>();
        StartTyping();
    }

    private void Update()
    {
        ambient.volume = vol;
        TheSlowTrack.volume = vol;
        GoodEnd.volume = vol;
        BadEnd.volume = vol;
        Tolpa.volume = vol;
        Gorod.volume = vol;
    }

    public void StartTyping()
    {
        if (FoodScript.IsScreamer) 
        {
            scream.SetActive(false);
            vol = lastVol;
            FoodScript.IsScreamer = false;
        }
        if (!isTyping)
        {
            StartCoroutine(TypeText());
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = "";
            textComponent.text = TextContainer.textMob[TextContainer.currentText][TextContainer.currentLine];
            TextContainer.currentLine += 1;
            isTyping = false;
            
            
            if (TextContainer.currentText == 2 && TextContainer.currentLine == 1)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                /*ambient.enabled = false;*/
                Debug.Log("mussss1");
                /*TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 2 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
            {
                StartCoroutine(CrossfadeToNextTrack(TheSlowTrack, ambient));
                /*ambient.enabled = true;
                TheSlowTrack.Pause();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 1)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                Debug.Log("mussss2");
                /*ambient.Stop();
                TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 4)
            {
                StartCoroutine(CrossfadeToNextTrack(TheSlowTrack, Tolpa));
                TheSlowTrack.Pause();
                ambient.enabled = false;
                Tolpa.Play();
                StartCoroutine(FadeInObject());
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 13)
            {
                StartCoroutine(CrossfadeToNextTrack(Tolpa, Gorod));
                /*Tolpa.Stop();
                Gorod.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 15)
            {
                StartCoroutine(CrossfadeToNextTrack(Gorod, TheSlowTrack));
                 /*Gorod.Stop();
                TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 17)
            {
                StartCoroutine(FadeOutCoroutine());
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 23)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                /*ambient.enabled = true;
                TheSlowTrack.Pause();*/
            }
            if (TextContainer.currentText == 8 && TextContainer.currentLine == 1)
            {
                Debug.Log("BadEnd");
                ambient.Stop();
                ambient.enabled = false;
            }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == 15)
        {
            BadEnd.Play();
        }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            BadEnd.Stop();
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 18)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
            /*ambient.enabled = false;
            TheSlowTrack.Play();*/
            Debug.Log("mussss3");
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
            /*ambient.enabled = true;
            TheSlowTrack.Pause();*/
        }
        if (TextContainer.currentText == 12 && TextContainer.currentLine == 2)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, GoodEnd));
            ambient.enabled = false;
            ambient.Stop();
            Debug.Log("mussss4");
        }
        if (TextContainer.currentText == 12 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            generalButton.interactable = false;
        }


        if (TextContainer.currentText == 2 && TextContainer.currentLine == 13)
        {
            StartCoroutine(RotateLeftCoroutine());
        }

        if (TextContainer.currentText == 2 && TextContainer.currentLine == 16)
        {
            StartCoroutine(RotateRightCoroutine());
        }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == 16)
        {
            StartCoroutine(FadeInObject());
        }
        if (TextContainer.currentText == 12 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            StartCoroutine(MoveUpCoroutine());
        }
        

            if (TextContainer.currentText == 1 && TextContainer.currentLine == 16)
            {
                mobik.sprite = srites[1];
            }
            else if (TextContainer.currentText == 1 && TextContainer.currentLine == 17)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 4 && TextContainer.currentLine == 6)
            {
                mobik.sprite = srites[3];
            }
            else if (TextContainer.currentText == 4 && TextContainer.currentLine == 11)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 9 && TextContainer.currentLine == 10)
            {
                mobik.sprite = srites[4];
            }
            if (TextContainer.currentText == 9 && TextContainer.currentLine == 11)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 9 && TextContainer.currentLine == 35)
            {
                mobik.sprite = srites[2];
            }
            if (TextContainer.currentText == 9 && TextContainer.currentLine == 36)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 2 && TextContainer.currentLine == 9)
            {
                mobik.sprite = srites[1];
            }
            if (TextContainer.currentText == 2 && TextContainer.currentLine == 11)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 3 && TextContainer.currentLine == 2)
            {
                mobik.sprite = srites[1];
            }
            if (TextContainer.currentText == 3 && TextContainer.currentLine == 8)
            {
                mobik.sprite = srites[0];
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 2)
            {
                mobik.sprite = srites[1];
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 6)
            {
                mobik.sprite = srites[0];
            }
            
            
            if (TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
            {
                if (TextContainer.currentText == 0)
                {
                    btnControll.FirstEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 1)
                {
                    TextContainer.currentText = 3;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 2)
                {
                    TextContainer.currentText = 3;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 3)
                {
                    btnControll.SecondEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 4)
                {
                    TextContainer.currentText = 6;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 5)
                {
                    TextContainer.currentText = 6;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 6)
                {
                    btnControll.ThirdEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 7)
                {
                    TextContainer.currentText = 8;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 9)
                {
                    TextContainer.currentText = 10;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 10)
                {
                    btnControll.FourthEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 11)
                {
                    TextContainer.currentText = 8;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 8)
                {
                    titi.SetActive(true);
                    StartCoroutine(MoveUpCoroutine());
                }
                else if (TextContainer.currentText == 12)
                {
                    titi.SetActive(true);
                    StartCoroutine(MoveUpCoroutine());
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
            }
        }
    }

    private IEnumerator TypeText()
    {
        yield return new WaitForSeconds(0.5f);
        isTyping = true;
        textComponent.text = "";

        foreach (char c in TextContainer.textMob[TextContainer.currentText][TextContainer.currentLine])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(charDelay);
        }

        TextContainer.currentLine += 1;
        isTyping = false;
        
        if (TextContainer.currentText == 2 && TextContainer.currentLine == 1)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                /*ambient.enabled = false;*/
                Debug.Log("mussss1");
                /*TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 2 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
            {
                StartCoroutine(CrossfadeToNextTrack(TheSlowTrack, ambient));
                /*ambient.enabled = true;
                TheSlowTrack.Pause();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 1)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                Debug.Log("mussss2");
                /*ambient.Stop();
                TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 4)
            {
                StartCoroutine(CrossfadeToNextTrack(TheSlowTrack, Tolpa));
                TheSlowTrack.Pause();
                ambient.enabled = false;
                Tolpa.Play();
                StartCoroutine(FadeInObject());
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 13)
            {
                StartCoroutine(CrossfadeToNextTrack(Tolpa, Gorod));
                /*Tolpa.Stop();
                Gorod.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 15)
            {
                StartCoroutine(CrossfadeToNextTrack(Gorod, TheSlowTrack));
                /*Gorod.Stop();
                TheSlowTrack.Play();*/
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 17)
            {
                StartCoroutine(FadeOutCoroutine());
            }
            if (TextContainer.currentText == 5 && TextContainer.currentLine == 23)
            {
                StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
                /*ambient.enabled = true;
                TheSlowTrack.Pause();*/
            }
            if (TextContainer.currentText == 8 && TextContainer.currentLine == 1)
            {
                Debug.Log("BadEnd");
                ambient.Stop();
                ambient.enabled = false;
            }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == 15)
        {
            BadEnd.Play();
        }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            BadEnd.Stop();
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 18)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
            /*ambient.enabled = false;
            TheSlowTrack.Play();*/
            Debug.Log("mussss3");
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, TheSlowTrack));
            /*ambient.enabled = true;
            TheSlowTrack.Pause();*/
        }
        if (TextContainer.currentText == 12 && TextContainer.currentLine == 2)
        {
            StartCoroutine(CrossfadeToNextTrack(ambient, GoodEnd));
            ambient.enabled = false;
            ambient.Stop();
            Debug.Log("mussss4");
        }
        
        if (TextContainer.currentText == 12 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            generalButton.interactable = false;
        }


        if (TextContainer.currentText == 2 && TextContainer.currentLine == 13)
        {
            StartCoroutine(RotateLeftCoroutine());
        }

        if (TextContainer.currentText == 2 && TextContainer.currentLine == 16)
        {
            StartCoroutine(RotateRightCoroutine());
        }
        if (TextContainer.currentText == 8 && TextContainer.currentLine == 16)
        {
            StartCoroutine(FadeInObject());
        }
        if (TextContainer.currentText == 12 && TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
        {
            
            StartCoroutine(MoveUpCoroutine());
        }
        
        

        if (TextContainer.currentText == 1 && TextContainer.currentLine == 16)
        {
            mobik.sprite = srites[1];
        }
        else if (TextContainer.currentText == 1 && TextContainer.currentLine == 17)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 4 && TextContainer.currentLine == 6)
        {
            mobik.sprite = srites[3];
        }
        else if (TextContainer.currentText == 4 && TextContainer.currentLine == 11)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 10)
        {
            mobik.sprite = srites[4];
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 11)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 35)
        {
            mobik.sprite = srites[2];
        }
        if (TextContainer.currentText == 9 && TextContainer.currentLine == 36)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 2 && TextContainer.currentLine == 9)
        {
            mobik.sprite = srites[1];
        }
        if (TextContainer.currentText == 2 && TextContainer.currentLine == 11)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 3 && TextContainer.currentLine == 2)
        {
            mobik.sprite = srites[1];
        }
        if (TextContainer.currentText == 3 && TextContainer.currentLine == 8)
        {
            mobik.sprite = srites[0];
        }
        if (TextContainer.currentText == 5 && TextContainer.currentLine == 2)
        {
            mobik.sprite = srites[1];
        }
        if (TextContainer.currentText == 5 && TextContainer.currentLine == 6)
        {
            mobik.sprite = srites[0];
        }
            
            
            
            if (TextContainer.currentLine == TextContainer.textMob[TextContainer.currentText].Count)
            {
                if (TextContainer.currentText == 0)
                {
                    btnControll.FirstEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 1)
                {
                    TextContainer.currentText = 3;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 2)
                {
                    TextContainer.currentText = 3;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 3)
                {
                    btnControll.SecondEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 4)
                {
                    TextContainer.currentText = 6;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 5)
                {
                    TextContainer.currentText = 6;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 6)
                {
                    btnControll.ThirdEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 7)
                {
                    TextContainer.currentText = 8;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 9)
                {
                    TextContainer.currentText = 10;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 10)
                {
                    btnControll.FourthEvent();
                    TextContainer.currentLine = 0;
                    pnl.interactable = false;
                    generalButton.gameObject.SetActive(false);
                }
                else if (TextContainer.currentText == 11)
                {
                    TextContainer.currentText = 8;
                    TextContainer.currentLine = 0;
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
                else if (TextContainer.currentText == 8)
                {
                    titi.SetActive(true);
                    StartCoroutine(MoveUpCoroutine());
                }
                else if (TextContainer.currentText == 12)
                {
                    titi.SetActive(true);
                    StartCoroutine(MoveUpCoroutine());
                    pnl.interactable = true;
                    generalButton.gameObject.SetActive(true);
                }
            }
    }
    
    private IEnumerator FadeInObject()
    {
        generalButton.interactable = false;
        Debug.Log("FadeIn");
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            eye.alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        eye.alpha = 1f;
        generalButton.interactable = false;
    }
    
    private IEnumerator FadeOutCoroutine()
    {
        generalButton.interactable = false;
        Debug.Log("FadeOut");
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            eye.alpha = Mathf.Lerp(1f, 0f, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        eye.alpha = 0f;
        generalButton.interactable = true;
    }
    
    private IEnumerator RotateLeftCoroutine()
    {
        generalButton.interactable = false;
        Quaternion startRotation = mainCamera.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y - 45f, startRotation.eulerAngles.z);

        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            mainCamera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / 2f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.rotation = endRotation;
        generalButton.interactable = true;
    }
    
    private IEnumerator RotateRightCoroutine()
    {
        generalButton.interactable = false;
        Quaternion startRotation = mainCamera.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y + 45f, startRotation.eulerAngles.z);

        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            mainCamera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / 2f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.rotation = endRotation;
        generalButton.interactable = true;
    }

    private IEnumerator MoveUpCoroutine()
    {
        yield return new WaitForSeconds(10f);
        generalButton.interactable = false;
        Vector3 startPosition = titles.anchoredPosition;
        Vector3 endPosition = startPosition + new Vector3(0f, 4500f, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < 15f)
        {
            titles.anchoredPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / 15f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        titles.anchoredPosition = endPosition;
        SceneManager.LoadScene(0);
    }

    private IEnumerator MoveForvardCoroutine()
    {
        // Сохраняем начальную позицию элемента
        Vector3 startPosition = mainCamera.transform.position;
        Vector3 endPosition = startPosition + new Vector3(2f, 20f, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < 10f)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / 100f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = endPosition;
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        vol = volume;
    }
    
    private IEnumerator CrossfadeToNextTrack(AudioSource asource, AudioSource asource2)
    {
        asource2.Play();
        asource2.volume = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < 5f)
        {
            asource.volume = Mathf.Lerp(1f, 0f, elapsedTime / 5f);
            elapsedTime += Time.deltaTime;
            asource2.volume = Mathf.Lerp(0f, 1f, elapsedTime / 5f);
            yield return null;
        }
        asource.Stop();
        /*elapsedTime = 0f;
        
        
        while (elapsedTime < 5f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }*/
    }
}