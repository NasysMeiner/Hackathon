using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class Beam2Point : MonoBehaviour
{
    [SerializeField] float y_center_offset;
    [SerializeField] float x_center_offset;

    [SerializeField] Material[] material;

    [SerializeField] float timeToChange;
    [SerializeField] public Transform[] point;
    Vector3[] points;

    [SerializeField] LineRenderer lr;
    int r = 0;

    public bool isActive = false;
    private Coroutine coroutine;

    private void Start()
    {
        points = new Vector3[3];
        lr.positionCount = 3;
    }

    private void Update()
    {
        if (isActive)
        {
            if (coroutine == null)
            {
                point[1].gameObject.SetActive(true);
                coroutine = StartCoroutine(Animation());
            }
        }
        else
        {
            point[1].gameObject.SetActive(false);
            lr.SetPositions(new Vector3[3]);

            // Останавливаем корутину и сбрасываем её
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;  // Сбросить, чтобы можно было перезапустить
            }
        }
    }

    // Основная анимация и смена 
    private IEnumerator Animation()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(timeToChange);
            FindCenter();
            lr.SetPositions(points);
        }

        // Завершение корутины
        coroutine = null;
    }


    //Получаем рандомный центр линии
    private void FindCenter()
    {
        var start = point[0].position;
        var end = point[1].position;

        var xOffset = Random.Range(-x_center_offset, x_center_offset) * Vector3.left;
        var yOffset = Random.Range(-x_center_offset, x_center_offset) * Vector3.up;
        var zOffset = Random.Range(-x_center_offset, x_center_offset) * Vector3.forward;
        
        var center = (end + start) / 2 + xOffset + yOffset + zOffset;

        var mat = new List<Material>();
        r = r == 0 ? 1 : 0;
        lr.material = material[r];

        points[0] = start /*+ xOffsetS + yOffsetS*/;
        points[1] = center;
        points[2] = end /*+ xOffsetE + yOffset*/;


    }
}
