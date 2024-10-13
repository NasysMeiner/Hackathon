using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MathPanel : MonoBehaviour, IInteractable
{
    [SerializeField] private TMP_Text mathText,res;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private bool _isInteractable = true;
    [SerializeField] private Camera cam;
    [SerializeField] private UiManager _manager;
    private GameObject mainCum;
    private int result, resInt;

    public void Init(UiManager uiManager)
    {
        _manager = uiManager;
    }
    public bool IsInteractable { get { return _isInteractable; } set { } }
    public void Action()
    {
        _manager.ViewText("ֽאזלט E");

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCamera();
        }
    }
    public void ActivateView()
    {
        if (_isInteractable)
            _manager.ViewText("ֽאזלט E");
    }
    public void DeActivateView()
    {
        _manager.CloseText();
    }

    void SwitchCamera()
    {
       mainCum = Camera.main.gameObject;
       cam.gameObject.SetActive(true);
       mainCum.SetActive(false);
       DeActivateView();
       Cursor.lockState = CursorLockMode.None;
       StartGame();
    }

    void StartGame()
    {
        int a = UnityEngine.Random.Range(2, 400);
        int b = UnityEngine.Random.Range(2, 400);
        int c = UnityEngine.Random.Range(2, 400);
        mathText.text = a + "+" + b + "-" + c;
        result = 1;//a + b - c;
    }

    public void CheckResult()
    {
        Debug.Log(res.text);
        resInt = Convert.ToInt32(res);
        if (resInt == result)
            EndGame();
        Debug.Log(resInt);
        Debug.Log(result);
    }

    public void EndGame()
    {
        cam.gameObject.SetActive(false);
        mainCum.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
