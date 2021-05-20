using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnétisme : MonoBehaviour
{
    [SerializeField]
    float courantAmpère;

    enum sorteAimant { Attraction = 1, Répulsion = -1};
    bool inRange = false;

    [SerializeField]
    sorteAimant sorte = (sorteAimant) 1;

    Rigidbody rb;
    Renderer rdr;

    //Constante magnétique
    private float u0 = 4 * Mathf.PI * Mathf.Pow(10, -7);

    float distance;
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
            distance = Vector3.Distance(gameObject.transform.position, rb.transform.position);
            rdr.material.SetColor("_Color", Color.blue);
            if(inRange && rb != null)
            {
                //Formule du Théorème d'Ampères: force du champ magnétique = (constante magnétique * courant) / (2 * pi * distance).
                //On peut la voir intégré ci-dessous.
                rb.velocity = rb.velocity + (transform.position - (rb.transform.position + rb.centerOfMass)) * (u0 * courantAmpère) / (2 * Mathf.PI * distance) * Time.deltaTime * (int)sorte;
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
