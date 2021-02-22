using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    [SerializeField]
    float Speed;

    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
    }
}
