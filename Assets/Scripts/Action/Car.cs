using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IInteractable
{
    [SerializeField] private string _textNoFuel = "No fuel";
    [SerializeField] private string _textNoItem = "No fuel";
    [SerializeField] private string _textFullFuel = "Full fuel";
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private float _maxFuel = 100f;
    [SerializeField] private float _currentFuel = 0f;

    [SerializeField] private bool _isInteractable = false;

    public bool IsInteractable { get { return _isInteractable; } set { } }

    public void Action()
    {
        if(PlayerContoller.Instance.hand == 2 && IsInteractable)
        {
            if(PlayerContoller.FuelController.FuelCount <= 0)
            {
                _uiManager.ViewText(_textNoFuel);
                _uiManager.OpenFuelText();
                _uiManager.ViewProgressBar(_currentFuel, _maxFuel);

                return;
            }

            _uiManager.CloseText();
            _uiManager.ViewProgressBar(_currentFuel, _maxFuel);
            _uiManager.OpenFuelText();

            if (_currentFuel < _maxFuel && PlayerContoller.FuelController.FuelCount > 0)
                _uiManager.ViewText("Press E");

            if (Input.GetKey(KeyCode.E))
            {
                if (_currentFuel < _maxFuel)
                {
                    _currentFuel += PlayerContoller.FuelController.Pour();
                }
                else if (_currentFuel >= _maxFuel)
                {
                    DeActivateView();
                    IsInteractable = false;
                    _uiManager.ViewText(_textFullFuel);
                    _currentFuel = _maxFuel;
                }
            }         
        }
        else if(PlayerContoller.Instance.hand != 2)
        {
            _uiManager.ViewText(_currentFuel >= _maxFuel ? _textFullFuel : _textNoItem);
            _uiManager.ViewProgressBar(_currentFuel, _maxFuel);
            _uiManager.CloseFuelText();
        }
    }

    public void ActivateView()
    {
        _uiManager.ViewTextInteractable();
        _uiManager.ViewProgressBar(_currentFuel, _maxFuel);
    }

    public void DeActivateView()
    {
        _uiManager.CloseTextInteractable();
        _uiManager.ResetProgressBar();
        _uiManager.CloseFuelText();
    }
}
