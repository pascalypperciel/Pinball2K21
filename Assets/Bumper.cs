using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bumper : MonoBehaviour
{
    [SerializeField] float puissance = 1f;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * puissance, ForceMode.Impulse);
        }
        if(anim != null)
        {
            anim.SetTrigger("activate");
        }
    }
}
