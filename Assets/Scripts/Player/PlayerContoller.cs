using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed, jumpSpeed; //скорость перса, сила прыжка и чувствительность мыши, настраивай в инспекторе
    float vertical, horizontal, jump;
    bool isGrounded;

    GameObject currentItem;
    public GameObject kanistra, payalnik;
    public Transform itemSpawner;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;

        if (isGrounded)
        GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Impulse);

        transform.Translate(new Vector3(horizontal, 0, vertical));

        if (Input.GetKey("1") || Input.GetKey("2"))
            Items(int.Parse(Input.inputString));
    }

    void Items(int num)
    {
        if (currentItem != null)
            Destroy(currentItem);

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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
