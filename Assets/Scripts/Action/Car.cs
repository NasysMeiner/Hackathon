using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IInteractable
{
    [SerializeField] private UiManager _uiManager;

    [SerializeField] private bool _isInteractable = false;

    public bool IsInteractable { get { return _isInteractable; } set { } }

    public void Action()
    {
        throw new System.NotImplementedException();
    }

    public void ActivateView()
    {
        _uiManager.ViewTextInteractable();
    }

    public void DeActivateView()
    {
        _uiManager.CloseTextInteractable();
    }
}
