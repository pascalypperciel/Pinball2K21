using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Puncher : MonoBehaviour
{
    float puissance;
    float maxPuissance = 16f;
    float puissanceParTic = 2;

    public Animator plungerAnim;

    Rigidbody ballRb;
    ContactPoint contact;

    bool ballReady;

    void Update()
    {
        if(ballReady)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if(puissance <= maxPuissance)
                {
                    puissance += puissanceParTic * Time.deltaTime;
                }
                plungerAnim.SetBool("activate", true);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if(ballRb != null)
                {
                    ballRb.AddForce(-1 * puissance * contact.normal, ForceMode.Impulse);
                }
                plungerAnim.SetBool("activate", false);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        ballReady = true;
        puissance = 0f;
        contact = collision.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    void OnCollisionExit(Collision collision)
    {
        ballReady = false;
        ballRb = null;
    }
}
