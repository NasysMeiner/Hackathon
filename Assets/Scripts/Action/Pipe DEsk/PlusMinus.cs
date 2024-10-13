using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlusMinus : MonoBehaviour
{
    public static PlusMinus Instance;
    public List<GameObject> pipes;
    public GameObject all;

    private void Awake()
    {
        Instance = this;
    }

    public void isWin(GameObject zxc)
    {
        int a = 0;
        bool isMach = false;
        foreach(GameObject pivo in pipes)
        {
            if(pivo == zxc) 
            {
                isMach = true;
                break;
            }
        }
        if(!isMach)
        pipes.Add(zxc);
        
        foreach(GameObject go in pipes)
        {
            if (go.GetComponent<Pipe>().isWin == true)
                a++;
        }
        if (a >= 7)
            Debug.Log("zxc");
    }
}
