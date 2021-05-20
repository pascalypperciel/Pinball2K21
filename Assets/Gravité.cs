using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravité : MonoBehaviour
{
    //Ce script ne sera pas utilisé sur les missiles car sinon ils ne seraient pas
    //aussi amusant à utiliser.
    GameObject machine;
    Rigidbody rb;
    float force;
    float distance;
    const float masseMachine = 9000000f;
    const float forceGravitationelle = 0.000000000066743f;

    private void Start()
    {
        machine = GameObject.Find("PointGravité");
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        distance = gameObject.transform.position.y - machine.transform.position.y;
        force = forceGravitationelle * (rb.mass * masseMachine) / Mathf.Pow(distance,2);
        rb.velocity -= new Vector3(0, force, 0);
    }
}
