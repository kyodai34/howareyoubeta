using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtons : MonoBehaviour
{
    void Save()
    {
        PlayerPrefs.SetInt("CurrentText", TextContainer.currentText);
        PlayerPrefs.SetInt("CurrentLine", TextContainer.currentLine);
    }
}
