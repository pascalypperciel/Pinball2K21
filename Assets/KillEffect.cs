using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEffect : MonoBehaviour
{
    void Awake()
    {
        Invoke("Détruire", 1);
    }

    void Détruire()
    {
        Destroy(gameObject);
    }
}
