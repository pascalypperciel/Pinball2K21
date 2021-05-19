using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrou : MonoBehaviour
{

    [SerializeField]
    KeyCode activerKey;

    Vector3 positionDepart;

    

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

    private void OnCollisionEnter(Collision other)
    {
        if (other.GetContact(0).thisCollider.gameObject.name == "Balle") 
        {
            
        }

    }
}
