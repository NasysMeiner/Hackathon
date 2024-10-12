using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Hole : MonoBehaviour, IInteractable
{
    [SerializeField] private float _maxStrength = 100f;
    [SerializeField] private float _currentStrength = 100f;
    [SerializeField] private float _speedRepair = 0.5f;
    [SerializeField] private bool _isInteractable = false;

    [SerializeField] private UiManager _uiManager;

    bool IInteractable.IsInteractable { get { return _isInteractable; } set { } }

    public void Init(float maxStrength, float speedRepair)
    {
        _maxStrength = maxStrength;
        _speedRepair = speedRepair;
    }

    public void ActivateView()
    {
        if(_isInteractable)
            _uiManager.ViewProgressBar(_currentStrength, _maxStrength);
    }

    public void DeActivateView()
    {
        _uiManager.ResetProgressBar();
    }

    public void Action()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_currentStrength < _maxStrength)
            {
                _currentStrength += _speedRepair * Time.deltaTime;
                ActivateView();
            }
            else
            {
                _isInteractable = false;
                DeActivateView();
            }
        }
    }

    public void Breake()
    {
        _currentStrength = 0;
        _isInteractable = true;
        DeActivateView();
        //Update model
    }
}
