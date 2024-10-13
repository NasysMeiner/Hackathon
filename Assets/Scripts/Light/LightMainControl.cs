using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMainControl : MonoBehaviour
{

    int state = 0;

    [SerializeField] Light[] emergency;
    [SerializeField] Light[] st_lights;
    [SerializeField] Light flashLight;

    private void Start()
    {
        ChangeState("Standard");
    }

    //Сменить состояние всего света, ключить или выключить
    public void ChangeState(string str)
    {
        switch (str)
        {
            case "Standard":
                foreach (Light light in st_lights)
                { light.enabled = true; }
                foreach (Light light in emergency)
                { light.enabled = false; }
                flashLight.enabled = false;
                break;
            case "Emergency":
                foreach (Light light in emergency)
                { light.enabled = true; }
                foreach (Light light in st_lights)
                { light.enabled = false; }
                flashLight.enabled = true;
                StartCoroutine(FlashLight());
                break;
            case "Off":
                foreach (Light light in emergency)
                { light.enabled = false; }
                foreach (Light light in st_lights)
                { light.enabled = false; }
                flashLight.enabled = true;
                break;
        }
    }

    //Свет постепенно мигает то светом то тьмой
    IEnumerator FlashLight()
    {
        //Зажигается ли свет или тухнет
        var upward = true;
        var time = 1f;

        while (true)
        {
            yield return new WaitForSeconds(0.02f);

            //Смена значений
            if (upward)
            {
                foreach (Light light in emergency)
                { light.intensity += 0.02f / time; }
            }
            else
            {
                foreach (Light light in emergency)
                { light.intensity -= 0.02f / time; }
            }

            //Поставить границы значений и сменить флаг
            if (emergency[0].intensity >= 1 || emergency[0].intensity <= 0)
            {
                upward = !upward;
                var value = emergency[0].intensity > 1 ? 1 : 0;
                foreach (Light light in emergency)
                { light.intensity = value; }
            }

            if (emergency[0].enabled == false)
            {
                foreach (Light light in emergency)
                { light.intensity = 0; }
                break;
            }
        }
    }

}
