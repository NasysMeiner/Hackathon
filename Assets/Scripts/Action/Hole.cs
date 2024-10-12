using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Hole : MonoBehaviour, IInteractable
{
    [SerializeField] private float _maxStrength = 100f;
    [SerializeField] private float _currentStrength = 100f;
    [SerializeField] private float _speedRepair = 0.5f;
    [SerializeField] private bool _isInteractable = false;

    [SerializeField] private UiManager _uiManager;


    public void Init(float maxStrength, float speedRepair)
    {
        _maxStrength = maxStrength;
        _speedRepair = speedRepair;
    }

    public void Action()
    {
        if(_currentStrength < _maxStrength)
        {
            _currentStrength += _speedRepair * Time.deltaTime;
            _uiManager.ViewProgressBar(_currentStrength, _maxStrength);
        }
        else
        {
            _isInteractable = false;
            _uiManager.ResetProgressBar();
        }
    }

    public void Breake()
    {
        _currentStrength = 0;
        _isInteractable = true;
        _uiManager.ResetProgressBar();
        //Update model
    }
}
