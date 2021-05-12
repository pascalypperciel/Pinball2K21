using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToClone;

    [SerializeField]
    private Transform spawnPoint;

    private GameObject gO;
    private void Update()
    {
        
    }
    public void Spawn()
    {
        gO = Instantiate(objectToClone, spawnPoint.position, Quaternion.identity);
        gO.layer = 7;
    }
}
