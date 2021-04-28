using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrou : MonoBehaviour
{
    private CollisonBalle collisionFin;
    private void Awake()
    {
        collisionFin = GetComponent<CollisonBalle>();
    }
    [SerializeField]
    KeyCode activerKey;

    Vector3 positionDepart;

    // Start is called before the first frame update
    void Start()
    {
        positionDepart = transform.position;
        transform.Translate(positionDepart.x + 10, positionDepart.y, positionDepart.z);
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
            transform.Translate(positionDepart.x, positionDepart.y, positionDepart.z);

        }
        else if (Input.GetKeyUp(activerKey))
            transform.Translate(positionDepart.x + 10, positionDepart.y, positionDepart.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        collisionFin.BalleDetruit();
    }
   
}
