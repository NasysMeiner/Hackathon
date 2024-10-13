using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerControl : MonoBehaviour
{
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _inCorrectColor;
    [SerializeField] private Light _light;
    //Список всех триггеров
    [SerializeField] Trigger[] triggers;

    //Списсок состояний триггеров
    int[] triggerStates;

    //Состояние генератора
    public bool _isWorking = true;


    void Start()
    {
        triggerStates = new int[triggers.Length];
        for (int r = 0; r < triggerStates.Length; r++ ) { triggerStates[r] = 0; }
        foreach (var tr in triggers)
        {
            ActivateTrigger(tr);
            ActivateTrigger(tr);
            tr.Init(_uiManager, this);
        }

        _light.color = _correctColor;
    }

    //Сломать все переключатели
    public void BreakSome()
    {
        _isWorking = false;

        //Случайная поломка генератора
        int y = 0;
        for (int r = 0; r < triggers.Length; r++)
        {
            var possibility = UnityEngine.Random.Range(0, 100);
            if (possibility < 70)
            {
                var rot = triggers[y].transform.GetChild(1).transform.rotation;
                triggers[y].transform.GetChild(1).transform.rotation = Quaternion.Euler(rot.x, rot.y, 45);
            }
            
        }
    }

    //Сломать все переключатели
    public void BreakAll()
    {
        _isWorking = false;

        //Случайная поломка генератора
        int y = 0;
        for (int r = 0; r < triggers.Length; r++)
        {
            var rot = triggers[y].transform.GetChild(1).transform.rotation;
            triggers[y].transform.GetChild(1).transform.rotation = Quaternion.Euler(rot.x, rot.y, 45);

        }

        _light.color = _inCorrectColor;
    }

    //Сломать все переключатели
    public void ActivateTrigger(Trigger trigger)
    {
        var num = Array.IndexOf(triggers, trigger);
        var rot = triggers[num].transform.GetChild(1).transform.rotation;

        if (triggerStates[num] == 0)
        {
            triggerStates[num] = 1;
            triggers[num].transform.GetChild(1).transform.rotation = Quaternion.Euler(rot.x, rot.y, 45);
        }
        else
        {
            triggerStates[num] = 0;
            triggers[num].transform.GetChild(1).transform.rotation = Quaternion.Euler(rot.x, rot.y, 135);
        }

        if (!triggerStates.Contains(0))
        {
            _isWorking = true;
            _light.color = _correctColor;
            EventManager.Instance.EndEvent();

            foreach(Trigger trig in triggers)
                trig.DisableInteracteble();
        }
    }
}
