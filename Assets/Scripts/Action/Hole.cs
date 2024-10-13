using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Hole : MonoBehaviour, IInteractable
{
    [SerializeField] private float _maxStrength = 100f;
    [SerializeField] private float _currentStrength = 100f;
    [SerializeField] private float _speedRepair = 0.5f;
    [SerializeField] private bool _isInteractable = false;

    [SerializeField] private UiManager _uiManager;

    private bool _isBreake = false;

    bool IInteractable.IsInteractable { get { return _isInteractable; } set { } }
    public bool IsBreake => _isBreake;

    public void Init(float maxStrength, float speedRepair)
    {
        _maxStrength = maxStrength;
        _speedRepair = speedRepair;
    }

    private void Start()
    {
        if(_currentStrength == _maxStrength)
            _isInteractable = false;
    }

    public void ActivateView()
    {
        _uiManager.AtenntionPayalnikClose();
        if (_isInteractable)
            _uiManager.ViewProgressBar(_currentStrength, _maxStrength);

        if (!_uiManager.IsActiveText)
            _uiManager.ViewTextInteractable();
    }

    public void DeActivateView()
    {
        _uiManager.ResetProgressBar();

        if (_uiManager.IsActiveText)
            _uiManager.CloseTextInteractable();
    }

    public void Action()
    {
        if (PlayerContoller.Instance.hand == 1)
        {
            ActivateView();

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
                    EventManager.Instance.EndEvent();
                    Debug.Log("Yes!!!");
                    _isBreake = false;
                    DeActivateView();
                }
            }
        }
        else
        {
            DeActivateView();
            _uiManager.AtenntionPayalnik();
        }
    }

    public void Breake()
    {
        _currentStrength = 0;
        _isInteractable = true;
        DeActivateView();
        _isBreake = true;
        //Update model
    }
}
