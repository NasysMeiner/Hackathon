using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public static ItemMove instance;
    bool startMove = true;
    bool endMove = false;
    Vector3 move = Vector3.zero;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (startMove)
        {
            move += new Vector3(-0.01f, 0.01f, 0);
            transform.position = move;
            if(move.x == 0.18)
                startMove = false;
        }

        if (endMove)
        {
            move -= new Vector3(-0.01f, 0.01f, 0);
            transform.position = move;
            if (move.x == 0)
                Destroy(gameObject);
        }
    }

    public void DeleteItem()
    {
        endMove = true;
    }
}
