using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float intensit� = 10;

    [SerializeField]
    bool activ� = false;

    Camera cam;
    Vector3 camPositionD�but;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        camPositionD�but = cam.transform.position;
        cam.transform.position = camPositionD�but;
    }

    private void Update()
    {
        if(activ�)
        {
            CallInvokeRepeating();
            Invoke("�teindreBool", 1);
            cam.transform.position = camPositionD�but;
        }
        else
        {
            activ� = false;
            cam.transform.position = camPositionD�but;
        }
    }

    void �teindreBool()
    {
        activ� = false;
    }

    void CallInvokeRepeating()
    {
        InvokeRepeating("ShakerCamera", 0, 0.06f);
    }

    void ShakerCamera()
    {
        cam.transform.position = camPositionD�but + Random.insideUnitSphere * intensit�;
    }
}