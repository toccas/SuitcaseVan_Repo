using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnVehicle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    private bool onVehicle = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && onVehicle)
        {
            rb.isKinematic = true;
            col.enabled = false;
            onVehicle = false;
        }
    }
}
