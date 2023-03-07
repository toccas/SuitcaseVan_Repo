using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuchGround : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.isKinematic = true;
        }
    }

}
