using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed, jumpSpeed; //скорость перса, сила прыжка и чувствительность мыши, настраивай в инспекторе
    float vertical, horizontal, jump;
    bool isGrounded;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;

        if (isGrounded)
        GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Impulse);

        transform.Translate(new Vector3(horizontal, 0, vertical));
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
