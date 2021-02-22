using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverFlipper : MonoBehaviour
{
    [SerializeField]
    private KeyCode rotationkey;

    [SerializeField]
    private Vector3 rotation;

    [SerializeField]
    private float speed;
    private void Rotationner(KeyCode rotationKey, Vector3 rotation, float speed)
    {
        if (Input.GetKeyDown(rotationKey))
        {
            transform.Rotate(rotation, Space.Self);
            
        }
        if (Input.GetKeyUp(rotationKey))
            transform.Rotate(-1 * rotation, Space.Self);
    }
    
    
    private void Update()
    {
        Rotationner(rotationkey, rotation, speed);  
        
    }
}
