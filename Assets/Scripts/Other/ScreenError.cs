using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenError : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private EventManager _eventManager;

    private void Update()
    {
        _text.text = _eventManager.CheckError();
    }
}
