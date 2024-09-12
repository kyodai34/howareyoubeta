using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControll : MonoBehaviour
{
    [SerializeField] private GameObject firstAnswer;
    [SerializeField] private GameObject secondAnswer;
    [SerializeField] private GameObject foodAnswer;
    
    [SerializeField] private GameObject SecondFirstAnswer;
    [SerializeField] private GameObject SecondSecondAnswer;
    
    [SerializeField] private GameObject TrirdFirstAnswer;
    [SerializeField] private GameObject TrirdSecondAnswer;
    
    [SerializeField] private GameObject FourthFirstAnswer;
    [SerializeField] private GameObject FourthSecondAnswer;

    public Button generalButton;

    public Button pnl;

    private bool foodDelete = true;

    private void Update()
    {
        if (TextContainer.howFood > 1 || TextContainer.currentText > 8)
        {
            foodDelete = false;
        }
    }

    public void FirstEvent()
    {
        firstAnswer.SetActive(true);
        secondAnswer.SetActive(true);
        foodAnswer.SetActive(true);
    }
    
    public void Dont()
    {
        firstAnswer.SetActive(false);
        secondAnswer.SetActive(false);
        foodAnswer.SetActive(false);
        SecondFirstAnswer.SetActive(false);
        SecondSecondAnswer.SetActive(false);
        TrirdFirstAnswer.SetActive(false);
        TrirdSecondAnswer.SetActive(false);
        FourthFirstAnswer.SetActive(false);
        FourthSecondAnswer.SetActive(false);
    }
    
    public void SecondEvent()
    {
        SecondFirstAnswer.SetActive(true);
        SecondSecondAnswer.SetActive(true);
        foodAnswer.SetActive(foodDelete);
    }
    
    public void ThirdEvent()
    {
        TrirdFirstAnswer.SetActive(true);
        TrirdSecondAnswer.SetActive(true);
        foodAnswer.SetActive(foodDelete);
    }
    
    public void FourthEvent()
    {
        FourthFirstAnswer.SetActive(true);
        FourthSecondAnswer.SetActive(true);
        foodAnswer.SetActive(foodDelete);
    }
    
    public void First11()
    {
        Dont();
        TextContainer.currentText = 1;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    
    public void First12()
    {
        Dont();
        TextContainer.currentText = 2;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    public void First21()
    {
        Dont();
        TextContainer.currentText = 4;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    public void First22()
    {
        Dont();
        TextContainer.currentText = 5;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    public void First31()
    {
        Dont();
        TextContainer.currentText = 7;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    
    public void First32()
    {
        Dont();
        TextContainer.currentText = 9;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    public void First41()
    {
        Dont();
        TextContainer.currentText = 11;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
    public void First42()
    {
        Dont();
        TextContainer.currentText = 12;
        pnl.interactable = true;
        generalButton.gameObject.SetActive(true);
    }
}
