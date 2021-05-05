using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnétisme : MonoBehaviour
{
    [SerializeField]
    float Force;

    enum sorteAimant { Attraction = 1, Répulsion = -1};
    bool inRange = false;

    [SerializeField]
    sorteAimant sorte = (sorteAimant) 1;

    Rigidbody rb;
    Renderer rdr;

    private void Start()
    {
        rdr = gameObject.GetComponent<Renderer>();
        ChangerCouleur(sorte);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            sorte = (sorteAimant) ((int) sorte * -1);
            ChangerCouleur(sorte);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            rdr.material.SetColor("_Color", Color.blue);
            if(inRange && rb != null)
            {
                rb.velocity = rb.velocity + (transform.position - (rb.transform.position + rb.centerOfMass)) * Force * Time.deltaTime * (int) sorte;
            }
        }
        else
        {
            ChangerCouleur(sorte);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        inRange = true;
        rb = other.GetComponent<Rigidbody>();
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
    private void ChangerCouleur(sorteAimant sorte)
    {
        int sorteInt = (int) sorte;
        if(sorteInt == 1)
        {
            rdr.material.SetColor("_Color", Color.red);
        }
        else if (sorteInt == -1)
        {
            rdr.material.SetColor("_Color", Color.yellow);
        }
    }
}
