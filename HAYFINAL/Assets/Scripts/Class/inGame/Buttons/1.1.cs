using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Answer1 : MonoBehaviour
{
    [SerializeField] private Button panel;
    [SerializeField] private GameObject butControll;
    private ButtonControll btnCon;

    private void Start()
    {
        btnCon = butControll.GetComponent<ButtonControll>();
    }

    public void Answer()
    {
        btnCon.Dont();
        panel.interactable = true;
    }
}
