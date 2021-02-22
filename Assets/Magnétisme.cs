using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnétisme : MonoBehaviour
{
    [SerializeField]
    float Force;

    enum sorteAimant { Attraction, Répulsion };
    [SerializeField]
    sorteAimant sorte;

    Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        if(sorte == sorteAimant.Attraction)
        {
            rb.velocity = rb.velocity + (transform.position - (rb.transform.position + rb.centerOfMass)) * Force * Time.deltaTime;
        }
        else
        {
            rb.velocity = rb.velocity - (transform.position - (rb.transform.position + rb.centerOfMass)) * Force * Time.deltaTime;
        }
    }
}
