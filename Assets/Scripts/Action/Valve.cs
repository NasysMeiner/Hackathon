using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _inCorrectColor;
    [SerializeField] private MeshRenderer _propts;

    [SerializeField] private float _speed;
    [SerializeField] private int _correctValue = 50;
    [SerializeField] private float _currentValue = 0;
    [SerializeField] private float _addValue = 1;
    [SerializeField] private int _maxValue = 100;
    [SerializeField] private int _errorValue = 10;
    [SerializeField] private bool _isInteractable = true;

    private UiManager _manager;

    public bool IsInteractable { get { return _isInteractable; } set { } }

    private void Start()
    {
        _currentValue = Random.Range(0, _maxValue);
        _correctValue = Random.Range(0, _maxValue);

        CheckCorrect();
    }

    public void Init(UiManager uiManager)
    {
        _manager = uiManager;
    }

    public void Action()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _currentValue += _addValue * Time.deltaTime;
            MoveValve((int)_addValue);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            MoveValve((int)-_addValue);
            _currentValue -= _addValue * Time.deltaTime;
        }

        CheckCorrect();

        if (_currentValue > _maxValue)
            _currentValue = 0;
        else if (_currentValue < 0)
            _currentValue = _maxValue;
    }

    public void ActivateView()
    {
        if (_isInteractable)
            _manager.ViewTextValve();
    }

    public void DeActivateView()
    {
        _manager.CloseViewTextValve();
    }

    private void CheckCorrect()
    {
        if ((int)_currentValue > _correctValue - _errorValue && (int)_currentValue < _correctValue + _errorValue)
        {
            _propts.material.color = _correctColor;
            _isInteractable = false;
        }
        else
        {
            _propts.material.color = _inCorrectColor;
        }
    }

    private void MoveValve(int direction)
    {
        transform.Rotate(new Vector3(0, direction * _speed, 0));
    }
}
