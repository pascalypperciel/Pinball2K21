using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToClone;

    [SerializeField]
    private Transform spawnPoint;

    public void Spawn()
    {
        Instantiate(objectToClone, spawnPoint.position, transform.rotation);
    }
}
