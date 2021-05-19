using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour
{
    [SerializeField]
    float Speed;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = -transform.forward * Speed;
    }
}
