using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class InsideMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject saveMenu;
    public bool isOpen = false;
    public bool isSaveOpen = false;

    public string currentText = "";
    public float typewriterSpeed = 0.001f;
    public string dangertext = "- Мы ещё не закончили говорить. \n- Так о чём это мы…";
    public GameObject exitMenuButton;
    public GameObject textPanel;
    public Text textMob;
    
    private TextMeshPro quitText;
    private string exit = "Выйти";
    /*[SerializeField] private GameObject exitButton;*/
    [SerializeField] private GameObject exitB;
    
    private void Start()
    {
        menu.SetActive(isOpen);
        saveMenu.SetActive(false);
        GameObject textGameObject = GameObject.Find("Text mob");
        /*quitText = exitButton.GetComponent<TextMeshPro>();*/
        textMob = textPanel.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isSaveOpen)
        {
            isOpen = !isOpen;
        }
        menu.SetActive(isOpen);
    }

    public void ContinueButton()
    {
        isOpen = false;
    }

    public void SaveGame()
    {
        isOpen = false;
        isSaveOpen = true;
        saveMenu.SetActive(true);
        
    }

    public void BackButton()
    {
        isOpen = true;
        isSaveOpen = false;
        saveMenu.SetActive(false);
    }


    public void ExitMainMenu()
    {
        isOpen = false;
        StartCoroutine(TypewriterCoroutine());
        exitMenuButton.SetActive(false);
        exitB.SetActive(false);
    }
    
    private IEnumerator TypewriterCoroutine()
    {
        foreach (char character in dangertext)
        {
            currentText += character;
            textMob.text= currentText;
            yield return new WaitForSeconds(0.01f);
            yield return null;
        }
    }
}
