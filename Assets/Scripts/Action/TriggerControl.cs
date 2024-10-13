using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerControl : MonoBehaviour
{

    //Список всех триггеров
    [SerializeField] Trigger[] triggers;

    //Списсок состояний триггеров
    int[] triggerStates;

    //Состояние генератора
    bool _isWorking = true;


    void Start()
    {
        triggerStates = new int[triggers.Length];
        for (int r = 0; r < triggerStates.Length; r++ ) { triggerStates[r] = 0; }
        foreach (var tr in triggers)
        {
            ActivateTrigger(tr);
            ActivateTrigger(tr);
        }
    }

    //Сломать все переключатели
    void BreakSome()
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
    void BreakAll()
    {
        _isWorking = false;

        //Случайная поломка генератора
        int y = 0;
        for (int r = 0; r < triggers.Length; r++)
        {
            var rot = triggers[y].transform.GetChild(1).transform.rotation;
            triggers[y].transform.GetChild(1).transform.rotation = Quaternion.Euler(rot.x, rot.y, 45);

        }
    }

    //Сломать все переключатели
    void ActivateTrigger(Trigger trigger)
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
        }
    }

    

}
