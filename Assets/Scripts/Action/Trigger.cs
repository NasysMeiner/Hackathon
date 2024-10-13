using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isInteractable = true;
    public bool IsInteractable { get { return _isInteractable; } set { } }

    [SerializeField] private UiManager _uiManager;

    private string _textPress = "Press E";

    public void Action()
    {
        if (IsInteractable)
        {

            _uiManager.ViewText(_textPress);

            if (Input.GetKey(KeyCode.E))
            {
                ;
            }
        }
    }

    public void ActivateView()
    {
        
    }

    public void DeActivateView()
    {
        
    }
}
