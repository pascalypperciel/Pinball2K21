using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    GameObject otherTP;

    private void Start()
    {
        otherTP = GameObject.Find("TeleporterOut");
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject boule = other.gameObject;
        boule.transform.position = otherTP.transform.position;
        boule.transform.rotation = otherTP.transform.rotation;
        Rigidbody rb = other.attachedRigidbody;
        rb.velocity = transform.right * 2;
    }
}
