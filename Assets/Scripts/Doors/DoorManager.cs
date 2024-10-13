using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] Door[] doors;


    //������� ����� �� ������
    public void OpenDoor(Door door)
    {
        doors[door.num].OpenDoor(0.2f);
        doors[door.num].transform.parent.GetComponent<BoxCollider>().enabled = false;
    }

    //������� ��� �����
    public void OpenAllDoor()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor(0.2f);
            door.transform.parent.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //������� ��� �����
    public void CloseAllDoor()
    {
        foreach (Door door in doors)
        {
            door.CloseDoor(0.2f);
            door.transform.parent.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
