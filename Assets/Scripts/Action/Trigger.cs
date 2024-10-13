using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isInteractable = true;
    public bool IsInteractable { get { return _isInteractable; } set { } }

    [SerializeField] private UiManager _uiManager;

    private string _textPress = "Press E";
    private TriggerControl _triggerControl;

    public void Init(UiManager uiManager, TriggerControl triggerControl)
    {
        _uiManager = uiManager;
        _triggerControl = triggerControl;
    }

    public void DisableInteracteble()
    {
        _isInteractable = false;
    }

    public void Action()
    {
        if (IsInteractable)
        {

            _uiManager.ViewText(_textPress);

            if (Input.GetKeyDown(KeyCode.E))
            {
                _triggerControl.ActivateTrigger(this);
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
