using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] Beam2Point b2p;
    [SerializeField] Transform laserMuzzle;

    bool init = false;

    private void Update()
    {
        // Если нажата клавиша "E" и игрок держит в руке нужный объект
        if (Input.GetKey(KeyCode.E) && PlayerContoller.Instance.hand == 1)
        {
            // Инициализация лазера при первом запуске
            if (!init)
            {
                init = true;
                transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
                b2p = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Beam2Point>();
                b2p.isActive = true;
            }

            // Активируем луч
            if (b2p != null)
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                // Если луч сталкивается с объектом
                if (Physics.Raycast(ray, out hit, 10))
                {
                    Vector3 hitPoint = hit.point;
                    b2p.point[1].transform.position = hitPoint;  // Точка столкновения
                    b2p.point[0].transform.position = transform.GetChild(1).transform.position;  // Позиция начала луча
                }
            }
        }
        else
        {
            // Деактивируем луч и сбрасываем флаг init
            if (b2p != null)
            {
                b2p.isActive = false;
                b2p = null;
                transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }

            

            // Сбрасываем init для повторной активации
            init = false;
        }


    }

}
