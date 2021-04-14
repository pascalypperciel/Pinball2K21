using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrou : MonoBehaviour
{
    [SerializeField]
    KeyCode activerKey;

    [SerializeField]
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(position.x + 100, position.y, position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Activer(KeyCode activerKey)
    {
        if (Input.GetKeyDown(activerKey))
        {
            transform.Translate(position.x, position.y, position.z);

        }
        else if (Input.GetKeyUp(activerKey))
            transform.Translate(position.x + 100, position.y, position.z);
    }
}
