using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] Door[] doors;

    public void Start()
    {
        OpenAllDoor();
        Invoke("CloseAllDoor", 1);
    }


    //������� ����� �� ������
    public void OpenDoor(Door door)
    {
        doors[door.num].OpenDoor(0.4f);
    }

    //������� ��� �����
    public void OpenAllDoor()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor(0.4f);
        }
    }

    //������� ��� �����
    public void CloseAllDoor()
    {
        foreach (Door door in doors)
        {
            door.CloseDoor(0.4f);
        }
    }

}
