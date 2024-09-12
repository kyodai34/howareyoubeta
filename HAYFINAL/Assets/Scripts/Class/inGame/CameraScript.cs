using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private GameObject cylinder;
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject position;
    [SerializeField] private GameObject textMob;
    private Text MobText;

    [SerializeField] private Button myButton;
    private enum Stages { start, mid, end };
    private static Stages number;
    private int count = 0;
    private int change = 0;
    private string[] names = new[] { "Блины", "Пончики", "Шаурма" };



    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(functional);
        MobText = textMob.GetComponent<Text>();
    }
    void ArrayChanger()
    {
   
    }






public void functional()
    {
        myButton.interactable = false;
        count++;
        onStart();
  
    }

    void onStart()
    {
        StartCoroutine(MoveToTarget());
        TextContainer.currentText = 3;
    }

    IEnumerator MoveToTarget()
    {
        GameObject[] gameObjects = new GameObject[3];
        gameObjects[0] = cylinder;
        gameObjects[1] = circle;
        gameObjects[2] = square;
        Vector3 startPosition = gameObjects[change].transform.position;
        float elapsedTime = 0f;
        int duration = 1;
        Vector3 targetPosition = new Vector3(gameObjects[change].transform.position.x - 2.5f, gameObjects[change].transform.position.y,
            gameObjects[change].transform.position.z);

        


        while (elapsedTime < duration)
        {
            gameObjects[change].transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    
        gameObjects[change].transform.position = targetPosition;
        MobText.text = names[change];
        if (count > 1)
        {
            gameObjects[change].transform.position = position.transform.position;
            count = 0;
            change++;
            UnityEngine.Debug.Log("WORKING");
        }
        if (change > 2)
        {
            change = 0;
        }
        myButton.interactable = true;
        UnityEngine.Debug.Log(count);
        UnityEngine.Debug.Log(change);
    }

}

 
