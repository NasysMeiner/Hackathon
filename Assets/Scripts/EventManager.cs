using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [SerializeField] private Robot _robot;
    [SerializeField] private List<Hole> _holes = new List<Hole>();
    [SerializeField] private List<Style> _styles = new List<Style>();
    [SerializeField] private Engine _engine;
    [SerializeField] private Car _car;

    private bool _isDialog = false;
    private bool _isEvent = false;
    private bool _isEnd = false;
    private Hole _currentHole = null;
    private int _currentStyle = 0;

    private void Start()
    {
        Instance = this;
        _robot.NextDialog();
        _isDialog = true;
    }

    private void Update()
    {
        if(_isDialog && _robot.PartDialog == null)
        {
            _isDialog = false;
            GenerateEvent();
        }
        else if(_isEvent && _isEnd)
        {
            _robot.NextDialog();
            _isDialog = true;
            _isEnd = false;
            _isEvent = false;
        }
    }

    public void EndEvent()
    {
        Debug.Log("End!!!");
        _isEnd = true;
        _currentStyle++;
    }

    private void GenerateEvent()
    {
        Style styl = _styles[_currentStyle];

        _isEvent = true;

        switch (styl)
        {
            case Style.BlackHole:
                _currentHole = _holes[Random.Range(0, _holes.Count)];
                _currentHole.Breake();
                break;

            case Style.Math:
                Debug.Log("Net poka");
                EndEvent();
                break;

            case Style.Generator:
                _engine.Breake();
                break;

            case Style.Pytnshki:
                Debug.Log("Net poka");
                EndEvent();
                break;

            case Style.Fuel:
                _car.Reset();
                break;

            case Style.Random:
                int randomNumber = Random.Range(0, 3);

                if(randomNumber == 0)
                    _styles[_currentStyle] = Style.BlackHole;
                else if(randomNumber == 1)
                    _styles[_currentStyle] = Style.Generator;
                else if (randomNumber == 2)
                    _styles[_currentStyle] = Style.Fuel;

                Debug.Log(_styles[_currentStyle]);
                GenerateEvent();
                break;
        }     
    }
}

[System.Serializable]
public enum Style
{
    Random,
    BlackHole,
    Generator,
    Fuel,
    Pytnshki,
    Math
}
