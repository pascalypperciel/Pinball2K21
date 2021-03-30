using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float intensité = 10;

    [SerializeField]
    bool activé = false;

    Camera cam;
    Vector3 camPositionDébut;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        camPositionDébut = cam.transform.position;
        cam.transform.position = camPositionDébut;
    }

    private void Update()
    {
        if(activé)
        {
            CallInvokeRepeating();
            Invoke("ÉteindreBool", 1);
            cam.transform.position = camPositionDébut;
        }
        else
        {
            activé = false;
            cam.transform.position = camPositionDébut;
        }
    }

    void ÉteindreBool()
    {
        activé = false;
    }

    void CallInvokeRepeating()
    {
        InvokeRepeating("ShakerCamera", 0, 0.06f);
    }

    void ShakerCamera()
    {
        cam.transform.position = camPositionDébut + Random.insideUnitSphere * intensité;
    }
}