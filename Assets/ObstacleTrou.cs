using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrou : MonoBehaviour
{
    //private CollisonBalle collisionFin;
    /*private void Awake()
    {
        collisionFin = GetComponent<CollisonBalle>();
    }*/
    [SerializeField]
    KeyCode activerKey;

    Vector3 positionDepart;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Activer(activerKey);
    }
    private void Activer(KeyCode activerKey)
    {
        if (Input.GetKeyDown(activerKey))
        {
            transform.Translate(0, -3, 0);

        }
        else if (Input.GetKeyUp(activerKey))
            transform.Translate(0, 3, 0);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        collisionFin.BalleDetruit();
    }*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.GetContact(0).thisCollider.gameObject.name == "Balle") 
        {
            
        }

    }
}
