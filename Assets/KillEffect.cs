using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEffect : MonoBehaviour
{
    void Awake()
    {
        Invoke("D�truire", 1);
    }

    void D�truire()
    {
        Destroy(gameObject);
    }
}
