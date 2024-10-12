using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isInteractable = true;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private List<PartDialog> _dialogs = new List<PartDialog>();

    private int _currentDialog = 0;
    private int _currentPartDialog = 0;
    private int _parts = 0;
    private PartDialog _partDialog;

    public bool IsInteractable { get { return _isInteractable; } set { } }

    private void Start()
    {
        NextDialog();
    }

    public void Action()
    {
        if (IsInteractable && _partDialog != null && _currentPartDialog < _parts)
        {
            _uiManager.ViewText("Press E");

            if(Input.GetKeyDown(KeyCode.E) && _currentPartDialog < _parts)
            {
                _uiManager.CloseText();
                _uiManager.Speak(_partDialog.Parts[_currentPartDialog].Name, _partDialog.Parts[_currentPartDialog].Text);
                _currentPartDialog++;
            }
        }
        else if(IsInteractable)
        {
            _uiManager.ViewText("Press E to close");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Close");
                _uiManager.CloseDialog();
                _isInteractable = false;
                _uiManager.CloseText();
                NextDialog();
            }
        }
        else
        {
            _uiManager.CloseText();
        }
    }

    public void NextDialog()
    {
        _isInteractable = true;

        if(_currentDialog < _dialogs.Count)
        {
            _partDialog = _dialogs[_currentDialog++];
            _parts = _partDialog.Parts.Count;
            _currentPartDialog = 0;
        }
    }

    public void ActivateView()
    {
        throw new System.NotImplementedException();
    }

    public void DeActivateView()
    {
        throw new System.NotImplementedException();
    }
}
