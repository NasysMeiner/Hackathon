using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(FuelController))]
public class PlayerContoller : MonoBehaviour
{
    public static PlayerContoller Instance;
    public static FuelController FuelController;
    public int hand;
    public float speed; //скорость перса настраивай в инспекторе
    float vertical, horizontal;

    GameObject currentItem;
    public GameObject kanistra, payalnik;
    public Transform itemSpawner;

    private void Awake()
    {
        Instance = this;
        FuelController = GetComponent<FuelController>();
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        transform.Translate(new Vector3(horizontal, 0, vertical));
        try
        {
            if (Input.GetKey("1") || Input.GetKey("2"))
                Items(Convert.ToInt32(Input.inputString));
        }
        catch (Exception e)
        {
            Debug.Log(Input.inputString);
        }
    }

    void Items(int num)
    {
        if (currentItem != null)
            Destroy(currentItem);

        hand = num;

        switch (num)
        {
            case 1:
                currentItem = Instantiate(payalnik,itemSpawner);
                return;
            case 2:
                currentItem = Instantiate(kanistra, itemSpawner);
                return;
        }
    } 
}
