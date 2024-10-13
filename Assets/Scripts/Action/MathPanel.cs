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
    [SerializeField] private GameObject player;
    private GameObject mainCum;
    private int result, resInt;
    public bool isActive = true;

    public void Init(UiManager uiManager)
    {
        _manager = uiManager;
    }
    public bool IsInteractable { get { return _isInteractable; } set { } }
    public void Action()
    {
        if(!isActive)
        {
            _manager.ViewText("Нажми E");

            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchCamera();
            }
        }
    }
    public void ActivateView()
    {
        if (_isInteractable)
            _manager.ViewText("Нажми E");
    }
    public void DeActivateView()
    {
        _manager.CloseText();
    }

    void SwitchCamera()
    {
       cam.gameObject.SetActive(true);
       player.SetActive(false);
       DeActivateView();
       Cursor.lockState = CursorLockMode.None;
       StartGame();
    }

    void StartGame()
    {
        int a = UnityEngine.Random.Range(50, 400);
        int b = UnityEngine.Random.Range(50, 400);
        int c = UnityEngine.Random.Range(2, 100);
        mathText.text = a + "+" + b + "-" + c;
        result = a + b - c;
    }

    public void CheckResult()
    {
        string inputString = inputField.text;
        if (int.TryParse(inputString, out int resultParse))
        {
            Debug.Log(resultParse);
            if (resultParse == result)
                EndGame();
            else
                StartCoroutine(Incorrect("Не правильно!"));
        }
        else
        {
            StartCoroutine(Incorrect("Не правильно ввёл"));
        }
        Debug.Log(resInt);
        Debug.Log(result);
    }

    public void EndGame()
    {
        cam.gameObject.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator Incorrect(String txt)
    {
        string a = mathText.text;
        mathText.text = txt;
        yield return new WaitForSeconds(1);
        mathText.text = a;
    }
}
