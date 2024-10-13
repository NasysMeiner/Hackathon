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

    //������� ��������� ����� �����, ������� ��� ���������
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

    //���� ���������� ������ �� ������ �� �����
    IEnumerator FlashLight()
    {
        //���������� �� ���� ��� ������
        var upward = true;
        var time = 1f;

        while (true)
        {
            yield return new WaitForSeconds(0.02f);

            //����� ��������
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

            //��������� ������� �������� � ������� ����
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
