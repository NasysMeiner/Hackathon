using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public GameObject textPanel;

    public void Speak(string name, string text, Image speaker)
    {
        textPanel.SetActive(true);
    }
}
