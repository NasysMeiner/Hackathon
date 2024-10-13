using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private List<Valve> _valves;
    [SerializeField] private UiManager _uiManager;

    private bool _isTrue = false;
    private bool _isBreake = false;
    private bool _isActive = true;

    public bool IsTrue => _isTrue;
    public bool IsBreake => _isBreake;

    private void OnEnable()
    {
        foreach (Valve valve in _valves)
            valve.Init(_uiManager);

        foreach (Valve valve in _valves)
            valve.Repair();
    }

    private void Update()
    {
        if (_isBreake)
        {
            int count = 0;

            for (int i = 0; i < _valves.Count; i++)
            {
                if (_valves[i].IsRepair)
                    count++;
            }

            if (count == _valves.Count)
            {
                _isBreake = false;

                if (EventManager.Instance != null)
                    EventManager.Instance.EndEvent();
            }
        }
    }

    public void Breake()
    {
        _isBreake = true;

        foreach (Valve valve in _valves)
            valve.Init(_uiManager);
    }
}
