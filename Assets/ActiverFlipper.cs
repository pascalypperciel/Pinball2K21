using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverFlipper : MonoBehaviour
{
    [SerializeField]
    private KeyCode rotationkey;

    [SerializeField]
    private Vector3 rotation;

    
    private void Rotationner(KeyCode rotationKey, Vector3 rotation)
    {
        if (Input.GetKeyDown(rotationKey))
        {
            transform.Rotate(rotation, Space.Self);
            
        }
        else if (Input.GetKeyUp(rotationKey))
            transform.Rotate(-1 * rotation, Space.Self);
    }   
    private void Update()
    {
        Rotationner(rotationkey, rotation);  
        
    }
}
