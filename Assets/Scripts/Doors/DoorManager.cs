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


    //Открыть дверь по номеру
    public void OpenDoor(Door door)
    {
        doors[door.num].OpenDoor(0.4f);
    }

    //Открыть все двери
    public void OpenAllDoor()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor(0.4f);
        }
    }

    //Открыть все двери
    public void CloseAllDoor()
    {
        foreach (Door door in doors)
        {
            door.CloseDoor(0.4f);
        }
    }

}
