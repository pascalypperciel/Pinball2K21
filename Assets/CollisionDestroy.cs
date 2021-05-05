using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("CollisionDestroy: " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
