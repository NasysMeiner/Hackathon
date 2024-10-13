using TMPro;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    [SerializeField] private TMP_Text _textFuel;
    [SerializeField] private float _maxFuel = 100f;
    [SerializeField] private float _speedUp = 20f;

    private float _fuelCount = 100f;

    public float FuelCount => _fuelCount;
    public bool IsMax 
    { 
        get
        {
            return _fuelCount == _maxFuel;
        } 
    }

    private void Start()
    {
        _fuelCount = _maxFuel;
        UpdateText();
    }

    public void FillUp()
    {
        _fuelCount += _speedUp * Time.deltaTime;

        if (_fuelCount > _maxFuel)
            _fuelCount = _maxFuel;

        UpdateText();
    }

    public float Pour()
    {
        float fuelCount = (_fuelCount - _speedUp * Time.deltaTime) > 0 ? _speedUp * Time.deltaTime : _fuelCount;

        _fuelCount -= fuelCount;

        if (_fuelCount < 0)
            _fuelCount = 0;

        UpdateText();

        return fuelCount;
    }

    private void UpdateText()
    {
        _textFuel.text = $"{(int)_fuelCount}/{_maxFuel}";
    }
}
