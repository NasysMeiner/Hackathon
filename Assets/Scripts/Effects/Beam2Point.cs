using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Beam2Point : MonoBehaviour
{
    [SerializeField] float y_center_offset;
    [SerializeField] float x_center_offset;

    [SerializeField] Material[] material;

    [SerializeField] float timeToChange;
    [SerializeField] Transform[] point;
    Vector3[] points;

    [SerializeField] LineRenderer lr;
    int r = 0;

    public bool isActive = true;
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
            if(coroutine == null)
                coroutine = StartCoroutine(Animation());
        }
    }

    //��������� �������� � ����� 
    private IEnumerator Animation()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(timeToChange);
            FindCenter();
            lr.SetPositions(points);
        }
    }


    //�������� ��������� ����� �����
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
