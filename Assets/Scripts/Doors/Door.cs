using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Номер двери
    public int num;

    [SerializeField] GameObject[] doorParts;
    Vector3 pos1Up = Vector3.zero;
    Vector3 pos2Up = new Vector3(0, -1.2f, 0);
    Vector3 pos1Down = new Vector3(0,0.73f,0);
    Vector3 pos2Down = new Vector3(0, 2.2f, 0);

    [SerializeField] GameObject rot;
    //[SerializeField] GameObject cam;

    public void Update()
    {
        if (rot != null)
        {
            rot.transform.Rotate(0, 0.1f, 0);
            /*var offset = new Vector3(216.5f, cam.transform.position.y, -30.3999996f);
            cam.transform.position += (offset - cam.transform.position) / 1000;*/
        }
    }

    public void OpenDoor(float time)
    {
        StartCoroutine(OpenAnimation(true, time));
    }

    public void CloseDoor(float time)
    {
        StartCoroutine(OpenAnimation(false, time));
    }


    //Анимация открытия и закрытия дери
    public IEnumerator OpenAnimation(bool isUp, float time)
    {
        var timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / time);

            // Линейная интерполяция позиции двери с нормализованным прогрессом
            if (isUp)
            {
                doorParts[0].transform.localPosition = Vector3.Lerp(pos1Up, pos2Up, progress);
                doorParts[1].transform.localPosition = Vector3.Lerp(pos1Down, pos2Down, progress);
            }
            else
            {
                doorParts[0].transform.localPosition = Vector3.Lerp(pos2Up, pos1Up, progress);
                doorParts[1].transform.localPosition = Vector3.Lerp(pos2Down, pos1Down, progress);
            }

            yield return null;  // Подождем один кадр перед следующим шагом
        }

        // Убедимся, что двери точно находятся в конечных позициях
        if (isUp)
        {
            doorParts[0].transform.localPosition = pos2Up;
            doorParts[1].transform.localPosition = pos2Down;
        }
        else
        {
            doorParts[0].transform.localPosition = pos1Up;
            doorParts[1].transform.localPosition = pos1Down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor(1f);
            transform.parent.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CloseDoor(1f);
            transform.parent.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
