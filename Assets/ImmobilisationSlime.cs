using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobilisationSlime : MonoBehaviour
{
    [SerializeField]
    public int duration = 4000;

    private SkinnedMeshRenderer rend;
    private Rigidbody boule;
    GameObject guitarHero;
    bool toggle = false;

    private void Start()
    {
        rend = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        guitarHero = GameObject.Find("GuitarHero");
    }

    private void Update()
    {
        duration--;
        if (duration < 2000 && duration % 300 == 0)
        {
            toggle = !toggle;
            rend.enabled = toggle;
        }
        if(duration <= 0)
        {
            Destroy(gameObject);
        }
    } 
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Boule")
        {
            boule = collision.collider.attachedRigidbody;
            boule.constraints = RigidbodyConstraints.FreezeAll;
            guitarHero.GetComponent<GuitarHero>().enabled = true;
        }
    }
}
