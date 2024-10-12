using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private List<Valve> _valves;
    [SerializeField] private UiManager _uiManager;

    private void OnEnable()
    {
        foreach (Valve valve in _valves)
            valve.Init(_uiManager);
    }
}
